using Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        FiguresAbstract tank1, tank2;
        Graphics formCanva;
        List<Bullet> bullets;
        List<Circle> bonuses;
        public Form1()
        {
            InitializeComponent();
            formCanva = CreateGraphics();


        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                tank1.Move("up");
            }
            else if (e.KeyChar == 's')
            {
                tank1.Move("down");
            }
            else if (e.KeyChar == 'a')
            {
                tank1.Move("left");
            }
            else if (e.KeyChar == 'd')
            {
                tank1.Move("right");
            }
            else if (e.KeyChar == 'i')
            {
                tank2.Move("up");
            }
            else if (e.KeyChar == 'k')
            {
                tank2.Move("down");
            }
            else if (e.KeyChar == 'j')
            {
                tank2.Move("left");
            }
            else if (e.KeyChar == 'l')
            {
                tank2.Move("right");
            }
            else if (e.KeyChar == 'c')
            {
                bullets.Add(new Bullet(tank1));
            }
            else if (e.KeyChar == 'n')
            {
                bullets.Add(new Bullet(tank2));
            }

            TankCheker();
            formCanva.Clear(this.BackColor);
            tank1.Draw(ref formCanva);
            tank2.Draw(ref formCanva);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            formCanva.Clear(this.BackColor);
            Queue<Bullet> delBullets = new Queue<Bullet>();
            Random rnd = new Random();
            foreach (var bullet in bullets)
            {
                bullet.Shoot();

                if (!bullet.CheckLive(this.Width, this.Height, tank1) || !bullet.CheckLive(this.Width, this.Height, tank2))
                {
                    delBullets.Enqueue(bullet);
                }
                bullet.Draw(ref formCanva);
            }
            while (delBullets.Count > 0)
            {
                Bullet blt = delBullets.Dequeue();
                bullets.Remove(blt);
            }
            if (tank1.Live <= 0 || tank2.Live <= 0)
            {
                timer1.Stop();
            }

            if (rnd.Next(0, 50)==1)
            {
                bonuses.Add(new Circle(rnd.Next(20, (int)this.Width-20), rnd.Next(20, (int)this.Height-20), new System.Windows.Shapes.Ellipse(), Color.Blue));
            }if(rnd.Next(0, 50) == 2)
            {
                bonuses.Add(new Circle(rnd.Next(20, (int)this.Width - 20), rnd.Next(20, (int)this.Height - 20), new System.Windows.Shapes.Ellipse(), Color.Red));
            }
            if (rnd.Next(0, 50) == 3)
            {
                bonuses.Add(new Circle(rnd.Next(20, (int)this.Width - 20), rnd.Next(20, (int)this.Height - 20), new System.Windows.Shapes.Ellipse(), Color.Green));
            }

            RewriteCircle();
            TTL();
            label1.Text = "" + tank1.Speed + " " +tank1.Power + " " + tank1.Armor;

            tank1.Draw(ref formCanva);
            tank2.Draw(ref formCanva);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tank1 = new Tank(20, this.Height / 2, 10, this.Height / 2 + 10, 10, this.Height / 2 - 10, Color.Blue);
            tank2 = new Tank(this.Width - 40, this.Height / 2, this.Width - 30, this.Height / 2 - 10, this.Width - 30, this.Height / 2 + 10, Color.Red);
            bullets = new List<Bullet>();
            bonuses = new List<Circle>();
            tank1.Draw(ref formCanva);
            tank2.Draw(ref formCanva);
            timer1.Start();
        }

        private void RewriteCircle()
        {
            foreach (var fgr in bonuses)
            {
                formCanva.FillEllipse(new SolidBrush(fgr.c), fgr.x, fgr.y, fgr.width, fgr.height);
            }
        }

        private void TankCheker()
        {
            foreach (var fgr in bonuses)
            {
                if (fgr.CheckPoint(tank1.Points[0]))
                {
                    if(fgr.c.Equals(Color.Blue))
                    {
                        tank1 = new ArmorTank(tank1);
                        bonuses.Remove(fgr);
                        break;
                    }
                    else if(fgr.c.Equals(Color.Red))
                    {
                        tank1 = new SpeedTank(tank1);
                        bonuses.Remove(fgr);
                        break;
                    }
                    else if (fgr.c.Equals(Color.Green))
                    {
                        tank1 = new PowerTank(tank1);
                        bonuses.Remove(fgr);
                        break;
                    }
                }
                if (fgr.CheckPoint(tank2.Points[0]))
                {
                    if (fgr.c.Equals(Color.Blue))
                    {
                        tank2 = new ArmorTank(tank2);
                        bonuses.Remove(fgr);
                        break;
                    }
                    else if (fgr.c.Equals(Color.Red))
                    {
                        tank2 = new SpeedTank(tank2);
                        bonuses.Remove(fgr);
                        break;
                    }
                    else if (fgr.c.Equals(Color.Green))
                    {
                        tank2 = new PowerTank(tank2);
                        bonuses.Remove(fgr);
                        break;
                    }
                }
            }
        }

        private void TTL()
        {
            Queue<Circle> delFgr = new Queue<Circle>();

            foreach (var fgr in bonuses)
            {
                if (!fgr.CheckLive())
                {
                    delFgr.Enqueue(fgr);
                }

            }

            while (delFgr.Count > 0)
            {
                Circle fgr = delFgr.Dequeue();

                bonuses.Remove(fgr);
                formCanva.Clear(this.BackColor);
                RewriteCircle();

            }
        }
    }
}
