using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day23
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/23/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            var input = Input.First();
            var cupCollection = new CupCollection(input.ToCharArray().Select(c => int.Parse(c.ToString())).ToList());
            var index = 1;
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"-- move {i+1} --");
                Console.WriteLine($"Index: {index}");
                Console.WriteLine(cupCollection.OutputCupsInCurrentState());
                cupCollection = cupCollection.PutListIntoCupCollectionAndReturnNewCollection(index, out index);
                Console.WriteLine();
                index++;
            }

            return cupCollection.OutputCups();
        }

        public string CheckInputToGetAnswerPart2()
        {
            throw new System.NotImplementedException();
        }
        
        private string[] _input;
        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}