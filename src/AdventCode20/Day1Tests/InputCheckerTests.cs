using System;
using AdventCode20;
using Tools;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day1Tests.NumberCheckerTests.InputCheckerTests
{
    [TestFixture]
    public class When_running_input_checker_with_example_values_for_part1
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[] {"1721", "979","366","299","675","1456"};
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo(514579));
        }
    }
    
    [TestFixture]
    public class When_running_input_checker_with_input_with_no_correct_values_for_part1
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[] {"1722", "979","366","299","675","1456"};
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_error_is_thrown()
        {
            var message = Assert.Throws<Exception>(() => _sut.CheckInputToGetAnswerPart1());
            Assert.That(message.Message, Is.EqualTo("No values in the input combine to 2020"));
        }
    }
    [TestFixture]
    public class When_running_input_checker_with_example_values_for_part2
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[] {"1721", "979","366","299","675","1456"};
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo(241861950));
        }
    }
    
    [TestFixture]
    public class When_running_input_checker_with_input_with_no_correct_values_for_part2
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[] {"1721", "1","366","299","675","1456"};
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_error_is_thrown()
        {
            var message = Assert.Throws<Exception>(() => _sut.CheckInputToGetAnswerPart2());
            Assert.That(message.Message, Is.EqualTo("No values in the input combine to 2020"));
        }
    }
}