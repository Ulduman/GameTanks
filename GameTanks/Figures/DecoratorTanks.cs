using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    abstract class DecoratorTanks : FiguresAbstract
    {
        protected FiguresAbstract tank;

        public DecoratorTanks(FiguresAbstract tank, int speed, int armor, int power,int live) : base(tank.points,tank.color,tank.speed,tank.armor,tank.power,tank.live)
        {
            this.tank = tank;
        }

    }
}
