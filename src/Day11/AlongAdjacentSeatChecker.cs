using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day11
{
    public class AlongAdjacentSeatChecker:IAdjacentSeatChecker
    {
        public bool CheckAdjacentSeatIsOccupied(Point position, IEnumerable<Seat> seatingMap, AdjacentSeatDirection direction)
        {
            var positionToCheck = ApplyOffset(position, direction);
            var highestXPosition = seatingMap.Max(s => s.Position.X);
            var highestYPosition = seatingMap.Max(s => s.Position.Y);
            while (positionToCheck.X >= 0 && positionToCheck.X<= highestXPosition && positionToCheck.Y >= 0 && positionToCheck.Y <= highestYPosition)
            {
                var seatToCheck = seatingMap.SingleOrDefault(s => s.Position == positionToCheck);

                if (seatToCheck == null)
                {
                    positionToCheck = ApplyOffset(positionToCheck, direction);
                    continue;
                }

                if (seatToCheck.Status == SeatStatus.Empty)
                {
                    return false;
                }

                if (seatToCheck.Status == SeatStatus.Occupied)
                {
                    return true;
                }
            }

            return false;
        }

        private Point ApplyOffset(Point position, AdjacentSeatDirection direction)
        {
            switch (direction)
            {
                case AdjacentSeatDirection.Down:
                    position.Offset(0,1);
                    break;
                case AdjacentSeatDirection.Up:
                    position.Offset(0,-1);
                    break;
                case AdjacentSeatDirection.Left:
                    position.Offset(-1,0);
                    break;
                case AdjacentSeatDirection.Right:
                    position.Offset(1,0);
                    break;
                case AdjacentSeatDirection.BottomLeft:
                    position.Offset(-1,1);
                    break;
                case AdjacentSeatDirection.BottomRight:
                    position.Offset(1,1);
                    break;
                case AdjacentSeatDirection.TopLeft:
                    position.Offset(-1,-1);
                    break;
                case AdjacentSeatDirection.TopRight:
                    position.Offset(1,-1);
                    break;
            }

            return position;
        }
    }
}