using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tools;

namespace Day11
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/11/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            return GetNumberOfSeatsChanged(new ImmediateAdjacentSeatChecker(),4).ToString();
        }
        
        public string CheckInputToGetAnswerPart2()
        {
            return GetNumberOfSeatsChanged(new AlongAdjacentSeatChecker(), 5).ToString();
        }

        private int GetNumberOfSeatsChanged(IAdjacentSeatChecker adjacentSeatChecker, int tolerance)
        {
            var seatFiller = new FerrySeatingMap(StartingSeats, adjacentSeatChecker, tolerance);

            var iteration = 0;
            while (seatFiller.AtLeastOnePersonMovedSeats)
            {
                iteration++;
                seatFiller.PopulateSeats();
                Console.WriteLine($"Iteration count: {iteration}");
            }

            return seatFiller.SeatingMap.Count(s => s.Status == SeatStatus.Occupied);
        }

        private List<Seat> _startingSeats;
        private List<Seat> StartingSeats
        {
            get
            {
                if (_startingSeats == null)
                {
                    _startingSeats = GetSeats();
                }

                return _startingSeats;
            }
        }
        
        private List<Seat> GetSeats()
        {
            var seats = new List<Seat>();
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
            
            for(var i = 0; i< values.Length; i++)
            {
                var row = values[i];
                
                for (var j = 0; j < row.Length; j++)
                {
                    var seat = new Seat().CreateSeat(values[i][j], new Point(j,i));
                    if (seat!= null)
                    {
                        seats.Add(seat);
                    }
                }
            }
            
            return seats;
        }

        
    }
}