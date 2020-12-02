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
    }
}