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

            if (!Dead)
            {  
                int mover = random.Next(1, 4);
                Direction direcao;
                if (mover == 1)//mover em direcao ao jogador
                {
                    direcao = DirecaoJogador(location, game.PlayerLocation);
                    base.location = Move(direcao, game.Bounderies);
                    if (Nearby(base.location, game.PlayerLocation, 1))
                    {
                        game.HitPlayer(3, random);
                    }
                }
                //else fica parado
            }
        }
    }
}
