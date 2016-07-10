using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorio2
{
    public class Game
    {
        public List<Enemy> Enemies;
        public Weapon WeaponInRoom;
        private Player player;
        public Point PlayerLocation {get{return player.Location;}}
        public int PlayerHitPoints { get { return player.HitPoints;}}
        public List<string> PlayerWeapons { get { return player.Weapons; } }
        private int level = 0;
        public int Level { get { return level; } }
        private Rectangle bounderies;
        public Rectangle Bounderies { get { return bounderies; } }
        public string WeaponEquiped { get { return player.EquippedWeapon;}}

        public Game(Rectangle bounderies)
        {
            this.bounderies = bounderies;//caixa que envolve a masmorra
            player = new Player(this,
                new Point(bounderies.Left + 10, bounderies.Top + 70), bounderies);
        }

        public void Move(Mover.Direction direction, Random random)
        {
            player.Move(direction);
            foreach(Enemy enemy in Enemies)
                enemy.Move(random);
        }

        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }

        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health)
        {
            player.IncreaseHealth(health);
        }

        public void Attack(Mover.Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }

        private Point GetRandomLocation(Random random)
        {
          //  return new Point (bounderies.Left +
          //      random.Next(bounderies.Right/10 - bounderies.Left/10) * 10,
          //      random.Next(bounderies.Bottom/10 - bounderies.Top/10)*10);
            return new Point(random.Next(bounderies.Left, bounderies.Right), random.Next(bounderies.Top, bounderies.Bottom));
        }

        private void addWeaponInventory(string weaponName, Random random)
        {
            if (!CheckPlayerInventory(weaponName))
            {
                switch (weaponName)
                {
                    case "Sword":
                        WeaponInRoom = new Sword(this, GetRandomLocation(random));
                        break;
                    case "Bow":
                        WeaponInRoom = new Bow(this, GetRandomLocation(random));
                        break;
                    case "Mace":
                        WeaponInRoom = new Mace(this, GetRandomLocation(random));
                        break;
                    case "RedPotion":
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                        break;
                    case "BluePotion":
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                        break;
                }
            }                
        }

        private Enemy addEnemies(string enemieName, Random random)
        {
            Enemy enemy;
            switch (enemieName)
            {
                case "Ghost":
                    enemy = new Ghost(this, GetRandomLocation(random), bounderies);
                    break;
                case "Ghoul":
                    enemy = new Ghoul(this, GetRandomLocation(random), bounderies);
                    break;
                default:
                    enemy = new Bat(this, GetRandomLocation(random), bounderies);
                    break;
            }
            return enemy;
        }

        public void NewLevel(Random random)
        {
            level++;
            Enemies = new List<Enemy>();
            switch (level)
            {
                case 1:
                    Enemies.Add(addEnemies("Bat", random));
                    addWeaponInventory("Sword", random);
                    break;
                case 2:
                    Enemies.Add(addEnemies("Ghost", random));
                    addWeaponInventory("BluePotion", random);
                    break;
                case 3:
                    Enemies.Add(addEnemies("Ghoul", random));
                    addWeaponInventory("Bow", random);
                    break;

                case 4://4 morcego , fantasma  arco  ou entao pocao azul                   
                    Enemies.Add(addEnemies("Bat", random));
                    Enemies.Add(addEnemies("Ghost", random));
                    if (!CheckPlayerInventory("Bow"))
                        addWeaponInventory("Bow", random);
                    else
                        addWeaponInventory("BluePotion", random);
                    break;

                case 5: //5 morcego zumbi pocao vermelha                   
                    Enemies.Add(addEnemies("Bat", random));
                    Enemies.Add(addEnemies("Ghost", random));
                    addWeaponInventory("RedPotion", random);
                    break;

                case 6:             //6 fantasma zumbi mace                   
                    Enemies.Add(addEnemies("Ghost", random));
                    Enemies.Add(addEnemies("Ghoul", random));
                    addWeaponInventory("Mace", random);
                    break;

                case 7: //7 morcego,fantasm,zumbi mace ou entao pocao vermelha                   
                    Enemies.Add(addEnemies("Bat", random));
                    Enemies.Add(addEnemies("Ghost", random));
                    Enemies.Add(addEnemies("Ghoul", random));
                    if (!CheckPlayerInventory("Mace"))
                        addWeaponInventory("Mace", random);
                    else if (!CheckPlayerInventory("RedPotion"))
                        addWeaponInventory("RedPotion", random);
                    break;

                case 8://8 n/a --> terminei o jogo com o apllication.exit
                    break;

            }
        }
    }
}
