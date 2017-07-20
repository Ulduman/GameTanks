using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace Figures
{
    public abstract class FiguresAbstract
    {
        public Point[] points { get; set; }
        public int speed { get; set; }
        public int armor { get; set; }
        public int power { get; set; }
        public int live { get; set; }
        public Color color { get; set; }


        public abstract void Draw(ref Graphics formCanva);
        public abstract void Move(String way, int speed);
        public abstract bool CheckLife(int power, int armor);
        public FiguresAbstract(int x1,int y1, int x2, int y2, int x3, int y3)
        {
            this.points =new Point[] { new Point(x1,y1), new Point(x2,y2), new Point(x3, y3)};

        }

        public FiguresAbstract(Point[] points, Color color, int speed, int armor, int power,int live)
        {
            this.live = live;
            this.color = color;
            this.points = points;
            this.speed = speed;
            this.armor = armor;
            this.power = power;
        }
    }
}
