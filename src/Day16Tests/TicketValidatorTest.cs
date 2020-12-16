using System.Collections.Generic;
using System.Linq;
using Day16;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day16Tests.TicketValidatorTest
{
    [TestFixture]
    public class When_running_GetFailValue
    {
        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                var rules = new List<IRule>
                {
                    new Rule().CreateRule("class: 1-3 or 5-7"),
                    new Rule().CreateRule("row: 6-11 or 33-44"),
                    new Rule().CreateRule("seat: 13-40 or 45-50")
                };
                
                yield return new TestCaseData(rules,"7,3,47",0, true);
                yield return new TestCaseData(rules,"40,4,50",4, false);
                yield return new TestCaseData(rules,"55,2,20",55, false);
                yield return new TestCaseData(rules,"38,6,12",12, false);
            }
        }

        [TestCaseSource(nameof(TestData))]
        public void Then_return_value_is_correct(List<IRule> rules, string ticket, int expectedValue, bool expectedReturn)
        {
            Assert.That(new TicketValidator().CheckValidation(rules,ticket, out var failCode), Is.EqualTo(expectedReturn));
            Assert.That(failCode, Is.EqualTo(expectedValue));
        }
    }
    [TestFixture]
    public class When_running_ParseRuleFromValues
    {
        private static IEnumerable<TestCaseData> TestData
        {
            get
            {
                var rules = new List<IRule>
                {
                    new Rule().CreateRule("class: 0-1 or 4-19"),
                    new Rule().CreateRule("row: 0-5 or 8-19"),
                    new Rule().CreateRule("seat: 0-13 or 16-19")
                };
                
                yield return new TestCaseData(rules,new List<int>{3,15,5},new List<string>{ "row"});
                yield return new TestCaseData(rules,new List<int>{9,1,14},new List<string>{"class", "row"});
                yield return new TestCaseData(rules,new List<int>{18,5,9},new List<string>{"class", "row","seat"});
            }
        }

        [TestCaseSource(nameof(TestData))]
        public void Then_return_value_is_correct(List<IRule> rules, List<int> values, List<string> expectedValue)
        {
            Assert.That(new TicketValidator().ParseRuleFromValues(rules,values).Select(r => r.RuleName).SequenceEqual(expectedValue), Is.True);
        }
    }
}