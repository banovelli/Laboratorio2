using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class Sword: Weapon
    {
        public Sword(Game game, Point location)
            : base(game, location){}

        public override string Name { get { return "Sword";} }
        public override void Attack(Direction direction, Random random)
        {
            int radius = 30;

            switch (direction)
            {
                case Direction.Up:
                    if(!DamageEnemy(Direction.Up, 30, 3, random))
                        if(!DamageEnemy(Direction.Left, 30, 3, random))
                            DamageEnemy(Direction.Right, 30, 3, random);
                    break;
                case Direction.Left:
                     if(!DamageEnemy(Direction.Up, 30, 3, random))
                    if(! DamageEnemy(Direction.Left, 30, 3, random))
                    DamageEnemy(Direction.Down, 30, 3, random);
                    break;
                case Direction.Right:
                     if(!DamageEnemy(Direction.Up, 30, 3, random))
                     if(!DamageEnemy(Direction.Right, 30, 3, random))
                    DamageEnemy(Direction.Down, 30, 3, random);
                    break;
                case Direction.Down:
                     if(!DamageEnemy(Direction.Down, 30, 3, random))
                     if(!DamageEnemy(Direction.Left, 30, 3, random))
                    DamageEnemy(Direction.Right, 30, 3, random);
                    break;
            }

            //to do
            //raio 30
            // 3 de dano
            //primeiro ataque 'frontal'
            // se nao ataqueque sentido horario
            // se nao ataque sentido anti horario
        }
    }
}
