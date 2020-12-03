using System;
using System.Drawing;
using System.Linq;
using Tools;

namespace Day3
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/3/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        
        public string CheckInputToGetAnswerPart1()
        {
            return CheckInput(3, 1).ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var values = new []
            {
                CheckInput(1, 1),
                CheckInput(3, 1),
                CheckInput(5, 1),
                CheckInput(7, 1),
                CheckInput(1, 2)
            };
            
            return values.Aggregate((a, x) => a * x).ToString();
        }

        private long CheckInput(int xOffset, int yOffset)
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);

            var treeCount = 0;

            for (var startingPosition = new Point(0,0); startingPosition.Y < values.Length - 1; startingPosition.Offset(xOffset,yOffset))
            {
                if (SlopeChecker.CheckIfPositionHoldsATree(values, startingPosition))
                {
                    treeCount++;
                }
            }
            
            return treeCount;
        }
    }
}