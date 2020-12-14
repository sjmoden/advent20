using System;

namespace Day14
{
    public static class BitMasker
    {
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