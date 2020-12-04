using Day4;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day4Tests.PassportCheckerTests
{
    [TestFixture]
    public class When_checking_if_all_Passport_fields_are_provided
    {
        private const string Input1 = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm
";

        private const string Input2 = @"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929";
        
        private const string Input3 = @"hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm";
        
        private const string Input4 = @"hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";
        
        [TestCase(Input1, true)]
        [TestCase(Input2, false)]
        [TestCase(Input3, true)]
        [TestCase(Input4, false)]
        public void The_result_is_correct(string input, bool expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(new []{ input });
            
            Assert.That(new Passport(input).CheckPassportThatFieldsExist, Is.EqualTo(expectedResult));
        }
    }
    [TestFixture]
    public class When_checking_if_all_Passport_fields_are_valid
    {
        private const string Input1 = "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\nhcl:#623a2f";

        private const string Input2 = "eyr:2029 ecl:blu cid:129 byr:1989\niyr:2014 pid:896056539 hcl:#a97842 hgt:165cm";
        
        private const string Input3 = "hcl:#888785\nhgt:164cm byr:2001 iyr:2015 cid:88\npid:545766238 ecl:hzl\neyr:2022";
        
        private const string Input4 = "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";
        
        private const string Input5 = "eyr:1972 cid:100\nhcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926";
        
        private const string Input6 = "iyr:2019\nhcl:#602927 eyr:1967 hgt:170cm\necl:grn pid:012533040 byr:1946";
        
        private const string Input7 = "hcl:dab227 iyr:2012\necl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277";
        
        private const string Input8 = "hgt:59cm ecl:zzz\neyr:2038 hcl:74454a iyr:2023\npid:3556412378 byr:2007";
        
        [TestCase(Input1, true)]
        [TestCase(Input2, true)]
        [TestCase(Input3, true)]
        [TestCase(Input4, true)]
        [TestCase(Input5, false)]
        [TestCase(Input6, false)]
        [TestCase(Input7, false)]
        [TestCase(Input8, false)]
        public void The_result_is_correct(string input, bool expectedResult)
        {
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(new []{ input });
            
            Assert.That(new Passport(input).IsValid, Is.EqualTo(expectedResult));
        }
    }
}