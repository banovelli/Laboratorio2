using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class Mace : Weapon
    {
        public Mace(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Mace"; } }
        public override void Attack(Direction direction, Random random)
        {
            int damage = 6;
            int radius = 60;
            switch (direction)
            {
                case Direction.Up:
                    if (!DamageEnemy(Direction.Up, radius, damage, random))
                        if (!DamageEnemy(Direction.Left, radius, damage, random))
                            if (!DamageEnemy(Direction.Down, radius, damage, random))
                                 DamageEnemy(Direction.Right, radius, damage, random);
                    break;
                case Direction.Left:                    
                        if (!DamageEnemy(Direction.Left, radius, damage, random))
                            if (!DamageEnemy(Direction.Down, radius, damage, random))
                                if (!DamageEnemy(Direction.Right, radius, damage, random))
                                     DamageEnemy(Direction.Up, radius, damage, random);
                    break;
                case Direction.Right:
                    if (!DamageEnemy(Direction.Right, radius, damage, random))
                        if (!DamageEnemy(Direction.Up, radius, damage, random))
                            if (!DamageEnemy(Direction.Left, radius, damage, random))
                                 DamageEnemy(Direction.Down, radius, damage, random);
                    break;
                case Direction.Down:
                    if (!DamageEnemy(Direction.Down, radius, damage, random))
                        if (!DamageEnemy(Direction.Right, radius, damage, random))
                            if (!DamageEnemy(Direction.Up, radius, damage, random))
                                 DamageEnemy(Direction.Left, radius, damage, random);                            
                    break;
            }
            //to do
            //raio 20
            // 6 de dano
            //aqte nas 4 direcoes, circular!!
        }
    }
}
