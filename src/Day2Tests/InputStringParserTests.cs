using Day2;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day2Tests.InputStringParserTests
{
    [TestFixture]
    public class When_running_TryParseString_on_valid_string
    {
        private bool _result;
        private string _password;
        private char _checkChar;
        private int _minValue;
        private int _maxValue;

        [SetUp]
        public void SetUp()
        {
            _result = InputStringParser.TryParseString("1-3 a: abcde", out _password, out _checkChar, out _minValue,
                out _maxValue);
        }

        [Test]
        public void Then_true_is_returned()
        {
            Assert.That(_result, Is.True);
        }

        [Test]
        public void Then_password_is_correct()
        {
            Assert.That(_password, Is.EqualTo("abcde"));
        }

        [Test]
        public void Then_check_char_is_correct()
        {
            Assert.That(_checkChar, Is.EqualTo('a'));
        }

        [Test]
        public void Then_max_value_is_correct()
        {
            Assert.That(_minValue, Is.EqualTo(1));
        }

        [Test]
        public void Then_min_value_is_correct()
        {
            Assert.That(_maxValue, Is.EqualTo(3));
        }
    }
    
    [TestFixture]
    public class When_running_TryParseString_on_invalid_string
    {
        //We could add more test for some cases, but that seems too much
        private bool _result;
        private string _password;
        private char _checkChar;
        private int _minValue;
        private int _maxValue;

        [SetUp]
        public void SetUp()
        {
            _result = InputStringParser.TryParseString("dsfdsfg:tttt?345", out _password, out _checkChar, out _minValue,
                out _maxValue);
        }

        [Test]
        public void Then_false_is_returned()
        {
            Assert.That(_result, Is.False);
        }

        [Test]
        public void Then_password_is_null()
        {
            Assert.That(_password, Is.Null);
        }

        [Test]
        public void Then_check_char_is_default()
        {
            Assert.That(_checkChar, Is.EqualTo(default(char)));
        }

        [Test]
        public void Then_max_value_is_default()
        {
            Assert.That(_minValue, Is.EqualTo(default(int)));
        }

        [Test]
        public void Then_min_value_is_default()
        {
            Assert.That(_maxValue, Is.EqualTo(default(int)));
        }
    }
}