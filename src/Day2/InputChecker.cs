using System;
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

        private void CheckInputToGetAnswers()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);

            _part1Answer = 0;
            _part2Answer = 0;
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
                    _part1Answer++;
                }

                if (PasswordPolicyChecker.CheckOfficialPassword(checkChar, minValue, maxValue, password))
                {
                    _part2Answer++;
                }
            }
        }

        private int _part1Answer;

        public int Part1Answer
        {
            get
            {
                if (_part1Answer == default)
                {
                    CheckInputToGetAnswers();
                }

                return _part1Answer;
            }
        }

        private int _part2Answer;
        public int Part2Answer {
            get
            {
                if (_part2Answer == default)
                {
                    CheckInputToGetAnswers();
                }

                return _part2Answer;
            }
        }
    }
}