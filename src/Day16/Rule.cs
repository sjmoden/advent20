using System;
using System.Text.RegularExpressions;

namespace Day16
{
    public class Rule:IRule
    {
        private (int lowestValue, int highestValue) _firstRange;
        private (int lowestValue, int highestValue) _secondRange;

        public string RuleName { get; private set; }

        public IRule CreateRule(string ruleString)
        {
            var matches = Regex.Match(ruleString,@"^(?'name'[a-zA-Z\s]*): (?'firstlower'[0-9]*)-(?'firstupper'[0-9]*) or (?'secondlower'[0-9]*)-(?'secondupper'[0-9]*)$");
            RuleName = matches.Groups["name"].Value;

            if (string.IsNullOrWhiteSpace(RuleName))
            {
                throw new ArgumentException("Rule Name cannot be parsed");
            }
            var firstLowerStr = matches.Groups["firstlower"].Value;
            var firstUpperStr = matches.Groups["firstupper"].Value;
            
            if (!int.TryParse(firstLowerStr, out var firstLowerValue) || !int.TryParse(firstUpperStr, out var firstUpperValue))
            {
                throw new ArgumentException("First Range cannot be parsed");
            }

            _firstRange = (firstLowerValue, firstUpperValue);
            
            var secondLowerStr = matches.Groups["secondlower"].Value;
            var secondUpperStr = matches.Groups["secondupper"].Value;
            
            if (!int.TryParse(secondLowerStr, out var secondLowerValue) || !int.TryParse(secondUpperStr, out var secondUpperValue))
            {
                throw new ArgumentException("Second Range cannot be parsed");
            }

            _secondRange = (secondLowerValue, secondUpperValue);
            
            return this;
        }

        public bool Validate(int value)
        {
            if (value <= _firstRange.highestValue && value >= _firstRange.lowestValue)
            {
                return true;
            }
            
            if (value <= _secondRange.highestValue && value >= _secondRange.lowestValue)
            {
                return true;
            }
            
            return false;
        }
    }
}