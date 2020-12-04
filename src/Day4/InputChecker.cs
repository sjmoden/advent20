using System.Linq;
using Tools;

namespace Day4
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/4/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }

        public string CheckInputToGetAnswerPart1()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl,"\n\n");
            return values.Count(v => new Passport(v).CheckPassportThatFieldsExist).ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var values = _puzzleInput.GetPuzzleInputAsArray(InputUrl,"\n\n");
            return values.Count(v => new Passport(v).IsValid).ToString();
        }
    }
}