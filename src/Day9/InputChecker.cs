using System;
using System.Linq;
using Tools;

namespace Day9
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/9/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        public string CheckInputToGetAnswerPart1()
        {
            return FirstInvalidValue.ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            if (!XmasValidator.TryGetContiguousSet(Input, FirstInvalidValue, out var contiguous))
            {
                throw new Exception("Contiguous Set not found.");
            }

            return (contiguous.Max() + contiguous.Min()).ToString();
        }
        
        private long[] _input;
        private long[] Input => _input ??= Array.ConvertAll(_puzzleInput.GetPuzzleInputAsArray(InputUrl), long.Parse);
        
        private long _firstInvalidValue;

        private long FirstInvalidValue
        {
            get
            {
                if (_firstInvalidValue == default)
                {
                    if (!XmasValidator.TryGetFirstInvalid(Input, 25, out _firstInvalidValue))
                    {
                        throw new Exception("Invalid entry not found.");
                    }
                    
                }

                return _firstInvalidValue;
            }
        }
    }
}