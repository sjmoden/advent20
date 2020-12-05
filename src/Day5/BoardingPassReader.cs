using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public static class BoardingPassReader
    {
        public static int GetBoardingPassId(string input)
        {
            if (input.Length != 10)
            {
                throw new ArgumentException("The input must be exactly 10 characters long.");
            }

            var rowInput = input.Substring(0, 7);
            var columnInput = input.Substring(7);

            var row = GetItemFromSetUsingStringInput(128, rowInput, 'f', 'b');
            var column = GetItemFromSetUsingStringInput(8, columnInput, 'l', 'r'); 
            return GetSeatId(row,column);
        }

        public static int GetSeatId(int row, int column)
        {
            return (row*8)+column;
        }

        private static int GetItemFromSetUsingStringInput(int setSize, string input, char lowerCharacter, char upperCharacter)
        {
            var boolInput = input.ToLowerInvariant().Select(c => ConvertCharToBool(c, lowerCharacter, upperCharacter));
            return GetItemFromSet(setSize, boolInput);
        }

        private static bool ConvertCharToBool(char input, char lowerCharacter, char upperCharacter)
        {
            if (input == lowerCharacter)
            {
                return true;
            }
            if (input == upperCharacter)
            {
                return false;
            }
            
            throw new ArgumentException($"The input characters can only contain {lowerCharacter} or {upperCharacter}.");
        }

        private static int GetItemFromSet(int setSize, IEnumerable<bool> input)
        {
            var set = Enumerable.Range(0,setSize).ToList();

            set = input.Aggregate(set, (current, inputValue) => GetPartitionedSet(current, inputValue).ToList());

            if (set.Count == 1)
            {
                return set.First();
            }
            
            throw new ArgumentException("There are not enough operations to return a unique value in the set.");
        }
        
        private static IEnumerable<int> GetPartitionedSet(IReadOnlyCollection<int> set, bool firstHalf)
        {
            if (set.Count % 2 != 0)
            {
                throw new ArgumentException("This does not work with odd length sets.");
            }
            
            return firstHalf ? set.Take(set.Count / 2) : set.Skip(set.Count / 2);
        }
    }
}