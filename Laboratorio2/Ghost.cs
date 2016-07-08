using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class Ghost : Enemy
    {
        public Ghost(Game game, Point location, Rectangle bounderies)
            : base(game, location, bounderies, 8)
        { }

        public override void Move(Random random)
        {
            //se esta vivo

            //1 em 3 de chance de mover ao jogador ou 2 em 3 q ele fique parado

            //apos mover , se proximo ataca com ate 3 pontos de dano
        }
    }
}
