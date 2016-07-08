using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class Player: Mover
    {
        private Weapon equippedWeapon;
        private int hitPoints;
        public int HitPoints { get { return hitPoints; } }
        private List<Weapon> inventory = new List<Weapon>();
        public List<string> Weapons {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }

        public Player(Game game, Point location, Rectangle bounderies)
            : base(game,location)
        {
            hitPoints = 10;
        }

        public void Hit(int maxDamage, Random random)
        {
            hitPoints -= random.Next(1, maxDamage);
        }

        public void Increasehealth(int health, Random random)
        {
            hitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Bounderies);
            if (!game.WeaponInRoom.PickedUp)
            {
                //verifica se tem uma weapon por perto e se possivel pega ela
                //se waepon no raio de 1 pode ser pega

                //se o jogador nao tiver nehuma arma, ja prepara ela para ser usada na proxima rodada
            }
        }

        public void Attack(Direction direction, Random random)
        {
            //verifica qual arma esta euipada e chama o atack daquela arma
            //se nao tiver arma preparada nao faz nada

            //se for uma pocao selecionada ela deve ser removida do inventario
        }
    }
}
