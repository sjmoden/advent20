using System;
using System.Drawing;

namespace Day12
{
    public class ShipMoverUsingWaypoint:IShipMover
    {
        private Point _movementPosition;
        private Point _position;
        
        public void InitialisePosition(Point startingPosition)
        {
            _position = startingPosition;
            _movementPosition = new Point(10,1);
        }

        public void MoveForward(int distance)
        {
            for (var i = 0; i < distance; i++)
            {
                _position.Offset(_movementPosition.X, _movementPosition.Y);
            }
        }

        public void MoveNorth(int distance)
        {
            _movementPosition.Offset(0, distance);
        }

        public void MoveEast(int distance)
        {
            _movementPosition.Offset(distance,0);
        }

        public void MoveWest(int distance)
        {
            _movementPosition.Offset(distance* -1,0);
        }

        public void MoveSouth(int distance)
        {
            _movementPosition.Offset(0, distance* -1);
        }

        public void RotateLeft(int degrees)
        {
            Rotate(degrees,() =>_movementPosition = new Point(-1 * _movementPosition.Y, _movementPosition.X));
        }

        public void RotateRight(int degrees)
        {
            Rotate(degrees,() => _movementPosition = new Point(_movementPosition.Y, -1 * _movementPosition.X));
        }
        
        private static void Rotate(int degrees,Action rotationAction)
        {
            if (degrees % 90 != 0)
            {
                throw new ArgumentException("Degrees must be a multiple of 90");
            }
            
            var rotations = (degrees%360) / 90;

            for (var i = 0; i < rotations; i++)
            {
                rotationAction.Invoke();
            }
        }
        
        public Point GetPosition()
        {
            return _position;
        }
    }
}