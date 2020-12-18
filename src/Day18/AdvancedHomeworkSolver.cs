using System;

namespace Day18
{
    public class AdvancedHomeworkSolver:HomeworkSolverBase
    {
        protected override string CalculateStr(string input)
        {
            var c = CalculateAdditions(input);
            c = CalculateMultiplication(c);
            return c;
        }

        private string CalculateAdditions(string input)
        {
            var newInput = " "+input+" ";

            while (newInput.IndexOf("+", StringComparison.InvariantCultureIgnoreCase) > 0)
            {
                var firstAddition = newInput.IndexOf("+", StringComparison.InvariantCultureIgnoreCase);
                var previousMultiplication = newInput.LastIndexOf("*", firstAddition,StringComparison.InvariantCultureIgnoreCase);
                var nextAddition = newInput.IndexOf("+", firstAddition+1,StringComparison.InvariantCultureIgnoreCase);
                var nextMultiplication = newInput.IndexOf("*", firstAddition + 1,StringComparison.InvariantCultureIgnoreCase);
                
                var previousOperator = previousMultiplication;
                var nextOperator = Math.Min(nextAddition == -1 ? newInput.Length : nextAddition,
                    nextMultiplication == -1 ? newInput.Length : nextMultiplication);

                var firstValueStr = newInput.Substring(previousOperator+1, firstAddition -previousOperator -1);
                if (!long.TryParse(firstValueStr, out var firstValue))
                {
                    throw  new ArgumentException("Input is not in the correct format");
                }
                
                var secondValueStr = newInput.Substring(firstAddition+1, nextOperator - firstAddition-1);
                
                if (!long.TryParse(secondValueStr, out var secondValue))
                {
                    throw  new ArgumentException("Input is not in the correct format");
                }
                
                var calculatedValue = firstValue + secondValue;
                var replacementStr = newInput.Substring(previousOperator + 2, nextOperator - previousOperator-3);
                newInput = newInput.Replace($" {replacementStr} ", $" {calculatedValue} ");
            }
            
            return newInput;
        }

        private string CalculateMultiplication(string input)
        {
            var newInput = input;
            while (newInput.IndexOf("*", StringComparison.InvariantCultureIgnoreCase) > 0)
            {
                var firstMultiplication = newInput.IndexOf("*", StringComparison.InvariantCultureIgnoreCase);
                var previousAddition = newInput.LastIndexOf("+", firstMultiplication,StringComparison.InvariantCultureIgnoreCase);
                var nextAddition = newInput.IndexOf("+", firstMultiplication+1,StringComparison.InvariantCultureIgnoreCase);
                var nextMultiplication = newInput.IndexOf("*", firstMultiplication + 1,StringComparison.InvariantCultureIgnoreCase);

                var previousOperator = Math.Max(0, previousAddition);
                var nextOperator = Math.Min(nextAddition == -1 ? newInput.Length : nextAddition,
                    nextMultiplication == -1 ? newInput.Length : nextMultiplication);

                var firstValueStr = newInput.Substring(previousOperator+1, firstMultiplication -previousOperator -1);
                if (!long.TryParse(firstValueStr, out var firstValue))
                {
                    throw  new ArgumentException("Input is not in the correct format");
                }
                
                var secondValueStr = newInput.Substring(firstMultiplication+1, nextOperator - firstMultiplication-1);
                
                if (!long.TryParse(secondValueStr, out var secondValue))
                {
                    throw  new ArgumentException("Input is not in the correct format");
                }

                var calculatedValue = firstValue * secondValue;
                var replacementStr = newInput.Substring(previousOperator + 1, nextOperator - previousOperator-2);
                newInput = newInput.Replace($" {replacementStr} ", $" {calculatedValue} ");
            }

            return newInput;
        }
    }
}