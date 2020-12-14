using System;
using System.Drawing;

namespace Day12
{
    public class ShipMover:IShipMover
    {
        public Point Move(Direction direction, int distance, Point currentPosition)
        {
            return direction switch
            {
                Direction.East => MoveXAxis(distance, currentPosition),
                Direction.West => MoveXAxis(-1 * distance, currentPosition),
                Direction.North => MoveYAxis(distance, currentPosition),
                Direction.South => MoveYAxis(-1 * distance, currentPosition),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        public Direction Rotate(Direction direction, int degrees, bool rotateLeft)
        {
            if (degrees % 90 != 0)
            {
                throw new ArgumentException("Degrees must be a multiple of 90");
            }

            var degreesToCheck = degrees % 360;

            var newDirection = direction;
            switch (Math.Abs(degreesToCheck))
            {
                case 0:
                    return direction;
                case 90:
                    newDirection = Rotate(rotateLeft, newDirection);
                    break;
                case 180:
                    newDirection = Rotate(rotateLeft, newDirection);
                    newDirection = Rotate(rotateLeft, newDirection);
                    break;
                case 270:
                    newDirection = Rotate(rotateLeft, newDirection);
                    newDirection = Rotate(rotateLeft, newDirection);
                    newDirection = Rotate(rotateLeft, newDirection);
                    break;
                    
            }

            return newDirection;
        }

        private Direction Rotate(bool rotateLeft, Direction direction) => rotateLeft ? RotateLeft(direction) : RotateRight(direction);

        private Direction RotateLeft(Direction direction)
        {
            return direction switch
            {
                Direction.East => Direction.North,
                Direction.West => Direction.South,
                Direction.North => Direction.West,
                Direction.South => Direction.East,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
        private Direction RotateRight(Direction direction)
        {
            return direction switch
            {
                Direction.East => Direction.South,
                Direction.West => Direction.North,
                Direction.North => Direction.East,
                Direction.South => Direction.West,
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        private static Point MoveXAxis(int distance, Point currentPosition)
        {
            currentPosition.Offset(distance,0);
            return currentPosition;
        }

        private static Point MoveYAxis(int distance, Point currentPosition)
        {
            currentPosition.Offset(0,distance);
            return currentPosition;
        }
    }
}