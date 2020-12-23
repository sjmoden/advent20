using Day22;
using Moq;
using NUnit.Framework;
using Tools;

namespace Day22Tests.Hand
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
    [TestFixture]
    public class When_running_input_checker_with_example_values_part2_stuck_in_loop
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[]
            {
                "Player 1:",
                "43",
                "19",
                "",
                "Player 2:",
                "2",
                "29",
                "14",
                ""
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);

            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part2_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo("105"));
        }
    }
}