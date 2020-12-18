using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day18
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/18/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            return Input.Sum(HomeworkSolver.SolveProblem).ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            throw new System.NotImplementedException();
        }
        
        private string[] _input;

        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}