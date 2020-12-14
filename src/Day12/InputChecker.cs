using System;
using Tools;

namespace Day12
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/12/input";
        private readonly IPuzzleInput _puzzleInput;
        private readonly IShipMover _shipMover;

        public InputChecker(IPuzzleInput puzzleInput, IShipMover shipMover)
        {
            _puzzleInput = puzzleInput;
            _shipMover = shipMover;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            var ship = new Ship(_shipMover);
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
            foreach (var value in values)
            {
                var command = value.Substring(0, 1);
                var distance = value.Substring(1);

                if (!int.TryParse(distance, out var distanceValue))
                {
                    throw  new Exception("Input not in the correct state");
                }

                switch (command)
                {
                    case "F":
                        ship.MoveForward(distanceValue);
                        break;
                    case "N":
                        ship.Move(Direction.North, distanceValue);
                        break;
                    case "S":
                        ship.Move(Direction.South, distanceValue);
                        break;
                    case "E":
                        ship.Move(Direction.East, distanceValue);
                        break;
                    case "W":
                        ship.Move(Direction.West, distanceValue);
                        break;
                    case "R":
                        ship.RotateRight(distanceValue);
                        break;
                    case "L":
                        ship.RotateLeft(distanceValue);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(command), command, null);
                }
            }
            
            return ship.GetTaxicabDistance().ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            throw new System.NotImplementedException();
        }
    }
}