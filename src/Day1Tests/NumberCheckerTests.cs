using AdventCode20;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day1Tests.NumberCheckerTests
{
    [TestFixture]
    public class When_checking_number_with_acceptable_value_two_values
    {
        private const int firstNumber = 1721;
        private const int secondNumber = 299;

        [Test]
        public void Then_the_correct_number_is_returned()
        {
            Assume.That(firstNumber+secondNumber, Is.EqualTo(2020));
            Assume.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber}, out var testValue), Is.True);
            Assert.That(testValue, Is.EqualTo(firstNumber * secondNumber));
        }
        
        [Test]
        public void Then_the_result_is_true()
        {
            Assume.That(firstNumber+secondNumber, Is.EqualTo(2020));
            Assert.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber}, out _), Is.True);
        }
    }
    
    
    [TestFixture]
    public class When_checking_number_with_unacceptable_value_two_values
    {
        private const int firstNumber = 1;
        private const int secondNumber = 299;

        [Test]
        public void Then_the_correct_number_is_not_returned()
        {
            Assume.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber}, out var testValue), Is.False);
            Assert.That(testValue, Is.Null);
        }
        
        [Test]
        public void Then_the_result_is_false()
        {
            Assert.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber}, out _), Is.False);
        }
    }
    
    [TestFixture]
    public class When_checking_number_with_acceptable_value_three_values
    {
        private const int firstNumber = 979;
        private const int secondNumber = 366;
        private const int thirdNumber = 675;

        [Test]
        public void Then_the_correct_number_is_returned()
        {
            Assume.That(firstNumber+secondNumber, Is.EqualTo(2020));
            Assume.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber, thirdNumber}, out var testValue), Is.True);
            Assert.That(testValue, Is.EqualTo(firstNumber * secondNumber * thirdNumber));
        }
        
        [Test]
        public void Then_the_result_is_true()
        {
            Assume.That(firstNumber+secondNumber, Is.EqualTo(2020));
            Assert.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber, thirdNumber}, out _), Is.True);
        }
    }
    
    
    [TestFixture]
    public class When_checking_number_with_unacceptable_value_three_values
    {
        private const int firstNumber = 1;
        private const int secondNumber = 299;
        private const int thirdNumber = 2991;

        [Test]
        public void Then_the_correct_number_is_not_returned()
        {
            Assume.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber, thirdNumber}, out var testValue), Is.False);
            Assert.That(testValue, Is.Null);
        }
        
        [Test]
        public void Then_the_result_is_false()
        {
            Assert.That(NumberChecker.TryGetCombinedNumberWhenAddingTo2020(new []{firstNumber, secondNumber, thirdNumber}, out _), Is.False);
        }
    }
}