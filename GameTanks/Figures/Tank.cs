using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Tank : FiguresAbstract
    {


        public Tank(int x1, int y1, int x2, int y2, int x3, int y3, Color color) : base(x1, y1, x2, y2, x3, y3)
        {
            this.speed = 1;
            this.armor = 1;
            this.power = 2;
            this.live = 5;
            this.color = color;
        }

        public override void Draw(ref Graphics formCanva)
        {
            formCanva.FillPolygon(new SolidBrush(color), points);
        }

        public override void Move(String way, int speed)
        {
            if (way.Equals("up"))
            {
                points[0].Y = points[0].Y - (speed);
                points[1].Y = points[1].Y - (speed);
                points[2].Y = points[2].Y - (speed);

            }else if (way.Equals("down"))
            {
                points[0].Y = points[0].Y + (speed);
                points[1].Y = points[1].Y + (speed);
                points[2].Y = points[2].Y + (speed);
            }
            else if (way.Equals("right"))
            {
                points[0].X = points[0].X + (speed);
                points[1].X = points[1].X + (speed);
                points[2].X = points[2].X + (speed);
            }else if (way.Equals("left"))
            {
                points[0].X = points[0].X - (speed);
                points[1].X = points[1].X - (speed);
                points[2].X = points[2].X - (speed);
            }
        }

        public override bool CheckLife(int power, int armor)
        {
            if (armor < power)
            {
                power = power-armor;
                this.live = this.live - power;
            }
            if (this.live > 0)
            {
                return true;
            } else return false;
        }
    }
}
