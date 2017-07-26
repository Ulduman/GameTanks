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
            this.power = tank.power;
            this.point = tank.points[0];
            if(tank.points[0].Y < tank.points[1].Y && tank.points[0].Y < tank.points[2].Y)
            {
                track =new int[] { 0, -1};
            }else if (tank.points[0].Y > tank.points[1].Y && tank.points[0].Y > tank.points[2].Y)
            {
                track = new int[] { 0, 1 };
            }
            else if (tank.points[0].X > tank.points[1].X && tank.points[0].X > tank.points[2].X)
            {
                track = new int[] {1, 0 };
            }
            else if (tank.points[0].X < tank.points[1].X && tank.points[0].X < tank.points[2].X)
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

       /* public bool CheckLive(int x, int y, FiguresAbstract tank1, FiguresAbstract tank2)
        {

            if (this.point.X > x || this.point.X < 0 || this.point.Y > y || this.point.Y < 0 || )
            {
                return false;
            } else return true;
        }*/


    }
}
