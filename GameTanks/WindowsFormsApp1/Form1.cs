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
            }else if (e.KeyChar == 's')
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
            }else if (e.KeyChar == 'i')
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

            formCanva.Clear(this.BackColor);
            tank1.Draw(ref formCanva);
            tank2.Draw(ref formCanva);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tank1 = new Tank(20, this.Height / 2, 10, this.Height / 2+10, 10, this.Height / 2-10, Color.Blue);
            tank2 = new Tank(this.Width-40, this.Height / 2, this.Width - 30, this.Height / 2-10, this.Width - 30, this.Height / 2+10, Color.Red);
            tank1.Draw(ref formCanva);
            tank2.Draw(ref formCanva);
        }
    }
}
