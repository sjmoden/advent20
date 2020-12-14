using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tools;

namespace Day14
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/14/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
            
        }
        public string CheckInputToGetAnswerPart1()
        {
            var memory = new Memory();
            var currentMask = string.Empty;
            foreach (var value in Input)
            {
                if (value.StartsWith("mask"))
                {
                    currentMask = value.Replace("mask = ", string.Empty);
                    continue;
                }
                
                var matchesPosition = Regex.Match(value,@"mem\[(?'position'[0-9]*)]");
                
                var position = matchesPosition.Groups["position"].Value;
                if (!int.TryParse(position, out var positionValue))
                {
                    throw new Exception("The Position is not a value");
                }
                
                var matchesNumber = Regex.Match(value,@"mem\[[0-9]*] = (?'number'[0-9]*)");
                
                var number = matchesNumber.Groups["number"].Value;
                if (!int.TryParse(number, out var numberValue))
                {
                    throw new Exception("The number is not a value");
                }
                
                memory.UpdateMemory(positionValue, BitMasker.ApplyBitmask(currentMask,numberValue));
            }

            return memory.ReturnMemorySum().ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            throw new NotImplementedException();
        }
        
        private string[] _input;

        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}