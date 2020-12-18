using System;

namespace Day18
{
    public class HomeworkSolver:HomeworkSolverBase
    {
        protected override string CalculateStr(string input)
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
    }
}