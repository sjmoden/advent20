using System.Collections.Generic;
using System.Drawing;

namespace Day11
{
    public interface IAdjacentSeatChecker
    {
        bool CheckAdjacentSeatIsOccupied(Point position, IEnumerable<Seat> seatingMap, AdjacentSeatDirection direction);
    }
}