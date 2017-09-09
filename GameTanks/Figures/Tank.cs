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
            this.Speed = 5;
            this.Armor = 1;
            this.Power = 2;
            this.Live = 5;
            this.Color = color;
        }


        public override void Draw(ref Graphics formCanva)
        {
            formCanva.FillPolygon(new SolidBrush(Color), Points);
        }

        public override void Move(String way)
        {
            double centrx = (Points[0].X + Points[1].X + Points[2].X) / 3,
            centry = (Points[0].Y + Points[1].Y + Points[2].Y) / 3,
            d0 = Math.Sqrt(Math.Pow(centrx - Points[0].X, 2) + Math.Pow(centry - Points[0].Y, 2)),
            dp = Math.Sqrt(Math.Pow(Points[2].X - Points[1].X, 2) + Math.Pow(Points[2].Y - Points[1].Y, 2))/2;

            if (way.Equals("up"))
            {
                if (Points[0].Y < Points[1].Y && Points[0].Y<Points[2].Y) {

                    Points[0].Y = Points[0].Y - (this.Speed);
                    Points[1].Y = Points[1].Y - (this.Speed);
                    Points[2].Y = Points[2].Y - (this.Speed);
                }
                else
                {
                    Points[0].Y = (int)Math.Round(centry - d0);
                    Points[0].X = (int)Math.Round(centrx);
                    Points[1].X = (int)Math.Round(centrx + dp);
                    Points[2].X = (int)Math.Round(centrx - dp);
                    Points[1].Y = (int)Math.Round((centry * 3 - Points[0].Y) / 2);
                    Points[2].Y = Points[1].Y;
                }
            }else if (way.Equals("down"))
            {
                if (Points[0].Y > Points[1].Y && Points[0].Y > Points[2].Y) {
                    Points[0].Y = Points[0].Y + (this.Speed);
                    Points[1].Y = Points[1].Y + (this.Speed);
                    Points[2].Y = Points[2].Y + (this.Speed);
                }
                else {
                    Points[0].Y = (int)Math.Round(centry + d0);
                    Points[0].X = (int)Math.Round(centrx);
                    Points[1].X = (int)Math.Round(centrx - dp);
                    Points[2].X = (int)Math.Round(centrx + dp);
                    Points[1].Y = (int)Math.Round((centry * 3 - Points[0].Y) / 2);
                    Points[2].Y = Points[1].Y;
                }
            }
            else if (way.Equals("right"))
            {
                if (Points[0].X > Points[1].X && Points[0].X > Points[2].X)
                {
                    Points[0].X = Points[0].X + (this.Speed);
                    Points[1].X = Points[1].X + (this.Speed);
                    Points[2].X = Points[2].X + (this.Speed);
                }else
                {
                    Points[0].X = (int)Math.Round(centrx + d0);
                    Points[0].Y = (int)Math.Round(centry);
                    Points[1].Y = (int)Math.Round(centry + dp);
                    Points[2].Y = (int)Math.Round(centry - dp);
                    Points[1].X = (int)Math.Round((centrx * 3 - Points[0].X) / 2);
                    Points[2].X = Points[1].X;
                }
            }
            else if (way.Equals("left"))
            {
                if (Points[0].X < Points[1].X && Points[0].X < Points[2].X)
                {
                    Points[0].X = Points[0].X - (this.Speed);
                    Points[1].X = Points[1].X - (this.Speed);
                    Points[2].X = Points[2].X - (this.Speed);
                }
                else
                {
                    Points[0].X = (int)Math.Round(centrx - d0);
                    Points[0].Y = (int)Math.Round(centry);
                    Points[1].Y = (int)Math.Round(centry - dp);
                    Points[2].Y = (int)Math.Round(centry + dp);
                    Points[1].X = (int)Math.Round((centrx * 3 - Points[0].X) / 2);
                    Points[2].X = Points[1].X;
                }
                
            }
        }

        public override bool CheckLife(int power)
        {
            if (this.Armor < power)
            {
                power = power- this.Armor;
                this.Live = this.Live - power;
            }
            if (this.Live > 0)
            {
                return true;
            } else return false;
        }

    }
}
