using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class RedPotion : Weapon, IPotion
    {
        public RedPotion(Game game, Point location)
        : base(game,location){ }

        public override string Name { get { return "RedPotion"; } }

        public override void Attack(Direction direction, Random random)
        {
            // aumenta saude em 10
            game.IncreasePlayerHealth(10);
            // marca ele como usada
            used = true;
        }
        private bool used = false;
        public bool Used { get { return used; } }
    }
}
