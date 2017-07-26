using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Tank : FiguresAbstract
    {


        public Tank(int x1, int y1, int x2, int y2, int x3, int y3, Color color) : base(x1, y1, x2, y2, x3, y3)
        {
            this.speed = 5;
            this.armor = 1;
            this.power = 2;
            this.live = 5;
            this.color = color;
        }

        public override void Draw(ref Graphics formCanva)
        {
            formCanva.FillPolygon(new SolidBrush(color), points);
        }

        public override void Move(String way)
        {
            double centrx = (points[0].X + points[1].X + points[2].X) / 3,
            centry = (points[0].Y + points[1].Y + points[2].Y) / 3,
            d0 = Math.Sqrt(Math.Pow(centrx - points[0].X, 2) + Math.Pow(centry - points[0].Y, 2)),
            dp = Math.Sqrt(Math.Pow(points[2].X - points[1].X, 2) + Math.Pow(points[2].Y - points[1].Y, 2))/2;

            if (way.Equals("up"))
            {
                if (points[0].Y < points[1].Y && points[0].Y<points[2].Y) {

                    points[0].Y = points[0].Y - (this.speed);
                    points[1].Y = points[1].Y - (this.speed);
                    points[2].Y = points[2].Y - (this.speed);
                }
                else
                {
                    points[0].Y = (int)Math.Round(centry - d0);
                    points[0].X = (int)Math.Round(centrx);
                    points[1].X = (int)Math.Round(centrx + dp);
                    points[2].X = (int)Math.Round(centrx - dp);
                    points[1].Y = (int)Math.Round((centry * 3 - points[0].Y) / 2);
                    points[2].Y = points[1].Y;
                }
            }else if (way.Equals("down"))
            {
                if (points[0].Y > points[1].Y && points[0].Y > points[2].Y) {
                    points[0].Y = points[0].Y + (this.speed);
                    points[1].Y = points[1].Y + (this.speed);
                    points[2].Y = points[2].Y + (this.speed);
                }
                else {
                    points[0].Y = (int)Math.Round(centry + d0);
                    points[0].X = (int)Math.Round(centrx);
                    points[1].X = (int)Math.Round(centrx - dp);
                    points[2].X = (int)Math.Round(centrx + dp);
                    points[1].Y = (int)Math.Round((centry * 3 - points[0].Y) / 2);
                    points[2].Y = points[1].Y;
                }
            }
            else if (way.Equals("right"))
            {
                if (points[0].X > points[1].X && points[0].X > points[2].X)
                {
                    points[0].X = points[0].X + (this.speed);
                    points[1].X = points[1].X + (this.speed);
                    points[2].X = points[2].X + (this.speed);
                }else
                {
                    points[0].X = (int)Math.Round(centrx + d0);
                    points[0].Y = (int)Math.Round(centry);
                    points[1].Y = (int)Math.Round(centry + dp);
                    points[2].Y = (int)Math.Round(centry - dp);
                    points[1].X = (int)Math.Round((centrx * 3 - points[0].X) / 2);
                    points[2].X = points[1].X;
                }
            }
            else if (way.Equals("left"))
            {
                if (points[0].X < points[1].X && points[0].X < points[2].X)
                {
                    points[0].X = points[0].X - (this.speed);
                    points[1].X = points[1].X - (this.speed);
                    points[2].X = points[2].X - (this.speed);
                }
                else
                {
                    points[0].X = (int)Math.Round(centrx - d0);
                    points[0].Y = (int)Math.Round(centry);
                    points[1].Y = (int)Math.Round(centry - dp);
                    points[2].Y = (int)Math.Round(centry + dp);
                    points[1].X = (int)Math.Round((centrx * 3 - points[0].X) / 2);
                    points[2].X = points[1].X;
                }
                
            }
        }

        public override bool CheckLife(int power)
        {
            if (this.armor < power)
            {
                power = power- this.armor;
                this.live = this.live - power;
            }
            if (this.live > 0)
            {
                return true;
            } else return false;
        }

    }
}
