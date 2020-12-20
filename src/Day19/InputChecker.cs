using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day19
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/19/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            var ruleReader = new RuleReader();
            ruleReader.MakeRegexFromRules(Rules,0);
            return Messages.Count(i => ruleReader.CheckStringAgainstRules(i)).ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            var newRules = Rules.Select(m =>
                m.Replace("8: 42", "8: 42 | 42 8").Replace("11: 42 31", "11: 42 31 | 42 11 31")).ToList();
            var ruleReader = new RuleReader();
            ruleReader.MakeRegexFromRules(newRules,Messages.Max(m => m.Length));
            return Messages.Count(i => ruleReader.CheckStringAgainstRules(i)).ToString();
        }

        private IEnumerable<string> _rules;
        private IEnumerable<string> Rules => _rules ??= Input.Where(i => i.Contains(':')); 
        
        private IEnumerable<string> _messages;
        private IEnumerable<string> Messages => _messages ??= Input.Where(i => !i.Contains(':')); 
        
        private string[] _input;
        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}