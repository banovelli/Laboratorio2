using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    public class Bow : Weapon
    {
        public Bow(Game game, Point location)
            : base(game, location) { }

        public override string Name { get { return "Bow"; } }
        public override void Attack(Direction direction, Random random)
        {
            //to do
            //raio 30
            // 1 de dano
            //aqte soimente na direcao
            
        }
    }
}
