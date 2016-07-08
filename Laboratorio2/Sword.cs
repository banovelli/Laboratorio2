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
            //to do
            //raio 10
            // 3 de dano
            //primeiro ataque 'frontal'
            // se nao ataqueque sentido horario
            // se nao ataque sentido anti horario
        }
    }
}
