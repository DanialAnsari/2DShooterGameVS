using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace hellogame
{
    public partial class Stage2 : Form
    {
        int x = 12;
        int y = 387;
        int Life = 100;
        int energy = 10;
        int tries = 3;
        int time = 62;
        int stage = 2;
        int e1x = 735;
        int e1y = 167;
        int count = 1;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int e1life = 3;
        int pause = 0;
        int pause2 = 0;
        int e1dead = 0;
        int pointer = -1;
        int walk = 0;
        int delay = 0;
        int plx = 374;
        int ply = 132;
        public Stage2()
        {
            InitializeComponent();
            LifeChange();
            EnergyChange();

            megasprite.Location = new System.Drawing.Point(x, y);
            SetEnemyLocation();

          

            Thread thread1 = new Thread(EnemyLoop);
            thread1.Start();

            Thread thread2 = new Thread(Timer);
            thread2.Start();

            TriesChange();
        }
        DataTable tb = new DataTable("Names");
        public Stage2(int lifeu, int energyu, int xu, int yu, int e1xu, int e1yu, int timeu,int e1dead, int triesu)
        {
            try
            {
                InitializeComponent();
              
                Life = lifeu;
                energy = energyu;
                x = xu;
                y = yu;
                e1x = e1xu;
                e1y = e1yu;
                time = timeu;
                tries = triesu;
                LifeChange();
                EnergyChange();

                megasprite.Location = new System.Drawing.Point(x, y);
                Thread thread = new Thread(myLoop);
                thread.Start();

                Thread thread1 = new Thread(EnemyLoop);
                thread1.Start();

                Thread thread2 = new Thread(Timer);
                thread2.Start();

                //Thread thread3 = new Thread(quickload);
                //thread3.Start();

                TriesChange();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public bool onMoving_Platform() {
            if (x >= plx - 76 && x <= plx + 70 && y >= ply - 60 && y <= ply - 55)
            {
                return true;
            }
            else {
                return false;
            }
        }

        PictureBox pb = new PictureBox();

        PictureBox pl2 = new PictureBox();

        PictureBox pl3 = new PictureBox();
        public void LifeChange()
        {
            if (Life == 100)
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\lifefull2.png");
            }

            else if (Life == 75)
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\lifefull2 -75.png");
            }
            else if (Life == 50)
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\lifefull2 -50.png");
            }

            else if (Life == 25)
            {
                pictureBox1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\lifefull2 -25.png");
            }

            else if (Life == 0)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\lifefull2 -0.png");
                    pause2 = 1;
                    megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Explotion.gif");
                    System.Threading.Thread.Sleep(1500);
                    megasprite.Visible = false;


                    pl2.Location = new System.Drawing.Point(360, 140);
                    pl2.Size = new Size(274, 304);
                    pl2.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Game-Over.png");

                    pictureBox6.Visible = false;
                    megasprite.Visible = false;
                    Enemy1.Visible = false;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

       
    }

        public void EnergyChange()
        {
            label4.Text = energy.ToString();
        }

        public void SetEnemyLocation()
        {
            Enemy1.Location = new System.Drawing.Point(e1x, e1y);
        }

        public void SetPlatformLocation()
        {
            pictureBox4.Location = new System.Drawing.Point(plx, ply);
        }

        private void myLoop()
        {
            while (pause != 6 && e1dead==1)
            {
                if (pause == 0)
                {
                    if (count2 == 0)
                    {
                        if (onMoving_Platform()==true) {
                            x--;
                        }
                       
                            plx--;
                        System.Threading.Thread.Sleep(10);
                       
                    }
                    else if (count2 == 1)
                    {
                        if (onMoving_Platform() == true)
                        {
                            x++;
                        }
                       
                            plx++;

                        System.Threading.Thread.Sleep(10);
                    }

                    if (plx < 370)
                    {
                       
                        count2 = 1;
                    }
                    if (plx > 580)
                    {
                       
                        count2 = 0;
                    }

                  
                    SetPlatformLocation();
                    megasprite.Location = new System.Drawing.Point(x, y);
                }
            }
           
        }

        private async void Timer()
        {
            while (time > 0)
            {
                if (pause == 0)
                {
                    time--;
                    await Task.Delay(1000);
                    label3.Text = time.ToString();
                }
            }
            Life = 0;
            LifeChange();

        }

        public void TriesChange()
        {
            label1.Text = tries.ToString();
        }


        private async void TakeDamage()
        {
            count4 = 1;
            megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megaman-damaged.png");
            x = x - 20;
            megasprite.Location = new System.Drawing.Point(x, y);
            Life = Life - 25;
            LifeChange();
            await Task.Delay(300);


            if (count == 1)
            {
                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand.png");
            }

            else if (count == 0)
            {
                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand-Left.png");
            }
            count4 = 0;

        }

        private void Stage2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (pause2 == 1)
                {
                    this.Controls.Add(pl2);
                }

                if (count4 == 0 && pause == 0 && pause2 == 0)
                {
                   

                        Thread thread1 = new Thread(Fall);
                        thread1.Start();
                   

                    if (e.KeyChar == 'd')
                    {
                        walk = 1;
                        if (count3 == 0)
                        {

                            megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megawalk-right.gif");
                        }
                        if (WallCheck1('d', x, y))
                        {
                            if (count3 == 1)
                            {
                                x = x + 5;
                            }
                            else {
                                x = x + 3;

                            }
                        }
                        megasprite.Location = new System.Drawing.Point(x, y);
                        count = 1;
                        if (x > 1035 && y >= 357 && e1dead == 1)
                        {
                            for (int i = 0; i < 50; i++)
                            {
                                x = x + 3;
                                System.Threading.Thread.Sleep(100);
                                megasprite.Location = new System.Drawing.Point(x, y);
                            }
                            BossStage bs = new BossStage();
                            this.Hide();
                            bs.ShowDialog();
                            this.Close();
                        }

                        if (delay == 0)
                        {
                            Thread ts = new Thread(Delay);
                            ts.Start();
                        }
                        walk = 0;
                        //if (count3 == 0) {
                        //    megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand.png");
                        //}
                    }

                    if (e.KeyChar == 'a')
                    {
                        walk = 1;
                        if (count3 == 0)
                        {
                            megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megawalk.gif");
                        }
                        if (WallCheck1('a', x, y) == true)
                        {
                            if (count3 == 1)
                            {
                                x = x - 5;


                            }
                            else {
                                x = x - 3;
                            }
                        }
                        megasprite.Location = new System.Drawing.Point(x, y);
                        count = 0;

                        if (delay == 0)
                        {
                            Thread ts = new Thread(Delay);
                            ts.Start();
                        }
                        walk = 0;
                    }

                    else if (e.KeyChar == 'w' && count3 == 0)
                    {

                        Thread thread = new Thread(MoveUp);
                        thread.Start();



                    }

                    else if (pause2 == 1 && e.KeyChar == 's')
                    {

                        pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Game Over-2.png");
                        pause++;
                    }

                    else if (pause2 == 1 && e.KeyChar == 'l')
                    {
                        tries--;

                        this.Hide();
                        if (tries != 0)
                        {
                            Stage2 fm = new Stage2(); ;
                            fm.ShowDialog();
                        }
                        else {
                        }
                        this.Close();

                    }

                    else if (pause2 == 2 && e.KeyChar == 'w')
                    {
                        pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Game-Over.png");
                        pause--;

                    }

                    else if (e.KeyChar == 'p')
                    {
                        pause = 1;

                        pb.Location = new System.Drawing.Point(360, 140);
                        pb.Size = new Size(274, 304);
                        pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Pause_Resume.png");

                        pictureBox6.Visible = false;
                        megasprite.Visible = false;
                        Enemy1.Visible = false;

                        this.Controls.Add(pb);
                    }



                    else if (e.KeyChar == 'l')
                    {
                        Fire();
                    }
                }
                if (pause == 1 && e.KeyChar == 's')
                {

                    pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Pause_Save.png");
                    pause++;
                }

                else if (pause == 2 && e.KeyChar == 's')
                {

                    pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Pause_Quit.png");
                    pause++;
                }

                else if (pause == 3 && e.KeyChar == 'w')
                {
                    pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Pause_Save.png");
                    pause--;
                }
                else if (pause == 2 && e.KeyChar == 'w')
                {
                    pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Pause_Resume.png");
                    pause--;
                }

                else if (pause == 1 && e.KeyChar == 'l')
                {
                    pause = 0;
                    pictureBox6.Visible = true;
                    megasprite.Visible = true;
                    Enemy1.Visible = true;
                    this.Controls.Remove(pb);
                }

                else if (pause == 2 && e.KeyChar == 'l')
                {
                    Save();
                }

                else if (pause == 3 && e.KeyChar == 'l')
                {
                    this.Close();
                }

                else if (pause2 == 1 && e.KeyChar == 's')
                {

                    pl2.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Game Over-2.png");
                    pause2++;
                }

                else if (pause2 == 1 && e.KeyChar == 'l')
                {
                    tries--;

                    this.Hide();
                    if (tries != 0)
                    {
                        Form1 fm = new Form1(3);
                        fm.ShowDialog();
                    }
                    else {
                    }
                    this.Close();

                }

                else if (pause2 == 2 && e.KeyChar == 'w')
                {
                    pl2.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Game-Over.png");
                    pause2--;

                }

                else if (pause2 == 2 && e.KeyChar == 'l')
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void Fall()
        {

            if (count3 == 0)
            {
                while (y < 387 && OnPlatform() == false)
                {
                    count3 = 1;
                    if (count == 1)
                    {
                        megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Megajump.png");
                    }
                    else if (count == 0)
                    {
                        megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Megajump -Left.png");
                    }
                    y = y + 4;
                    megasprite.Location = new System.Drawing.Point(x, y);
                    await Task.Delay(1);

                }
                if (y > 387)
                {
                    y = 387;
                    megasprite.Location = new System.Drawing.Point(x, y);
                }
                count3 = 0;
                while (x >= 322 && x <= 711 && y >= 387) {
                    TakeDamage();
                    System.Threading.Thread.Sleep(500);
                }
                
            }
        }


        public void Delay()
        {
            delay = 1;
            System.Threading.Thread.Sleep(400);
            if (walk == 0)
            {
                System.Threading.Thread.Sleep(400);
                if (walk == 0)
                {
                    System.Threading.Thread.Sleep(400);
                    if (walk == 0)
                    {
                        if (count == 1)
                        {
                            megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand.png");
                        }

                        else if (count == 0)
                        {
                            megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand-Left.png");
                        }
                    }
                }
            }
            delay = 0;
        }
        public void Save()
        {
            XmlTextWriter textwrite = new XmlTextWriter("C:\\Users\\dania\\Desktop\\GameSave.xml", null);

            textwrite.WriteStartDocument();

            //write comment
            textwrite.WriteComment("First Comment XmlTextWriter Sample");
            textwrite.WriteComment("myXmlFile.xml in root dir");
            //write student record

            textwrite.WriteStartElement("", "Progress", "");

            textwrite.WriteStartElement("", "Stage", "");
            textwrite.WriteString(stage.ToString());
            textwrite.WriteEndElement();

            //WriteState next element
            textwrite.WriteStartElement("", "Life", "");
            textwrite.WriteString(Life.ToString());
            textwrite.WriteEndElement();

            textwrite.WriteStartElement("", "Energy", "");
            textwrite.WriteString(energy.ToString());
            textwrite.WriteEndElement();


            textwrite.WriteStartElement("", "Time", "");
            textwrite.WriteString(time.ToString());
            textwrite.WriteEndElement();

            textwrite.WriteStartElement("", "Tries", "");
            textwrite.WriteString(tries.ToString());
            textwrite.WriteEndElement();



            textwrite.WriteStartElement("", "PlayerLocationX", "");
            textwrite.WriteString(x.ToString());
            textwrite.WriteEndElement();

            textwrite.WriteStartElement("", "PlayerLocationY", "");
            textwrite.WriteString(y.ToString());
            textwrite.WriteEndElement();

            textwrite.WriteStartElement("", "Enemy1", "");



            textwrite.WriteStartElement("", "EnemnyLocationX", "");
            textwrite.WriteString(e1x.ToString());
            textwrite.WriteEndElement();

            textwrite.WriteStartElement("", "EnemnyLocationY", "");
            textwrite.WriteString(e1y.ToString());
            textwrite.WriteEndElement();

            textwrite.WriteStartElement("", "EnemnyDead", "");
            textwrite.WriteString(e1dead.ToString());
            textwrite.WriteEndElement();

            textwrite.WriteEndElement();

            textwrite.WriteEndElement();
            textwrite.Flush();
            //close writer
            textwrite.Close();

            MessageBox.Show("Save Sucessful");
        }


        public async void Fire()
        {
           
            if (energy > 0)
            {
                energy = energy - 1;
                EnergyChange();
                if (count == 1)
                {
                    megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Megaman-fire.png");
                }

                else if (count == 0)
                {
                    megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Megaman-fireleft.png");
                }



                Thread thread = new Thread(BulletTravel);
                thread.Start();
                this.Controls.Add(pb);

                await Task.Delay(300);

                if (count == 1)
                {
                    megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand.png");
                }

                else if (count == 0)
                {
                    megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand-Left.png");
                }
            }
        }

        public bool WallCheck1(char a, int x, int y)
        {
            if (a == 'd')
            {


                if (x >= 40 && x <= 43 && y > 283)
                {
                    return false;
                }

                else if (x >= 144 && x <= 147 && y > 160)
                {
                    return false;
                }

                else if (x >= 710 && x <= 713 && y > 160)
                {
                    return false;
                }

                else if (y < 160) {

                    return true;
                }


                else {
                    return true;
                }
            }
            else
            {



                if (x >= 1000 && x <= 1003 && y > 283)
                {
                    return false;
                }

                else if (x >= 888 && x <= 891 && y > 160)
                {
                    return false;
                }

                else if (x >= 326 && x <= 323 && y > 160)
                {
                    return false;
                }

                else if (y < 160)
                {

                    return true;
                }


                else {
                    return true;
                }

            }

        }

        public void EnemyBuletTravel() {

            int xf = 0;
            int yf = 0;
            pictureBox12.Size = new Size(42, 33);
            pictureBox12.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\EnemyBullet.png");
           
           
                xf =e1x - 60;
                yf = e1y - 10;

            pictureBox12.Location = new System.Drawing.Point(xf, yf);
           
           
                while (xf > 0 && WallCheck1('a', xf, yf) == true)
                {

                    xf--;
                pictureBox12.Location = new System.Drawing.Point(xf, yf);
                    if (xf > x - 60 && xf < x + 60 && yf > y - 60 && yf < y + 60)
                    {

                    TakeDamage();

                        xf = xf + 500;
                        yf = yf - 500;
                      
                    }
                System.Threading.Thread.Sleep(1);
                }



            pictureBox12.Image = null;

        }
        private void BulletTravel()
        {
            int xf = 0;
            int yf = 0;
            pb.Size = new Size(42, 33);
            pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bullet.png");
            if (count == 1)
            {
                xf = x + 60;
                yf = y + 10;
            }
            else if (count == 0)
            {
                xf = x - 60;
                yf = y - 10;
            }
            pb.Location = new System.Drawing.Point(xf, yf);
            if (count == 1)
            {
                while (xf < 1000 && WallCheck1('d', xf, yf) == true)
                {
                    xf++;
                    pb.Location = new System.Drawing.Point(xf, yf);
                    if (xf > e1x - 60 && xf < e1x + 60 && yf > e1y - 60 && yf < e1y + 60)
                    {

                        e1life--;
                        xf = xf + 1000;
                        yf = yf - 1000;
                       
                        if (e1life == 0)
                        {
                            e1dead = 1;
                        }

                    }

                }

            }
            else if (count == 0)
            {
                while (xf > 0 && WallCheck1('a', xf, yf) == true)
                {
                    xf--;
                    pb.Location = new System.Drawing.Point(xf, yf);
                    if (xf > e1x - 60 && xf < e1x + 60 && yf > e1y - 60 && yf < e1y + 60)
                    {

                        e1life--;
                        xf = xf + 500;
                        yf = yf - 500;
                        if (e1life == 0)
                        {
                            e1dead = 1;
                        }
                    }

                }

            }

            pb.Image = null;
            pb.Location = new System.Drawing.Point(-1, -1);
            this.Controls.Remove(pb);

        }

        private async void MoveUp()
        {
            count3 = 1;
            if (count == 1)
            {
                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Megajump.png");
            }
            else if (count == 0)
            {
                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Megajump -Left.png");
            }

            for (int i = 0; i < 40; i++)
            {

                y = y - 4;
                megasprite.Location = new System.Drawing.Point(x, y);
                await Task.Delay(1);
            }
         
            for (int j = 0; j < 40; j++)
            {

                y = y + 4;
                megasprite.Location = new System.Drawing.Point(x, y);
                await Task.Delay(1);
                if (OnPlatform() == true)
                {
                    j = 50;
                }
            }

            if (count == 1)
            {
                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand.png");
            }

            else if (count == 0)
            {
                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megastand-Left.png");
            }
            count3 = 0;
        }

        public bool OnPlatform()
        {
            if ((y >= 280 && y <= 285 && x >= 45 && x <= 146) || (y >= 155 && y <= 160 && x >= 160 && x <= 305) || (y >= 155 && y <= 160 && x >= 740 && x<=875) || (y >= 275 && y <= 281 && x >= 890 && x <= 990) ||(onMoving_Platform() == true))
            {
                return true;
            }
            else {
                return false;
            }
        }


        public async void EnemyLoop()
        {

            try
            {
                e1dead = 0;

                while (pause != 6 && e1dead == 0)
                {

                    if (Math.Abs(x - e1x) < 550 && y <= 160)
                    {

                        Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Canon2Fire.png");
                        Thread t1 = new Thread(EnemyBuletTravel);
                        t1.Start();
                        await Task.Delay(300);
                        Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\CannonRecharge.png");
                        await Task.Delay(2000);
                    }
                }
                if (e1dead == 1)
                {
                    Enemy1.Visible = false;

                }



                Thread thread = new Thread(myLoop);
                thread.Start();
            }
            catch (Exception ex) {

            }
        }

        private void Stage2_FormClosed(object sender, FormClosedEventArgs e)
        {
            pause = 6;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }
    }
}
