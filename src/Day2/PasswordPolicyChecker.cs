using System;
using System.Linq;

namespace Day2
{
    public static class PasswordPolicyChecker
    {
        public static bool CheckPassword(char checkLetter, int minValue, int maxValue, string password)
        {
            var numberOfEntries = password.Count(p => p == checkLetter);
            return numberOfEntries >= minValue && numberOfEntries <= maxValue;
        }
        
        public static bool CheckOfficialPassword(char checkLetter, int firstPosition, int secondPosition, string password)
        {
            if (firstPosition < 1 || secondPosition < 1)
            {
                throw  new ArgumentException("The positions cannot be less that 1.");
            }
            
            var firstPositionValue = password[firstPosition-1];
            var secondPositionValue = password[secondPosition-1];
            return firstPositionValue == checkLetter ^ secondPositionValue == checkLetter;
        }
    }
}