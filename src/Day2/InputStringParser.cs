namespace Day2
{
    public class InputStringParser
    {
        public static bool TryParseString(string input, out string password, out char checkChar, out int minValue,
            out int maxValue)
        {
            var inputSplit = input.Split(':');

            if (inputSplit.Length < 2 || string.IsNullOrWhiteSpace(inputSplit[1]))
            {
                SetValuesToDefaults(out password,out checkChar,out minValue,out maxValue);
                return false;
            }

            password = inputSplit[1].Trim();

            var policySplit = inputSplit[0].Split(' ');
            
            if (policySplit.Length < 2 || policySplit[1].Trim().Length > 1)
            {
                SetValuesToDefaults(out password,out checkChar,out minValue,out maxValue);
                return false;
            }

            checkChar = policySplit[1].Trim()[0];

            var numbersSplit = policySplit[0].Split('-');
            
            if (numbersSplit.Length < 2 || !int.TryParse(numbersSplit[0], out minValue) || !int.TryParse(numbersSplit[1], out maxValue))
            {
                SetValuesToDefaults(out password,out checkChar,out minValue,out maxValue);
                return false;
            }

            return true;
        }

        private static void SetValuesToDefaults(out string password, out char checkChar, out int minValue, out int maxValue)
        {
            password = default;
            checkChar = default;
            minValue = default;
            maxValue = default;
        }
    }
}