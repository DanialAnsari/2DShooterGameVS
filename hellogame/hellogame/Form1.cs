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
using System.Windows.Input;
using System.Xml;

namespace hellogame
{
    public partial class Form1 : Form
    {
     
        int x = 12;
        int y = 387;
        int Life = 100;
        int energy = 10;
        int tries = 3;
        int time = 62;
        int stage = 1;
        int e1x = 741;
        int e1y = 390;
        int count = 1;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int e1life = 3;
        int pause=0;
        int pause2 = 0;
        int e1dead = 0;
        int pointer = -1;
        int walk = 0;
       int delay=0;
        public Form1()
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public Form1(int tr)
        {
            try
            {
                InitializeComponent();

                tries = tr;
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

       

        public bool OnPlatform() {
            if ((y >= 280 && y <= 285 && x >= 290 && x <= 450) || (y >= 175 && y <= 180 && x >= 455 && x <= 635) || (y >= 110 && y <= 115 && x >= 660))
            {
                return true;
            }
            else {
                return false;
            }
        }
        public void SetEnemyLocation() {
            Enemy1.Location = new System.Drawing.Point(e1x, e1y);
        }
        public Form1(int lifeu,int energyu,int xu,int yu,int e1xu,int e1yu,int timeu,int triesu ) {
            try { 
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

        public Form1(int lifeu, int energyu, int xu, int yu, int e1xu, int e1yu, int timeu, int triesu,int dead,DataTable dt,int pointeru)
        {
            try
            {
                InitializeComponent();
                tb = dt;
                Life = lifeu;
                energy = energyu;
                x = xu;
                y = yu;
                e1x = e1xu;
                e1y = e1yu;
                time = timeu;
                tries = triesu;
                pointer = pointeru;
                e1dead = dead;
              LifeChange();
                EnergyChange();

                megasprite.Location = new System.Drawing.Point(x, y);
                if (dead == 0)
                {
                    SetEnemyLocation();
                }
                else {
                    this.Controls.Remove(Enemy1);
                }
                Thread thread = new Thread(myLoop);
                thread.Start();

                Thread thread2 = new Thread(Timer);
                thread2.Start();

                Thread thread3 = new Thread(quickload);
                thread3.Start();

                TriesChange();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        PictureBox pb = new PictureBox();

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }


        public bool WallCheck1(char a,int x,int y) {
            if (a == 'd')
            {

                if (y <= 270)
                {
                    return true;
                }
                else if (x >= 277 && x <= 282)
                {
                    return false;
                }


                else {
                    return true;
                }
            }
            else 
            {
                
                if (y<= 270)
                {
                   
                    return true;
                }

                else if (x >=455  && x <= 460)
                {
                   
                    return false;
                }


                else {
                 
                    return true;
                }

            }

        }


        public void Delay() {
            delay = 1;
            System.Threading.Thread.Sleep(400);
            if (walk == 0) {
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
        private async void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {

                if (pause2== 1) {
                    this.Controls.Add(pl2);
                }
                
            if (count4 == 0 && pause == 0 && pause2==0)
            {
                    if ((x <= 400 || x > 580) && count3 == 0)
                    {

                        Thread thread = new Thread(Fall);
                        thread.Start();
                    }
                    else if (x < 230 || x > 310 && count3==0) {
                        Thread thread = new Thread(Fall);
                        thread.Start();

                    }

                    if (e.KeyChar == 'd')
                    {
                        walk = 1;
                        if (count3 == 0)
                        {
                           
                          
                        }
                        if (WallCheck1('d', x, y))
                        {
                            if (count3 == 1)
                            {
                                x = x + 5;
                            }
                            else {
                                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megawalk-right.gif");
                                x = x + 3;
                                
                            }
                        }
                        megasprite.Location = new System.Drawing.Point(x, y);
                        count = 1;
                        if (x > 851 && y<165 && e1dead==1) {
                            for (int i = 0; i < 50; i++) {
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
                            
                        }
                        if (WallCheck1('a', x, y) == true)
                        {
                            if (count3 == 1)
                            {
                                x = x - 5;


                            }
                            else {
                                megasprite.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\megawalk.gif");
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

                    else if (pause2 == 1 && e.KeyChar == 's'){

                        pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Game Over-2.png");
                        pause++;
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

                    else if (pause2 == 2 && e.KeyChar == 'w') {
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
        

        private void Form1_Click(object sender, EventArgs e)
        {
            
            
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
            while (pause != 6 && e1dead==0)
            {
                if (pause == 0)
                {
                    if (count2 == 0)
                    {
                        e1x--;
                        System.Threading.Thread.Sleep(10);
                    }
                    else if (count2 == 1)
                    {
                        e1x++;
                        System.Threading.Thread.Sleep(10);
                    }

                    if (e1x < 470)
                    {
                        Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Enemy - Right.gif");
                        count2 = 1;
                    }
                    if (e1x > 740)
                    {
                        Enemy1.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Enemy.gif");
                        count2 = 0;
                    }

                    if (x > e1x - 70 && x < e1x + 70 && y > e1y - 60 && y < e1y + 60)
                    {
                        if (count4 == 0)
                        {
                            Thread thread = new Thread(TakeDamage);
                            thread.Start();
                        }
                    }
                    SetEnemyLocation();

                }
            }
            if (e1dead == 1) {
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

        PictureBox pl2 = new PictureBox();
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

            else if (Life == 0) {
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
                catch (Exception ex) {
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

        public void TriesChange() {
            label1.Text = tries.ToString();
        }

        private void BulletTravel() {
            int xf = 0;
            int yf = 0;
            pb.Size = new Size(42, 33);
            pb.Image = Image.FromFile("C:\\Users\\dania\\Pictures\\Bullet.png");
            if (count == 1)
            {
                 xf = x + 60;
                 yf = y + 10;
            }
            else if (count == 0) {
                 xf = x - 60;
                 yf = y- 10;
            }
            pb.Location = new System.Drawing.Point(xf, yf);
            if (count == 1)
            {
                while (xf < 1000 && WallCheck1('d',xf,yf)==true)
                {
                    xf++;
                    pb.Location = new System.Drawing.Point(xf, yf);
                    if (xf > e1x - 60 && xf < e1x + 60 && yf > e1y - 60 && yf < e1y + 60)
                    {

                        e1life--;
                        xf = xf + 500;
                        yf = yf - 500;
                        if (e1life == 0) {
                            e1dead = 1;
                        }
                     
                    }
                   
                }
                
            }
            else if (count == 0) {
                while (xf >0 && WallCheck1('a', xf, yf) == true)
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
            energy= Convert.ToInt32(tb.Rows[pointer][1]);
            x = Convert.ToInt32(tb.Rows[pointer][2]);
            y = Convert.ToInt32(tb.Rows[pointer][3]);
             e1x= Convert.ToInt32(tb.Rows[pointer][4]);
            e1y = Convert.ToInt32(tb.Rows[pointer][5]);
            time = Convert.ToInt32(tb.Rows[pointer][6]);
            tries = Convert.ToInt32(tb.Rows[pointer][7]);
            e1dead= Convert.ToInt32(tb.Rows[pointer][8]);
            this.Hide();
            Form1 f1 = new Form1(Life, energy, x, y, e1x, e1y, time, tries,e1dead,tb,pointer);
            f1.ShowDialog();
            this.Close();


        }
    }

    
}
