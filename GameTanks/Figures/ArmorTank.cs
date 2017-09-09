using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class ArmorTank : DecoratorTanks
    {
        public ArmorTank(FiguresAbstract tank) : base(tank,tank.Speed,tank.Armor,tank.Power,tank.Live)
        {
            this.Armor = tank.Armor + 1;
        }

        public override bool CheckLife(int power)
        {
            tank.Armor = this.Armor;

            bool x = tank.CheckLife(power);

            this.Live = tank.Live;
            return x;

        }

        public override void Draw(ref Graphics formCanva)
        {
            tank.Draw(ref formCanva);
        }

        public override void Move(string way)
        {
            tank.Speed = this.Speed;
            tank.Move(way);
            this.Points = tank.Points;
        }
    }
}
