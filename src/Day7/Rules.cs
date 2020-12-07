using System.Collections.Generic;
using Tools;

namespace Day7
{
    public class RulesFromInput:IRules
    {
        private readonly IPuzzleInput _puzzleInput;
        private const string InputUrl = "https://adventofcode.com/2020/day/7/input";

        public RulesFromInput(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        private IEnumerable<string> _rules;
        public IEnumerable<string> Rules => _rules ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}