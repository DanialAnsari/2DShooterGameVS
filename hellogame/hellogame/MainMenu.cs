using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace hellogame
{
    public partial class MainMenu : Form
    {

        int cursor = 1;
        int cx = 158;
        int cy = 216;
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void MainMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's' && cursor < 3)
            {
                cursor++;
                cy = cy + 40;
                pictureBox2.Location = new System.Drawing.Point(cx, cy);
            }

            else if (e.KeyChar == (char)Keys.Enter && cursor == 2)
            {
                Form1 fm = new Form1();
                this.Hide();
                fm.ShowDialog();
                this.Close();
            }
            else if (e.KeyChar == 'w' && cursor > 1)
            {
                cursor--;
                cy = cy - 40;
                pictureBox2.Location = new System.Drawing.Point(cx, cy);
            }

            else if (cursor == 1 && e.KeyChar == (char)Keys.Enter)
            {
                int count = 0;
                string temp = "";
                int life = 0;
                int energy = 0;
                int time = 0;
                int tries = 0;
                int stage = 0;
                int e1dead = 0;
                int x = 0;
                int y = 0;
                int ex = 0;
                int ey = 0;
                try
                {


                    string Filename = "C:\\Users\\dania\\Desktop\\GameSave.xml";

                    XmlTextReader RD = new XmlTextReader(Filename);

                    while (RD.Read())
                    {
                        if (RD.NodeType == XmlNodeType.Element)
                        {

                            

                            if (RD.LocalName.Equals("Life"))
                            {

                                temp = RD.ReadString();
                                life = Convert.ToInt32(temp);
                                count++;
                              
                            }

                            if (RD.LocalName.Equals("Energy"))
                            {
                                temp = RD.ReadString();
                                energy = Convert.ToInt32(temp);
                                count++;
                                
                            }

                            if (RD.LocalName.Equals("Time"))
                            {
                                temp = RD.ReadString();
                                time = Convert.ToInt32(temp);
                                count++;
                               
                            }

                            if (RD.LocalName.Equals("Tries"))
                            {
                                temp = RD.ReadString();
                                tries = Convert.ToInt32(temp);
                                count++;
                                
                            }

                            if (RD.LocalName.Equals("PlayerLocationX"))
                            {
                                temp = RD.ReadString();
                                x = Convert.ToInt32(temp);
                                count++;
                          
                            }
                            if (RD.LocalName.Equals("PlayerLocationY"))
                            {
                                temp = RD.ReadString();
                                y = Convert.ToInt32(temp);
                                count++;
                                
                            }
                            if (RD.LocalName.Equals("EnemnyLocationX"))
                            {
                                temp = RD.ReadString();
                                ex = Convert.ToInt32(temp);
                                count++;
                                
                            }
                            if (RD.LocalName.Equals("EnemnyLocationY"))
                            {
                                temp = RD.ReadString();
                                ey = Convert.ToInt32(temp);
                                count++;
                                
                            }

                            if (RD.LocalName.Equals("Stage")) {

                                temp = RD.ReadString();
                                stage = Convert.ToInt32(temp);
                                count++;
                                
                            }

                            if (RD.LocalName.Equals("EnemnyDead"))
                            {

                                temp = RD.ReadString();
                                e1dead = Convert.ToInt32(temp);
                                count++;

                            }

                        }
                    }
                }
                catch (Exception ep)
                {

                    MessageBox.Show(ep.Message);
                }
                Console.ReadLine();
                if (count == 10)
                {
                    MessageBox.Show("Load Sucessful");
                }
                else {
                    MessageBox.Show("not Sucessful");
                }
                if (stage == 1)
                {
                    Form1 f1 = new Form1(life, energy, x, y, ex, ey, time, tries);
                    this.Hide();
                    f1.ShowDialog();
                    this.Close();
                }

                else if (stage == 2)
                {
                    Stage2 f1 = new Stage2(life, energy, x, y, ex, ey, time, e1dead,tries);
                    this.Hide();
                    f1.ShowDialog();
                    this.Close();
                }

                else if (stage == 3) {
                    BossStage f1 = new BossStage();
                    this.Hide();
                    f1.ShowDialog();
                    this.Close();

                }
               
            }

            

            }
        }
    }

