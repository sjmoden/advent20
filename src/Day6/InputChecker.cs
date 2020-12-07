using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day6
{
    public class InputChecker:IInputChecker
    {        
        private const string InputUrl = "https://adventofcode.com/2020/day/6/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        public string CheckInputToGetAnswerPart1()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl,"\n\n");

            return values.Select(value => value.Split("\n").SelectMany(s => s.ToCharArray())).Select(questions => questions.Distinct().Count()).Sum().ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl,"\n\n");

            return (from value in values
                select value.Split("\n")
                into peopleResponses
                select peopleResponses.Select(response => response.ToCharArray().ToList())
                    .Where(questions => questions.Any())
                    .Aggregate<List<char>, List<char>>(null,
                        (current, questions) => current == null ? questions : current.Intersect(questions).ToList())
                into duplicates
                select duplicates.Distinct().Count()).Sum().ToString();
        }
    }
}