using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    public static class XmasValidator
    {
        public static bool Validate(long numberToCheck, IEnumerable<long> preambleValues)
        {
            foreach (var preambleValue in preambleValues)
            {
                var checkValue = numberToCheck - preambleValue;
                if (preambleValue % checkValue == 0  && preambleValues.Count(p => p == checkValue) > 1)
                {
                    return true;
                }
                
                if (preambleValue % checkValue != 0 && preambleValues.Any(p => p == checkValue))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool TryGetFirstInvalid(long[] input, int preAmbleDepth, out long invalidValue)
        {
            for (var i = preAmbleDepth; i < input.Length; i++)
            {
                if (!Validate(input[i],input.Skip(i-preAmbleDepth).Take(preAmbleDepth)))
                {
                    invalidValue = input[i];
                    return true;
                }
            }

            invalidValue = default;
            return false;
        }

        public static bool TryGetContiguousSet(long[] input, long checkValue, out List<long> contiguousSet)
        {
            for(var i = 0; i<input.Length;i++)
            {
                if (input[i] >= checkValue)
                {
                    continue;
                }
                
                contiguousSet = new List<long>();
                var j = 0;
                while (contiguousSet.Sum() < checkValue)
                {
                    contiguousSet.Add(input[i+j]);

                    if (contiguousSet.Sum() == checkValue)
                    {
                        return true;
                    }

                    j++;
                }
            }

            contiguousSet = default;
            return false;
        }
    }
}