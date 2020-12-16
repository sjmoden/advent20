using Day16;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day16Tests.RuleTests
{
    [TestFixture]
    public class When_running_validation
    {
        [TestCase("class: 1-3 or 5-7",1,true)]
        [TestCase("class: 1-3 or 5-7",3,true)]
        [TestCase("class: 1-3 or 5-7",5,true)]
        [TestCase("class: 1-3 or 5-7",7,true)]
        [TestCase("class: 1-3 or 5-7",4,false)]
        [TestCase("class: 1-3 or 5-7",0,false)]
        [TestCase("class: 1-3 or 5-7",8,false)]
        public void Then_correct_value_is_returned(string rule,int value,bool expectedOutput)
        {
            Assert.That(new Rule().CreateRule(rule).Validate(value), Is.EqualTo(expectedOutput));
        }
    }
}