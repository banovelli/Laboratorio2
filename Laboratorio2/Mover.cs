﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
    //um problema pra resolver depois é considerar o ceontro do player ou enemy ao inves do top left, e assim calcular qual seria a sua posicao para o ataque.....
    public abstract class Mover
    {
        private const int MoveInterval = 10;
        public Point location;
        public Point Location{get {return location;}}
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(location.X - locationToCheck.X) < distance &&
                (Math.Abs(location.Y - locationToCheck.Y) < distance))
                return true;

            return false;
        }

        public bool Nearby(Point locationToCheck, Point target, int distance)
        {
            if (Math.Abs(target.X - locationToCheck.X) < distance &&
                (Math.Abs(target.Y - locationToCheck.Y) < distance))
                return true;

            return false;
        }

        public Point Move(Direction direction, Rectangle bounderies)
        {
            Point newLocation = location;
            switch(direction){
                case Direction.Up:
                    if(newLocation.Y-MoveInterval >= bounderies.Top)
                        newLocation.Y -=MoveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= bounderies.Bottom)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= bounderies.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= bounderies.Right)
                        newLocation.X += MoveInterval;
                    break;
                default:
                    break;
            }
            return newLocation;
        }

        public Direction DirecaoJogador(Point location, Point target)
        {
            Direction direcao;
            int diffX = location.X - target.X;
            int diffY = location.Y - target.Y;
            if (Math.Abs(diffX) >= Math.Abs(diffY))
            {
                if (diffX >= 0)
                    direcao = Direction.Left;
                else
                    direcao = Direction.Right;
            }
            else{
                if (diffY >= 0)
                    direcao = Direction.Up;
                else
                    direcao = Direction.Down;

            }
            return direcao;
        }

        public enum Direction{
            Up,
            Down,
            Left,
            Right
        }
    }
}
