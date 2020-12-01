namespace AdventCode20
{
    public static class NumberChecker
    {
        public static bool TryGetCombinedNumberWhenAddingTo2020(int firstValue, int secondValue, out int? combinedValue)
        {
            if (firstValue + secondValue != 2020)
            {
                combinedValue = null;
                return false;
            }

            combinedValue = firstValue * secondValue;
            return true;
        }
        
        public static bool TryGetCombinedNumberWhenAddingTo2020(int firstValue, int secondValue,int thirdValue, out int? combinedValue)
        {
            if (firstValue + secondValue + thirdValue != 2020)
            {
                combinedValue = null;
                return false;
            }

            combinedValue = firstValue * secondValue * thirdValue;
            return true;
        }
    }
}