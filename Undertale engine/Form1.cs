using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unauticna;
using System.IO;

namespace Undertale_engine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Image tex7 = Resource1.Sans;
        private void Form1_Load(object sender, EventArgs e)
        {
            unscript un = new unscript();
            if (File.Exists("main.uns"))
            {


                un.ins = "main.uns";
                un.Start();
                List<Image> n = new List<Image>();
                int i = 0;
                if (un.outsv.Count != 0)
                {
                    enemyhp = (decimal)un.outsv[0].x;
                    while ((int)un.outsv[0].y > i)
                    {


                        if (un.link.Count != 0)
                        {

                            string path;
                            path = un.link[i + 1];
                            n.Add(Bitmap.FromFile(path));
                            pictureBox1.BackgroundImage = tex7;
                            i++;
                        }
                    }
                }
                if (un.outsd.Count != 0)
                {


                    enemyhp = (decimal)un.outsd[0].x;
                    while ((int)un.outsd[0].y > i)
                    {


                        if (un.link.Count != 0)
                        {

                            string path;
                            path = un.link[i+1];
                            
                            n.Add(Bitmap.FromFile(path));
                            pictureBox1.BackgroundImage = tex7;
                            i++;
                        }
                    }
                }
                textr = n.ToArray();
                if (un.outs2.Count != 0)
                {
                    enemyname = un.outs2[0];
                }
                if (un.link.Count != 0)
                {

                    string path = un.link[0];
                    tex7 = Bitmap.FromFile(path);
                }
                
            }
            pictureBox1.BackgroundImage = tex7;
            
        }

            //////////////////////////////////////////////////// 

            decimal enemyhp = 78964m;
        string enemyname = "not_in_au_sans";


        Image[] textr = new Image[] { Resource1.Sans_порожение_1, Resource1.Sans_порожение__1 };
        short animatic;
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = "hp:" + enemyhp.ToString();
            label2.Text = enemyname;
            if (enemyhp <= 0)
            {
                label1.Text = "dead";


                pictureBox1.BackgroundImage = textr[animatic];
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            animatic += 1;
            if (textr.Length - 1 < animatic)
            {
                animatic = 0;
            }
        }

        //////////////////////////////////////////////////// 



        //////////////////////////////////////////////////// 
        //КНОПКА ТЕСТ 1
        Bitmap tex1 = Resource1.fight;
        Bitmap tex2 = Resource1.fight_click;
        Bitmap tex3 = Resource1.fight_unclick;
        Bitmap tex4 = Resource1.fight_enter;

        bool onconected;

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = tex4;
            onconected = false;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = tex2;
            onconected = true;
            if (enemyhp >=0)
            {


                enemyhp -= 123m;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = tex3;
            onconected = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (onconected)
            {


                button1.BackgroundImage = tex1;
                onconected = false;

            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = tex3;
            onconected = true;
            
        }

        


        //////////////////////////////////////////////////// 



    }
}
