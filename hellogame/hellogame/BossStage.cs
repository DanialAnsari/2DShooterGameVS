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
    public partial class BossStage : Form
    {

        int x = 12;
        int y = 387;
        int Life = 100;
        int energy = 10;
        int tries = 3;
        int time = 62;
        int stage = 1;
        int e1x = 673;
        int e1y = -30;
        int count = 1;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int e1life = 20;
        int pause = 0;
        int pause2 = 0;
        int e1dead = 0;
        int pointer = -1;
        int walk = 0;
        int delay = 0;
        int attack=0;
        public BossStage()
        {
            try
            {
                InitializeComponent();

                LifeChange();
                EnergyChange();

                megasprite.Location = new System.Drawing.Point(x, y);
                SetEnemyLocation();

                Thread thread = new Thread(myLoop);
                thread.Start();

                Thread thread2 = new Thread(Timer);
                thread2.Start();

                TriesChange();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


       
        public void SetEnemyLocation()
        {
            Enemy1.Location = new System.Drawing.Point(e1x, e1y);
        }
        

       


        PictureBox pb = new PictureBox();

        private void Form1_Load(object sender, EventArgs e)
        {


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
        private void myLoop()
        {
            pause2 = 1;   
            int xs = 67;
            int ys = 53;
            Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bossmini.png");
            while (e1y < 260) {
                e1y=e1y+4;

                System.Threading.Thread.Sleep(10);
                SetEnemyLocation();
            }

            Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\BossStand5.png");
            while (xs < 276 && ys < 190) {
                
                if (xs < 276) {
                    xs=xs+5;
                }

                if (ys < 190) {
                    ys=ys+5;
                }
                System.Threading.Thread.Sleep(10);
                Enemy1.Size = new System.Drawing.Size(xs,ys);

            }
            pause2 = 0;
            Random rnd = new Random();
            while (pause != 6 && e1dead == 0)
            {
                attack = rnd.Next(1, 4);
                if (attack == 1)
                {
                    int[] a = { 0, 0, 0 };
                    int temp = 0;
                    Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\BossStand3-Attack.png");
                    Enemy1.Size = new System.Drawing.Size(xs, ys);


                    pictureBox4.Location = new System.Drawing.Point(645, 301);
                    pictureBox4.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bossmini.png");



                    pictureBox6.Location = new System.Drawing.Point(645, 355);
                    pictureBox6.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bossmini.png");


                    pictureBox7.Location = new System.Drawing.Point(645, 409);
                    pictureBox7.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bossmini.png");

                    System.Threading.Thread.Sleep(500);

                    while (temp < 3)
                    {
                        attack = rnd.Next(0, 3);
                        if (attack == 0 && a[0] == 0)
                        {
                            a[attack] = 1;
                            int xf = 645;
                            int yf = 301;

                            while (xf > -100)
                            {

                                
                                xf--;
                                System.Threading.Thread.Sleep(1);

                                pictureBox4.Location = new System.Drawing.Point(xf, yf);
                                if (xf > x - 60 && xf < x + 60 && yf > y - 60 && yf < y + 60)
                                {

                                    TakeDamage();
                                    xf = -101;
                                    

                                }
                                //System.Threading.Thread.Sleep(1);
                            }

                            temp++;
                        }
                        else if (attack == 1 && a[1] == 0)
                        {
                            a[attack] = 1;
                            int xf = 645;
                            int yf = 355;

                            while (xf > -100)
                            {

                                xf--;
                                System.Threading.Thread.Sleep(1);

                                pictureBox6.Location = new System.Drawing.Point(xf, yf);
                                if (xf > x - 60 && xf < x + 60 && yf > y - 60 && yf < y + 60)
                                {

                                    TakeDamage();
                                    xf = -101;

                                }
                                //System.Threading.Thread.Sleep(1);
                            }

                            temp++;
                        }

                        else if (attack == 2 && a[2] == 0)
                        {
                            a[attack] = 1;
                            int xf = 645;
                            int yf = 409;

                            while (xf > -100)
                            {

                                xf--;
                                System.Threading.Thread.Sleep(1);
                                pictureBox7.Location = new System.Drawing.Point(xf, yf);
                                if (xf > x - 60 && xf < x + 60 && yf > y - 60 && yf < y + 60)
                                {

                                    TakeDamage();
                                    xf = -101;

                                }
                                //System.Threading.Thread.Sleep(1);
                            }
                            pictureBox7.Location = new System.Drawing.Point(xf, yf);
                            temp++;
                        }

                    }
                    Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\BossStand3-Attack.png");
                }

                else if (attack == 2) {
                    int temp = 0;


                    while (temp < 5) {
                        int by = 4;
                        int bx = x;
                        pictureBox4.Location = new System.Drawing.Point(bx, by);
                        pictureBox4.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bossmini.png");

                        while (by < 390) {
                            by++;

                            System.Threading.Thread.Sleep(2);
                            pictureBox4.Location = new System.Drawing.Point(bx, by);
                            if (bx > x - 60 && bx < x + 60 && by > y - 60 && by < y + 60)
                            {

                                TakeDamage();
                                by=500;
                                

                            }
                        }
                        temp++;

                    }

                }

                else if (attack==8) {
                    Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bossmini.png");
                    Enemy1.Size = new System.Drawing.Size(189, 70);
                    while (e1x >0)
                    {
                        e1x--;

                        System.Threading.Thread.Sleep(1);
                        e1y = e1y + 100;
                        Enemy1.Location = new System.Drawing.Point(e1x, e1y);
                        if (e1x > x - 60 && e1x < x + 60 && e1y > y - 60 && e1y < y + 60)
                        {

                            TakeDamage();

                        }
                    }

                    e1y = e1y - 100;
                    while (e1x < 673)
                    {
                        e1x = e1x + 5;
                        System.Threading.Thread.Sleep(1);
                        Enemy1.Location = new System.Drawing.Point(e1x, e1y);
                        if (e1x > x - 60 && e1x < x + 60 && e1y > y - 60 && e1y < y + 60)
                        {
                            TakeDamage();
                        }
                    }

                    Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\BossStand3-Attack.png");
                    Enemy1.Location = new System.Drawing.Point(e1x, e1y);
                    Enemy1.Size = new System.Drawing.Size(xs, ys);
                }
            }
            if (e1dead == 1)
            {
                Enemy1.Visible = false;
                this.Controls.Remove(Enemy1);

            }
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

            textwrite.WriteEndElement();

            textwrite.WriteEndElement();
            textwrite.Flush();
            //close writer
            textwrite.Close();

            MessageBox.Show("Save Sucessful");
        }
        private async void TakeDamage()
        {
            if (count4 == 0)
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
        }

      
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

                    PictureBox pl2 = new PictureBox();
                  
                    pl2.Location = new System.Drawing.Point(360, 140);
                    pl2.Size = new Size(274, 304);
                    pl2.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Game-Over.png");

                   
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

        public void TriesChange()
        {
            label1.Text = tries.ToString();
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
                while (xf < 1500)
                {
                    xf++;
                    pb.Location = new System.Drawing.Point(xf, yf);
                    if (xf > e1x - 120 && xf < e1x + 120 && yf > e1y - 200 && yf < e1y + 200)
                    {
                        
                        e1life--;
                        xf = 1000;
                        if (e1life == 0)
                        {
                            e1dead = 1;
                        }

                    }

                }

            }
            else if (count == 0)
            {
                while (xf > 0)
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
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            pause = 6;
        }


        public async void Fall()
        {


            if (count3 == 0)
            {
                while (y < 387)
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
            }
        }

        DataTable tb = new DataTable("Names");
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (pointer == -1)
            {
                tb.Columns.Add("Life", typeof(int));
                tb.Columns.Add("Energy", typeof(int));
                tb.Columns.Add("PlayerX", typeof(int));
                tb.Columns.Add("PlayerY", typeof(int));
                tb.Columns.Add("EnemyX", typeof(int));
                tb.Columns.Add("EnemyY", typeof(int));
                tb.Columns.Add("Time", typeof(int));
                tb.Columns.Add("Tries", typeof(int));
                tb.Columns.Add("EnemyDead", typeof(int));

                ds.Tables.Add(tb);
            }

            DataRow empRow;

            empRow = tb.NewRow();
            empRow[0] = Life;
            empRow[1] = energy;
            empRow[2] = x;
            empRow[3] = y;
            empRow[4] = e1x;
            empRow[5] = e1y;
            empRow[6] = time;
            empRow[7] = tries;
            empRow[8] = e1dead;
            tb.Rows.Add(empRow);


            Thread thread = new Thread(quicksave);
            thread.Start();


        }

        private async void quicksave()
        {
            label5.Text = "Quick Save Sucessful";
            pointer++;
            MessageBox.Show(pointer.ToString());
            await Task.Delay(3000);
            label5.Text = "";


        }

        private async void quickload()
        {
            label5.Text = "Quick Load Sucessful";
            await Task.Delay(3000);

            label5.Text = "";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Life = Convert.ToInt32(tb.Rows[pointer][0]);
            energy = Convert.ToInt32(tb.Rows[pointer][1]);
            x = Convert.ToInt32(tb.Rows[pointer][2]);
            y = Convert.ToInt32(tb.Rows[pointer][3]);
            e1x = Convert.ToInt32(tb.Rows[pointer][4]);
            e1y = Convert.ToInt32(tb.Rows[pointer][5]);
            time = Convert.ToInt32(tb.Rows[pointer][6]);
            tries = Convert.ToInt32(tb.Rows[pointer][7]);
            e1dead = Convert.ToInt32(tb.Rows[pointer][8]);
            this.Hide();
            Form1 f1 = new Form1(Life, energy, x, y, e1x, e1y, time, tries, e1dead, tb, pointer);
            f1.ShowDialog();
            this.Close();


        }

        private void BossStage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                PictureBox pl2 = new PictureBox();
                if (pause2 == 1)
                {
                    
                    this.Controls.Add(pl2);
                }

                if (count4 == 0 && pause == 0 && pause2 == 0)
                {

                    Thread thread = new Thread(Fall);
                    thread.Start();


                    if (e.KeyChar == 'd')
                    {
                        walk = 1;
                        if (count3 == 0)
                        {

                            megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megawalk-right.gif");
                        }

                        if (count3 == 1)
                        {
                            x = x + 5;
                        }
                        else {
                            x = x + 3;

                        }

                        megasprite.Location = new System.Drawing.Point(x, y);
                        count = 1;
                        if (x > 851 && y < 165 && e1dead == 1)
                        {
                            for (int i = 0; i < 50; i++)
                            {
                                x = x + 3;
                                System.Threading.Thread.Sleep(100);
                                megasprite.Location = new System.Drawing.Point(x, y);
                            }
                            Stage2 st = new Stage2();
                            this.Hide();
                            st.ShowDialog();
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

                        if (count3 == 1)
                        {
                            x = x - 5;


                        }
                        else {
                            x = x - 3;
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

                        Thread thread1 = new Thread(MoveUp);
                        thread1.Start();



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
                            BossStage fm = new BossStage();
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

        private void BossStage_FormClosed(object sender, FormClosedEventArgs e)
        {
            pause = 6;
        }
    }
}
