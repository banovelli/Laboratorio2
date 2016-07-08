﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio2
{
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

        public enum Direction{
            Up,
            Down,
            Left,
            Right
        }
    }
}