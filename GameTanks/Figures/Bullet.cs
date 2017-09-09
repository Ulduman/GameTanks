using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Figures
{
    public class Bullet
    {
        private Point point;
        private Size size = new Size(4, 4);
        private int[] track;
        int power;


        public Bullet(FiguresAbstract tank)
        {
            this.power = tank.Power;
            this.point = tank.Points[0];
            if(tank.Points[0].Y < tank.Points[1].Y && tank.Points[0].Y < tank.Points[2].Y)
            {
                track =new int[] { 0, -1};
            }else if (tank.Points[0].Y > tank.Points[1].Y && tank.Points[0].Y > tank.Points[2].Y)
            {
                track = new int[] { 0, 1 };
            }
            else if (tank.Points[0].X > tank.Points[1].X && tank.Points[0].X > tank.Points[2].X)
            {
                track = new int[] {1, 0 };
            }
            else if (tank.Points[0].X < tank.Points[1].X && tank.Points[0].X < tank.Points[2].X)
            {
                track = new int[] { -1, 0 };
            }
        }
        public void Shoot()
        {
            this.point.X = point.X + track[0]*5;
            this.point.Y = point.Y + track[1]*5;
        }

        public void Draw(ref Graphics formCanva)
        {
            Point point = new Point(this.point.X - 2, this.point.Y - 2);
            formCanva.FillEllipse(Brushes.Black, new Rectangle(point,size));
        }

         public bool CheckLive(int x, int y, FiguresAbstract tank1)
         {
            double a1 = (this.point.X - tank1.Points[0].X) * (tank1.Points[1].Y - tank1.Points[0].Y) - (tank1.Points[1].X - tank1.Points[0].X) * (point.Y - tank1.Points[0].Y),
            b1 = (this.point.X - tank1.Points[1].X) * (tank1.Points[2].Y - tank1.Points[1].Y) - (tank1.Points[2].X - tank1.Points[1].X) * (point.Y - tank1.Points[1].Y),
            c1 = (this.point.X - tank1.Points[2].X) * (tank1.Points[0].Y - tank1.Points[2].Y) - (tank1.Points[0].X - tank1.Points[2].X) * (point.Y - tank1.Points[2].Y);

            if ((a1 == 0 && point.Y>tank1.Points[1].Y && point.Y<tank1.Points[0].Y && point.X>tank1.Points[0].X && point.X<tank1.Points[1].X) || 
                (c1 == 0 && point.Y > tank1.Points[0].Y && point.Y < tank1.Points[2].Y && point.X > tank1.Points[2].X && point.X < tank1.Points[0].X) || 
                (b1 == 0 && point.Y > tank1.Points[2].Y && point.Y < tank1.Points[1].Y && point.X > tank1.Points[1].X && point.X < tank1.Points[2].X) || 
                (a1 > 0 && c1 > 0 && b1 > 0) || (a1 < 0 && c1 < 0 && b1 < 0))
            {
                tank1.CheckLife(power);
                return false;
            }else if (this.point.X > x || this.point.X < 0 || this.point.Y > y || this.point.Y < 0)
                {
                    return false;
                }
                else return true;

         }


    }
}
