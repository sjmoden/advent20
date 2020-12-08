using System;
using Tools;

namespace Day8
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/8/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
            Boot.TryExecute(values, out var accumulatorValue);
            return accumulatorValue.ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
            var changePosition = 0;

            while (changePosition < values.Length)
            {
                if (TryModifyValues(values,changePosition, out var newValues) && Boot.TryExecute(newValues, out var accumulatorValue))
                {
                    return accumulatorValue.ToString();
                }  
                changePosition++;
            }
            
            throw new Exception("The correct value is not found.");
        }

        private static bool TryModifyValues(string[] values, int changePosition, out string[] newValues)
        {
            newValues = (string[])values.Clone();
            if (newValues[changePosition].StartsWith("acc"))
            {
                newValues = null;
                return false;
            }

            if (newValues[changePosition].StartsWith("jmp"))
            {
                newValues[changePosition] = newValues[changePosition].Replace("jmp", "nop");
            }
            else
            {
                newValues[changePosition] = newValues[changePosition].Replace("nop", "jmp");
            }

            return true;
        }
        
    }
}