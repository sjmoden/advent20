using System.Drawing;

namespace Day12
{
    public interface IShipMover
    {
        void InitialisePosition(Point startingPosition);

        Point GetPosition();
        void MoveForward(int distance);
        void MoveNorth(int distance);
        void MoveEast(int distance);
        void MoveWest(int distance);
        void MoveSouth(int distance);
        void RotateLeft(int degrees);
        void RotateRight(int degrees);
    }
}