﻿using System;
using System.Drawing;

namespace Day12
{
    public class ShipMover:IShipMover
    {
        private Point _movementPosition;
        private Point _position;
        public void InitialisePosition(Point startingPosition)
        {
            _position = startingPosition;
            _movementPosition = new Point(1,0);
        }

        public Point GetPosition()
        {
            return _position;
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
            _position.Offset(0,distance);
        }

        public void MoveEast(int distance)
        {
            _position.Offset(distance,0);
        }

        public void MoveWest(int distance)
        {
            _position.Offset(-1 * distance,0);
        }

        public void MoveSouth(int distance)
        {
            _position.Offset(0,-1 * distance);
        }

        public void RotateLeft(int degrees)
        {
            Rotate(degrees, () => _movementPosition = new Point(-1 * _movementPosition.Y, _movementPosition.X));
        }

        public void RotateRight(int degrees)
        {
            Rotate(degrees, () => _movementPosition = new Point(_movementPosition.Y, -1 * _movementPosition.X));
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
    }
}