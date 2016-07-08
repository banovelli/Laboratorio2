using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{

    public class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location, Rectangle bounderies)
            : base(game, location, bounderies, 10)
        { }

        public override void Move(Random random)
        {
            //se esta vivo

            //2 em 3 de chance de mover ao jogador ou 1 em 3 q ele fique parado

            //apos mover , se proximo ataca com ate 4 pontos de dano
        }
    }
}
