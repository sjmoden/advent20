namespace Day8
{
    public static class BootCommandParser
    {
        public static bool TryParse(string input, out BootCommand command, out int argument)
        {
            var inputSplit = input.Split(' ');

            if (inputSplit.Length != 2)
            {
                command = default;
                argument = default;
                return false;
            }

            switch (inputSplit[0].ToLowerInvariant())
            {
                case "acc":
                    command = BootCommand.Accumulate;
                    break;
                case "jmp":
                    command = BootCommand.Jump;
                    break;
                case "nop":
                    command = BootCommand.NoOperation;
                    break;
                default:
                    command = default;
                    argument = default;
                    return false;
            }

            return int.TryParse(inputSplit[1], out argument);
        }
    }
}