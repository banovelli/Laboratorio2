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

        public override string Name { get { return "BluePotion"; } }

        public override void Attack(Direction direction, Random random)
        {
            if (!used)
                game.IncreasePlayerHealth(5);
           // aumenta saude em 5
            // marca ele como usada
            used = true;
        }
        private bool used = false;
        public bool Used { get { return used; } }
    }
}
