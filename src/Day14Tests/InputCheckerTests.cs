using Day14;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day14Tests.InputCheckerTests
{
    [TestFixture]
    public class When_running_input_checker_with_example_values_part1
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[]
            {
                @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                @"mem[8] = 11",
                @"mem[7] = 101",
                @"mem[8] = 0"
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part1_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo("165"));
        }
    }
    
    [TestFixture]
    public class When_running_input_checker_with_example_values_part2
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[]
            {
                @"mask = 000000000000000000000000000000X1001X",
                @"mem[42] = 100",
                @"mask = 00000000000000000000000000000000X0XX",
                @"mem[26] = 1"
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part2_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo("208"));
        }
    }
}