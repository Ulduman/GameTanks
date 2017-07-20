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

        public override bool CheckLife(int power)
        {
            tank.armor = this.armor;

            bool x=tank.CheckLife(power);

            this.live = tank.live;
            return x;

        }

        public override void Draw(ref Graphics formCanva)
        {
            tank.Draw(ref formCanva);
        }

        public override void Move(string way)
        {
            tank.speed = this.speed;
            tank.Move(way);
            this.points = tank.points;
        }
    }
}
