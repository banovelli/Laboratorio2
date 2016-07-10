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
            if (!Dead)
            {
                int mover = random.Next(1, 4);
                Direction direcao;
                if (mover < 3)//mover em direcao ao jogador
                {
                    direcao = DirecaoJogador(location, game.PlayerLocation);
                    base.location = Move(direcao, game.Bounderies);
                    if (Nearby(base.location, game.PlayerLocation, 16))
                    {
                        game.HitPlayer(4, random);
                    }
                }
                //else fica parado
            }
        }
    }
}
