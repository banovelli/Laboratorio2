using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class Bat : Enemy
    {
        public Bat(Game game, Point location, Rectangle bounderies)
            : base (game, location, bounderies, 6)
        {}

        public override void Move(Random random)
        {
         //se esta vivo
   
            //50% de chance de mover ao jogador ou dir aleatoria

            //apos mover , se proximo ataca com ate 2 pontos de dano
        }
    }
}
