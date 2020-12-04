using System;
using System.Globalization;
using System.Linq;

namespace Day4
{
    public class Passport:IPassport
    {
        public Passport(string input)
        {
            var entries = input.Split(new [] {"\n"," "}, StringSplitOptions.None);
            
            foreach (var entry in entries)
            {
                var keyValue = entry.Split(':');
                
                if (string.IsNullOrWhiteSpace(keyValue[0]) || string.IsNullOrWhiteSpace(keyValue[1]))
                {
                    continue;
                }
                
                switch (keyValue[0].ToLowerInvariant())
                {
                    case "byr":
                        _birthYear = keyValue[1];
                        break;
                    case "iyr":
                        _issueYear = keyValue[1];
                        break;
                    case "eyr":
                        _expirationYear = keyValue[1];
                        break;
                    case "hgt":
                        _height = keyValue[1];
                        break;
                    case "hcl":
                        _hairColour = keyValue[1];
                        break;
                    case "ecl":
                        _eyeColour = keyValue[1];
                        break;
                    case "pid":
                        _passportId = keyValue[1];
                        break;
                }
            }
        }
        
        private readonly string _birthYear;
        private readonly string _issueYear;
        private readonly string _expirationYear;
        private readonly string _height;
        private readonly string _hairColour;
        private readonly string _eyeColour;
        private readonly string _passportId;

        public bool CheckPassportThatFieldsExist =>
            !string.IsNullOrWhiteSpace(_birthYear)
            && !string.IsNullOrWhiteSpace(_issueYear)
            && !string.IsNullOrWhiteSpace(_expirationYear)
            && !string.IsNullOrWhiteSpace(_height)
            && !string.IsNullOrWhiteSpace(_hairColour)
            && !string.IsNullOrWhiteSpace(_eyeColour)
            && !string.IsNullOrWhiteSpace(_passportId);

        public bool IsValid => CheckIfValid();

        private bool CheckIfValid()
        {
            if (!CheckPassportThatFieldsExist)
            {
                return false;
            }

            if (!int.TryParse(_birthYear, out var birthYear) || birthYear < 1920 || birthYear > 2002)
            {
                return false;
            }
            
            if (!int.TryParse(_issueYear, out var issueYear) || issueYear < 2010 || issueYear > 2020)
            {
                return false;
            }
            
            if (!int.TryParse(_expirationYear, out var expirationYear) || expirationYear < 2020 || expirationYear > 2030)
            {
                return false;
            }
            
            var acceptableEyeColours = new[] {"amb","blu","brn","gry","grn","hzl","oth"};
            if (!acceptableEyeColours.Contains(_eyeColour, StringComparer.InvariantCultureIgnoreCase))
            {
                return false;
            }
            
            if (!_hairColour.StartsWith('#') || _hairColour.Length != 7 || !int.TryParse(_hairColour.Substring(1),
                NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _))
            {
                return false;
            }
            
            if (_passportId.Length != 9 || !int.TryParse(_passportId, out _))
            {
                return false;
            }

            if (!ValidateHeight())
            {
                return false;
            }
            
            return true;
        }

        private bool ValidateHeight()
        {
            var endingString = _height.Substring(_height.Length - 2);
            var startingString = _height.Substring(0,_height.Length - 2);
            if (!int.TryParse(startingString, out var heightValue))
            {
                return false;
            }


            switch (endingString.ToLowerInvariant())
            {
                case "cm":
                    return heightValue >= 150 && heightValue <= 193;
                case "in":
                    return heightValue >= 59 && heightValue <= 76;
                default:
                    return false;
            }
        }
    }
}