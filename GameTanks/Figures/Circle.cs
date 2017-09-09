using System;
using System.Windows.Shapes;
using System.Drawing;

namespace Figures
{
    public class Circle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public int ttl { get; set; }

        public Shape fgr;
        public Color c;

        public Circle(int x, int y, Shape fgr, Color c)
        {
            this.x = x;
            this.y = y;
            this.width = 10;
            this.height = 10;
            this.ttl = new Random().Next(40, 200);
            this.fgr = fgr;
            this.c = c;
        }

        public bool CheckLive()
        {
            ttl--;
            if (ttl <= 0) return false;
            else return true;
        }

        public virtual int GetPoints()
        {
            return (int)Math.Round((double)(width * height / 10));
        }

        public bool CheckPoint(Point point)
        {
            int x0, y0;

            x0 = this.x + width / 2;
            y0 = this.y + height / 2;

            if ((Math.Pow(point.X - x0, 2) + Math.Pow(point.Y - y0, 2)) <= Math.Pow(width / 2, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
