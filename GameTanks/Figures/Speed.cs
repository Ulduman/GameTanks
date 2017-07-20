using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class SpeedTank : DecoratorTanks
    {
        public SpeedTank(FiguresAbstract tank) : base(tank,tank.speed+1,tank.armor,tank.power,tank.live)
        {
        }

        public override bool CheckLife(int power,int armor)
        {
            bool x=tank.CheckLife(power, armor);
            this.live = tank.live;
            return x;

        }

        public override void Draw(ref Graphics formCanva)
        {
            tank.Draw(ref formCanva);
        }

        public override void Move(string way,int speed)
        {
            tank.Move(way, speed);
            this.points = tank.points;
        }
    }
}
