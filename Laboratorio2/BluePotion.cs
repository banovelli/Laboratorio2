using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class BluePotion : Weapon, IPotion
    {
        public BluePotion(Game game, Point location)
            : base(game, location) { }

        public string Name { get { return "Blue potion"; } }

        public override void Attack(Direction direction, Random random)
        {
           // aumenta saude em 5
            // marca ele como usada
        }
    }
}
