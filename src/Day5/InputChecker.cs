using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day5
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/5/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        public string CheckInputToGetAnswerPart1()
        {
            return SeatIds.Max().ToString();

        }

        public string CheckInputToGetAnswerPart2()
        {
            var allAvailableSeatIds = Enumerable.Range(0,128).SelectMany(r => Enumerable.Range(0,8).Select(c => BoardingPassReader.GetSeatId(r,c)));
            var potentialSeats = allAvailableSeatIds.Where(s => !SeatIds.Contains(s)).ToList();
            foreach (var potentialSeat in potentialSeats.Where(potentialSeat => SeatIds.Contains(potentialSeat - 1) && SeatIds.Contains(potentialSeat + 1)))
            {
                return potentialSeat.ToString();
            }
            throw new Exception("Seat not found.");
        }

        private IEnumerable<int> _seatIds;

        private IEnumerable<int> SeatIds
        {
            get
            {
                if (_seatIds == null)
                {
                    var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
                    _seatIds =  values.Where(v => !string.IsNullOrWhiteSpace(v)).Select(BoardingPassReader.GetBoardingPassId);
                }

                return _seatIds;
            }
        }
    }
}