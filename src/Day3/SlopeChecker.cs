using System;
using System.Drawing;

namespace Day3
{
    public static class SlopeChecker
    {
        private static bool CheckIfPositionOnRowHoldsATree(string input, int position)
        {
            return input[position % input.Length] == '#';
        }

        public static bool CheckIfPositionHoldsATree(string[] input, Point coordinate)
        {
            if (coordinate.Y >= input.Length)
            {
                throw new ArgumentException("Y coordinate is for a row that doesnt exist.");
            }
            
            return CheckIfPositionOnRowHoldsATree(input[coordinate.Y], coordinate.X);
        }
    }
}