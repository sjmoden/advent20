using System;
using System.Linq;

namespace Day18
{
    public static class HomeworkSolver
    {
        public static long SolveProblem(string input)
        {
            var cleanedInput = RemoveBrackets(input);
            return Calculate(cleanedInput);
        }

        private static string RemoveBrackets(string input)
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

        private static int GetNextOperatorPosition(string input, int startingPosition)
        {
            var nextAddOperator = input.IndexOf("+",startingPosition, StringComparison.InvariantCultureIgnoreCase);
            var nextMultiplyOperator = input.IndexOf("*",startingPosition ,StringComparison.InvariantCultureIgnoreCase);

            if (nextAddOperator == -1 && nextMultiplyOperator == -1)
            {
                return -1;
            }
            if (nextAddOperator == -1 || nextMultiplyOperator == -1)
            {
                return Math.Max(nextAddOperator, nextMultiplyOperator); 
            }
            
            return Math.Min(nextAddOperator, nextMultiplyOperator);
        }
        
        private static string CalculateStr(string input)
        {
            var first = GetNextOperatorPosition(input, 0);
            var second = GetNextOperatorPosition(input, first+1);

            if (first == -1 && second == -1)
            {
                return input;
            }
            
            if (second == -1)
            {
                second = input.Length;
            }

            var operatorStr = input.Substring(first, 1);
            var firstValueStr = input.Substring(0, first);

            if (!long.TryParse(firstValueStr, out var firstValue))
            {
                throw  new ArgumentException("Input is not in the correct format");
            }
            
            var secondValueStr = input.Substring(first+1, second - first-1);
            if (!long.TryParse(secondValueStr, out var secondValue))
            {
                throw  new ArgumentException("Input is not in the correct format");
            }
            
            var strToReplace = input.Substring(0, second);
            long replacementValue = 0;
            switch (operatorStr)
            {
                case "+":
                    replacementValue = firstValue + secondValue;
                    break;
                case "*":
                    replacementValue = firstValue* secondValue;
                    break;
            }
            
            var newInput =replacementValue+ input.Substring(strToReplace.Length);
            return CalculateStr(newInput);
        }

        private static long Calculate(string input)
        {
            var valueStr = CalculateStr(input);
            if (!long.TryParse(valueStr, out var value))
            {
                throw  new Exception("Calculation error");
            }

            return value;
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
    }
}