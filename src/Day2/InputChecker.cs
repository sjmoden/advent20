using System;
using System.Linq;
using Tools;

namespace Day2
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/2/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public int CheckInputToGetAnswerPart1()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);

            int count = 0;
            foreach (var value in values)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }
                
                if (!InputStringParser.TryParseString(value, out var password, out var checkChar, out var minValue, out var maxValue))
                {
                    throw new Exception($"A value is not in the correct format, I have not planned to deal with this: {value}");
                }

                if (PasswordPolicyChecker.CheckPassword(checkChar, minValue, maxValue, password))
                {
                    count++;
                }
            }

            return count;
        }
    }
}