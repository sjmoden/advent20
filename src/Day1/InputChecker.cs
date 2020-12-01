using System;
using Tools;

namespace AdventCode20
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/1/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public int CheckInputToGetAnswerPart1()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
            for(var  i =0; i<values.Length-1;i++)
            {
                var firstValue = int.Parse(values[i]); 
                for (var j = i + 1; j < values.Length-1; j++)
                {
                    var secondValue = int.Parse(values[j]);
                    if (NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstValue, secondValue}, out var combinedValue) && combinedValue != null)
                    {
                        return (int)combinedValue;
                    }
                }
            }

            throw new Exception("No values in the input combine to 2020");
        }

        public int CheckInputToGetAnswerPart2()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl);
            
            for(var  i =0; i<values.Length-1;i++)
            {
                var firstValue = int.Parse(values[i]); 
                for (var j = i + 1; j < values.Length-1; j++)
                {
                    var secondValue = int.Parse(values[j]);
                    for (var k = j + 1; k < values.Length - 1; k++)
                    {
                        var thirdValue = int.Parse(values[k]);
                        if (NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstValue, secondValue,thirdValue}, out var combinedValue) && combinedValue != null)
                        {
                            return (int)combinedValue;
                        }
                    }
                }
            }
            
            throw new Exception("No values in the input combine to 2020");
        }
    }
}