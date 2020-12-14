using System;
using System.Collections.Generic;
using System.Drawing;
using Tools;
using Unity;

namespace Day12
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/12/input";
        private readonly IPuzzleInput _puzzleInput;
        private readonly IShip _ship;
        private readonly IShip _shipUsingWayPoint;

        public InputChecker(IPuzzleInput puzzleInput, [Dependency("Ship")] IShip ship, [Dependency("ShipUsingWaypoint")] IShip shipUsingWayPoint)
        {
            _puzzleInput = puzzleInput;
            _ship = ship;
            _shipUsingWayPoint = shipUsingWayPoint;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            var ship = _ship.SetUpShip(new Point(0,0));
            RunInputOnShip(ship);
            return ship.GetTaxicabDistance().ToString();
        }

        private void RunInputOnShip(Ship ship)
        {
            foreach (var value in Input)
            {
                var command = value.Substring(0, 1);
                var distance = value.Substring(1);

                if (!int.TryParse(distance, out var distanceValue))
                {
                    throw new Exception("Input not in the correct state");
                }

                switch (command)
                {
                    case "F":
                        ship.ShipMover.MoveForward(distanceValue);
                        break;
                    case "N":
                        ship.ShipMover.MoveNorth(distanceValue);
                        break;
                    case "S":
                        ship.ShipMover.MoveSouth(distanceValue);
                        break;
                    case "E":
                        ship.ShipMover.MoveEast(distanceValue);
                        break;
                    case "W":
                        ship.ShipMover.MoveWest(distanceValue);
                        break;
                    case "R":
                        ship.ShipMover.RotateRight(distanceValue);
                        break;
                    case "L":
                        ship.ShipMover.RotateLeft(distanceValue);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(command), command, null);
                }
            }
        }

        public string CheckInputToGetAnswerPart2()
        {
            var ship = _shipUsingWayPoint.SetUpShip(new Point(0,0));
            RunInputOnShip(ship);
            return ship.GetTaxicabDistance().ToString();
        }
        
        
        private string[] _input;

        private IEnumerable<string> Input
        {
            get
            {
                if (_input == null)
                {
                    _input = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
                }

                return _input;
            }
        }
    }
}