using System.Drawing;

namespace Day12
{
    public interface IShipMover
    {
        Point Move(Direction direction, int distance, Point currentPosition);
        Direction Rotate(Direction direction, int degrees, bool rotateLeft);
    }
}