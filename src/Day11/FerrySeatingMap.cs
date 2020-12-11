using System.Collections.Generic;

namespace Day11
{
    public class FerrySeatingMap
    {
        private readonly IAdjacentSeatChecker _adjacentSeatChecker;
        private readonly int _tolerance;
        public FerrySeatingMap(List<Seat> seatingMap, IAdjacentSeatChecker adjacentSeatChecker, int tolerance)
        {
            SeatingMap=seatingMap;
            _adjacentSeatChecker = adjacentSeatChecker;
            _tolerance = tolerance;
            AtLeastOnePersonMovedSeats = true;
        }
        
        public List<Seat> SeatingMap;
        public bool AtLeastOnePersonMovedSeats; 
        
        public void PopulateSeats()
        {
            AtLeastOnePersonMovedSeats = false;
            var newSeatingMap = new List<Seat>();

            foreach (var seat in SeatingMap)
            {
                var status = seat.Status;
                
                if (status == SeatStatus.Occupied && GetNumberOfAdjacentOccupiedSeats(seat) >= _tolerance)
                {
                    status = SeatStatus.Empty;
                    AtLeastOnePersonMovedSeats = true;
                }
                else if (status == SeatStatus.Empty && GetNumberOfAdjacentOccupiedSeats(seat) == 0)
                {
                    status = SeatStatus.Occupied;
                    AtLeastOnePersonMovedSeats = true;
                }

                var newSeat = new Seat().CreateSeat(status, seat.Position);
                newSeatingMap.Add(newSeat);
            }
            
            SeatingMap = newSeatingMap;
        }

        private int GetNumberOfAdjacentOccupiedSeats(Seat seat)
        {
            var count = 0;

            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.Up))
            {
                count++;
            }
            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.Down))
            {
                count++;
            }
            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.Left))
            {
                count++;
            }
            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.Right))
            {
                count++;
            }
            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.TopLeft))
            {
                count++;
            }
            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.TopRight))
            {
                count++;
            }
            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.BottomLeft))
            {
                count++;
            }
            if (_adjacentSeatChecker.CheckAdjacentSeatIsOccupied(seat.Position,SeatingMap,AdjacentSeatDirection.BottomRight))
            {
                count++;
            }
            
            return count;
        }
    }
}