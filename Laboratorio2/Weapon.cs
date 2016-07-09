using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public abstract class Weapon: Mover
    {
        
        private bool pickedup;
        public bool PickedUp{get{return pickedup;}}

        public Weapon(Game game, Point location)
            : base(game, location)
        {
            pickedup = false;
        }

        public void PickUpWeapon() { pickedup = true; }
        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                   if (Nearby(enemy.Location, target, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, game.Bounderies);//Move(direction, target, game.Bounderies);
            }
            return false;
        }

    }
}
