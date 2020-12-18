using System;
using System.Linq;

namespace Day18
{
    public abstract class HomeworkSolverBase
    {
        public long SolveProblem(string input)
        {
            var cleanedInput = RemoveBrackets(input);
            return Calculate(cleanedInput);
        }
        
        private string RemoveBrackets(string input)
        {
            var nextBracketStr = GetNextBracketStr(input);

            if (nextBracketStr == input)
            {
                return input;
            }
            
            string replacementString;
            if (nextBracketStr.Count(c => c == '(') > 1)
            {
                var newSubCalculation = RemoveBrackets(nextBracketStr.Substring(1,nextBracketStr.Length -2));
                replacementString = Calculate(newSubCalculation).ToString();
            }
            else
            {
                replacementString = Calculate(nextBracketStr.Substring(1,nextBracketStr.Length -2)).ToString();
            }

            var newInput = input.Replace(nextBracketStr, replacementString);

            if (newInput.Any(n => n == '('))
            {
                newInput = RemoveBrackets(newInput);
            }
            return newInput;
        }
        
        private static string GetNextBracketStr(string input)
        {
            var firstBracket = input.IndexOf('(');

            if (firstBracket == -1)
            {
                return input;
            }
            
            var matchingBracket = 0;
            var leftBracketCount = 1;
            var rightBracketCount = 0;

            for (var i = firstBracket+1; i < input.Length; i++)
            {
                var checkChar = input[i];

                switch (checkChar)
                {
                    case '(':
                        leftBracketCount++;
                        break;
                    case ')':
                        rightBracketCount++;
                        break;
                }
                
                if (leftBracketCount == rightBracketCount)
                {
                    matchingBracket = i;
                    break;
                }
            }

            return input.Substring(firstBracket, matchingBracket - firstBracket+1);
        }

        protected abstract string CalculateStr(string input);
        
        private long Calculate(string input)
        {
            var valueStr = CalculateStr(input);
            if (!long.TryParse(valueStr, out var value))
            {
                throw  new Exception("Calculation error");
            }

            return value;
        }
    }
}