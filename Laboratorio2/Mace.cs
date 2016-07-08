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
            //to do
            //raio 20
            // 6 de dano
            //aqte nas 4 direcoes, circular!!
        }
    }
}
