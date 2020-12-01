using System.Linq;

namespace AdventCode20
{
    public static class NumberChecker
    {
        public static bool TryGetCombinedNumberWhenAddingTo2020(int[] values, out int? combinedValue)
        {
            if (values.Sum() != 2020)
            {
                combinedValue = null;
                return false;
            }

            combinedValue = values.Aggregate((a, x) => a * x);;
            return true;
        }
    }
}