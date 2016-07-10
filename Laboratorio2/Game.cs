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

        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), bounderies));
                    if (!CheckPlayerInventory("Sword"))
                        WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                case 2:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), bounderies));
                    if (!CheckPlayerInventory("Sword"))
                        WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    if (!CheckPlayerInventory("BluePotion"))
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;
                case 3:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), bounderies));
                    if (!CheckPlayerInventory("Bow"))
                        WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;

                case 4://4 morcego , fantasma  arco  ou entao pocao azul
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), bounderies));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), bounderies));
                    if (!CheckPlayerInventory("Bow"))
                        WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    else if (!CheckPlayerInventory("BluePotion"))
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;

                case 5: //5 morcego zumbi pocao vermelha
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), bounderies));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), bounderies));
                    if (!CheckPlayerInventory("RedPotion"))
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;

                case 6:             //6 fantasma zumbi mace
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), bounderies));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), bounderies));
                    if (!CheckPlayerInventory("Mace"))
                        WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;

                case 7: //7 morcego,fantasm,zumbi mace ou entao pocao vermelha
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), bounderies));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random), bounderies));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random), bounderies));
                    if (!CheckPlayerInventory("Mace"))
                        WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    else if (!CheckPlayerInventory("RedPotion"))
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;

                case 8://8 n/a --> terminei o jogo com o apllication.exit
                    Enemies = new List<Enemy>();
                    break;

            }
           
            
            
            
            
        }
    }
}
