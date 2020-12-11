using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day11
{
    public class ImmediateAdjacentSeatChecker: IAdjacentSeatChecker
    {
        public bool CheckAdjacentSeatIsOccupied(Point position, IEnumerable<Seat> seatingMap, AdjacentSeatDirection direction)
        {
            switch (direction)
            {
                case AdjacentSeatDirection.Down:
                    position.Offset(0,-1);
                    break;
                case AdjacentSeatDirection.Up:
                    position.Offset(0,1);
                    break;
                case AdjacentSeatDirection.Left:
                    position.Offset(-1,0);
                    break;
                case AdjacentSeatDirection.Right:
                    position.Offset(1,0);
                    break;
                case AdjacentSeatDirection.BottomLeft:
                    position.Offset(-1,-1);
                    break;
                case AdjacentSeatDirection.BottomRight:
                    position.Offset(1,-1);
                    break;
                case AdjacentSeatDirection.TopLeft:
                    position.Offset(-1,1);
                    break;
                case AdjacentSeatDirection.TopRight:
                    position.Offset(1,1);
                    break;
            }
            
            var seatToCheck = seatingMap.SingleOrDefault(s => s.Position == position);
            if (seatToCheck == null || seatToCheck.Status == SeatStatus.Empty)
            {
                return false;
            }

            return true;
        }
    }
}