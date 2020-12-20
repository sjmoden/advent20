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

        public void MakeRegexFromRules(IEnumerable<string> input, int maxInputLength)
        {
            var firstRule = input.Single(i => i.StartsWith("0:"));
            var splitFirstRule = firstRule.Split(':');
            _regex = $"{splitFirstRule[1]} ";
            CycleRegex(input, maxInputLength);
        }

        private void CycleRegex(IEnumerable<string> input, int maxInputLength)
        {
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
            //As per the problem suggestion, these are hard coded to solve the immediate issues
            //I could have made these more generic, but its not worth the grief
            else if (splitNextRule[1] == " 42 | 42 8")
            {
                replacementString = "(?: 42 )+";
            }
            else if (splitNextRule[1] == " 42 31 | 42 11 31")
            {
                //I know some flavours of regex allows for some level of recursion, but I do not think dotNet does.
                //This is a rough fix based off the length of the longest message
                // Its a tad rough, but it works
                var first = true;
                for (var i = 1; i <= maxInputLength; i++)
                {
                    if (!first)
                    {
                        replacementString += " | ";
                    }
                    else
                    {
                        replacementString += " (?: ";
                    }
                    replacementString += $"(?: 42 ){{{i}}} (?: 31 ){{{i}}}";
                    first = false;
                }

                replacementString += " ) ";
            }
            else
            {
                replacementString = $"(?:{splitNextRule[1]} )";
            }
            
            _regex = _regex.Replace($" {numberToFix.ToString().Trim()} ", $" {replacementString} ");
                
            CycleRegex(input, maxInputLength);
        }
        
    }
}