using System;
using System.Collections.Generic;

namespace Day8
{
    public static class Boot
    {
        public static bool TryExecute(string[] values, out int accumulatorValue)
        {
            var positionsAttended = new List<int>();
            var position = 0;
            accumulatorValue = 0;

            while (true)
            {
                if (positionsAttended.Contains(position))
                {
                    return false;
                }

                positionsAttended.Add(position);
                BootCommandParser.TryParse(values[position], out var command, out var argument);
                ExecuteSingle(command,ref position,ref accumulatorValue,argument);

                if (position >= values.Length)
                {
                    return true;
                }
            }
        }
        
        public static void ExecuteSingle(BootCommand command,ref int position,ref int accumulatorValue, int argument)
        {
            switch (command)
            {
                case BootCommand.NoOperation:
                    position++;
                    break;
                case BootCommand.Jump:
                    position += argument;
                    break;
                case BootCommand.Accumulate:
                    position++;
                    accumulatorValue += argument;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(command), command, null);
            }
        }
    }
}