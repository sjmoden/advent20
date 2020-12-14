using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public static class BitMasker
    {
        public static IEnumerable<long> ApplyMultipleBitMasks(string bitmask, int value)
        {
            var output = new List<long>();
            var bits = Convert.ToString(value, 2).PadLeft(36, '0').ToCharArray();

            var bitmaskArray = bitmask.ToCharArray();
            var xPositions = new List<int>();
            for (var i = 0; i < bitmaskArray.Length; i++)
            {
                var bitMaskOperation = bitmaskArray[i];
                if (bitMaskOperation == 'X')
                {
                    xPositions.Add(i);
                    bits[i] = 'X';
                    continue;
                }

                if (bitMaskOperation == '1')
                {
                    bits[i] = '1';
                }
            }

            var numberOfFloats = bits.Count(b => b == 'X');
            for (var i = 0; i < Math.Pow(2,numberOfFloats); i++)
            {
                var changeArray = Convert.ToString(i, 2).PadLeft(numberOfFloats,'0');

                var j = 0;
                foreach (var xPosition in xPositions)
                {
                    bits[xPosition] = changeArray[j];
                    j++;
                }
                
                output.Add(Convert.ToInt64(new string(bits), 2));
            }

            return output;
        }

        public static long ApplyBitmask(string bitmask, int value)
        {
            var bits = Convert.ToString(value, 2).PadLeft(36, '0').ToCharArray();

            var bitmaskArray = bitmask.ToCharArray();
            for (var i = 0; i < bitmaskArray.Length; i++)
            {
                var bitMaskOperation = bitmaskArray[i];
                if (bitMaskOperation == 'X')
                {
                    continue;
                }

                if (bitMaskOperation == '1')
                {
                    bits[i] = '1';
                }

                if (bitMaskOperation == '0')
                {
                    bits[i] = '0';
                }
            }
            
            return Convert.ToInt64(new string(bits),2);
        }
    }
}