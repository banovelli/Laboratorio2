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

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Mover.Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }

        private Point GetRandomLocation(Random random)
        {
            return new Point (bounderies.Left +
                random.Next(bounderies.Right/10 - bounderies.Left/10) * 10,
                random.Next(bounderies.Bottom/10 - bounderies.Top/10)*10);
        }

        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), bounderies));
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                case 2:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random), bounderies));
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
            }
            //2 fantasma poção azul, sword
            //3 zumbi arco
            //4 morcego , fantasma  arco  ou entao pocao azul
            //5 morcego zumbi pocao vermelha
            //6 fantasma zumbi mace
            //7 morcego,fantasm,zumbi mace ou entao pocao vermelha
            //8 n/a --> terminei o jogo com o apllication.exit
        }
    }
}
