using System.Collections.Generic;
using System.Linq;
using Day9;
using NUnit.Framework;


// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day9Tests.XmasValidatorTests
{
    [TestFixture]
    public class When_running_Validate_with_values
    {

        [TestCase(40,new long[]{35,20,15,25,47}, true)]
        [TestCase(60,new long[]{30,30,15,25,47}, true)]
        [TestCase(60,new long[]{30,42,15,25,47}, false)]
        [TestCase(127,new long[]{95,102,117,150,182}, false)]
        public void Then_the_return_is_correct(int checkValue, IEnumerable<long> preAmble ,bool expectedResult)
        {
            Assert.That(XmasValidator.Validate(checkValue,preAmble), Is.EqualTo(expectedResult));
        }
    }

    [TestFixture]
    public class When_running_TryGetFirstInvalid_with_example_failing
    {
        private bool _returnValue;
        private long _firstValue;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576
            };
            _returnValue = XmasValidator.TryGetFirstInvalid(inputArray, 5, out _firstValue);
        }

        [Test]
        public void Then_return_value_is_correct()
        {
            Assert.That(_returnValue, Is.EqualTo(true));
        }

        [Test]
        public void Then_first_value_is_correct()
        {
            Assert.That(_firstValue, Is.EqualTo(127));
        }
    }

    [TestFixture]
    public class When_running_TryGetFirstInvalid_with_example_passing
    {
        private bool _returnValue;
        private long _firstValue;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new long[]
            {
                35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 219, 219, 299, 369, 438, 807
            };
            _returnValue = XmasValidator.TryGetFirstInvalid(inputArray, 5, out _firstValue);
        }

        [Test]
        public void Then_return_value_is_correct()
        {
            Assert.That(_returnValue, Is.EqualTo(false));
        }

        [Test]
        public void Then_first_value_is_correct()
        {
            Assert.That(_firstValue, Is.EqualTo(default(int)));
        }
    }

    [TestFixture]
    public class When_running_TryGetContiguousSet_with_example
    {
        [TestFixture]
        public class When_running_TryGetFirstInvalid_with_example_passing
        {
            private bool _returnValue;
            private List<long> _contiguousSet;

            [OneTimeSetUp]
            public void SetUp()
            {
                var inputArray = new long[]
                {
                    35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576
                };
                _returnValue = XmasValidator.TryGetContiguousSet(inputArray, 127, out _contiguousSet);
            }

            [Test]
            public void Then_return_value_is_correct()
            {
                Assert.That(_returnValue, Is.EqualTo(true));
            }

            [Test]
            public void Then_contiguous_set_is_correct()
            {
                Assert.That(_contiguousSet.SequenceEqual(new List<long>(){15,25,47,40}), Is.True);
            }
        }
    }
}