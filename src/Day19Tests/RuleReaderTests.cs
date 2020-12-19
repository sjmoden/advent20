using System.Collections.Generic;
using Day19;
using NUnit.Framework;

namespace Day19Tests.RuleReaderTests
{
    [TestFixture]
    public class When_running_
    {
        private RuleReader _ruleReader = new RuleReader();
        
        [SetUp]
        public void Setup()
        {
            var input = new List<string>
            {
                 @"0: 4 1 5"
                ,@"1: 2 3 | 3 2"
                ,@"2: 4 4 | 5 5"
                ,@"3: 4 5 | 5 4"
                ,"4: \"a\""
                ,"5: \"b\""
            };
            
            _ruleReader.MakeRegexFromRules(input);
        }

        [TestCase("ababbb", true)]
        [TestCase("abbbab", true)]
        [TestCase("bababa", false)]
        [TestCase("aaabbb", false)]
        [TestCase("aaaabbb", false)]
        public void Then_the_result_is_correct(string checkString, bool expectedResult)
        {
            Assert.That(_ruleReader.CheckStringAgainstRules(checkString),Is.EqualTo(expectedResult));
        }
    }
}