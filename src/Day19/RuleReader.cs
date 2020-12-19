using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day19
{
    public class RuleReader
    {
        private string _regex = string.Empty;

        public bool CheckStringAgainstRules(string checkInput)
        {
            return Regex.IsMatch(checkInput,_regex);
        }

        public void MakeRegexFromRules(IEnumerable<string> input)
        {
            var firstRule = input.Single(i => i.StartsWith("0:"));
            var splitFirstRule = firstRule.Split(':');
            _regex = $"{splitFirstRule[1]} ";
            CycleRegex(input);
        }

        private void CycleRegex(IEnumerable<string> input)
        {
            //Console.WriteLine(_regex);
            var numberToFix = Regex.Match(_regex,"(?'Number' [0-9]+)");
            if (!numberToFix.Groups["Number"].Success)
            {
                _regex = _regex.Replace("\"", "").Replace(" ", "");
                _regex = $"^{_regex}$";
                return;
            }

            var nextRule = input.Single(i => i.StartsWith($"{numberToFix.Groups["Number"].Value.Trim()}:"));
            var splitNextRule = nextRule.Split(':');

            var replacementString = string.Empty;

            if (splitNextRule[1].Contains("\"") || !splitNextRule[1].Contains("|"))
            {
                replacementString = splitNextRule[1];
            }
            else
            {
                replacementString = $"(?:{splitNextRule[1]} )";
            }
            
            _regex = _regex.Replace($" {numberToFix.ToString().Trim()} ", $" {replacementString} ");
                
            CycleRegex(input);
        }
        
    }
}