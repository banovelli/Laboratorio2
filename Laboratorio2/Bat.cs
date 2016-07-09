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
            if (!Dead)
            {
                //50% de chance de mover ao jogador ou dir aleatoria
                int mover = random.Next(1, 2);
                Direction direcao;
                if (mover == 1)//mover em direcao ao jogador
                {
                    direcao = DirecaoJogador(location, game.PlayerLocation);
                }
                else
                {//mover direcao aleatoria
                    int dirMover = random.Next(2, 4);
                    direcao = Direction.Up;
                    switch (dirMover)
                    {
                        case 2:
                            direcao = Direction.Left;
                            break;
                        case 3:
                            direcao = Direction.Right;
                            break;
                        case 4:
                            direcao = Direction.Down;
                            break;
                    }
                }
                base.location =  Move(direcao, game.Bounderies);

                if (Nearby(base.location, game.PlayerLocation, 1))
                {
                    game.HitPlayer(2, random);
                }

                //apos mover , se proximo ataca com ate 2 pontos de dano

            }
        }
    }
}
