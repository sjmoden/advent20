using Day22;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day22Tests.InputCheckerTests
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
                "Player 1:",
                "9",
                "2",
                "6",
                "3",
                "1",
                "",
                "Player 2:",
                "5",
                "8",
                "4",
                "7",
                "10",
                ""
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);

            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part1_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo("306"));
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
                "Player 1:",
                "9",
                "2",
                "6",
                "3",
                "1",
                "",
                "Player 2:",
                "5",
                "8",
                "4",
                "7",
                "10",
                ""
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);

            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part2_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo("291"));
        }
    }
}