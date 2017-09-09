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
        public Point[] Points { get; set; }
        public int Speed { get; set; }
        public int Armor { get; set; }
        public int Power { get; set; }
        public int Live { get; set; }
        public Color Color { get; set; }


        public abstract void Draw(ref Graphics formCanva);
        public abstract void Move(String way);
        public abstract bool CheckLife(int power);
        public FiguresAbstract(int x1,int y1, int x2, int y2, int x3, int y3)
        {
            this.Points =new Point[] { new Point(x1,y1), new Point(x2,y2), new Point(x3, y3)};

        }

        public FiguresAbstract(Point[] points, Color color, int speed, int armor, int power,int live)
        {
            this.Live = live;
            this.Color = color;
            this.Points = points;
            this.Speed = speed;
            this.Armor = armor;
            this.Power = power;
        }


    }
}
