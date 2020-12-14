using System;
using System.Drawing;

namespace Day12
{
    public class Ship
    {
        private readonly IShipMover _shipMover;

        public Point Position = new Point(0, 0);
        public Direction Direction = Direction.East;

        public Ship(IShipMover shipMover)
        {
            _shipMover = shipMover;
        }

        public int GetTaxicabDistance()
        {
            return Math.Abs(Position.X)  + Math.Abs(Position.Y);
        }

        public void ChangeDirection(Direction direction)
        {
            Direction = direction;
        }
        
        public void MoveForward(int distance)
        {
            Move(Direction, distance);
        }
        
        public void RotateRight(int degrees)
        {
            Direction = _shipMover.Rotate(Direction,degrees, false);
        }
        public void RotateLeft(int degrees)
        {
            Direction = _shipMover.Rotate(Direction,degrees,true);
        }
        
        public void Move(Direction direction, int distance)
        {
            Position=_shipMover.Move(direction, distance, Position);
        }
    }
}