using Day18;
using Moq;
using NUnit.Framework;
using Tools;

namespace Day18Tests.InputCheckerTests
{
    [TestFixture]
    public class When_running_input_checker_with_example_values
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[]
            {
                @"((8 + 6 + 4 + 9 * 2 + 9) * 8 + 2 * (7 + 2 + 4 * 2 + 4) * 2 * 5) * 3",
                @"3 * 8 * 2 + 9 * ((6 + 5 * 3) * 7 * 9 * 7 * 7) * (7 * 4 + 5 + 8 * 8)",
                @"9 + (5 * 5 + 2 + (5 * 2 + 6 * 9 * 3 + 6) * 4) + 3 * 5",
                @"6 + (8 * 5 * 3 + 9 + 3 * 4) + 9 + 3 * 3",
                @"(8 + 8 * 4 + 3 + 6) + (4 + 3 * 7 + 7 + 4 + 2) + 7 + (3 + (2 * 8 + 7 + 7) * 7 + 5 * (3 * 2 + 9 + 2 + 8 + 7) * (4 + 2 + 8))",
                @"7 + 6 + 9 * 8 * 7 * 3) + (4 + 5 * (2 * 8 * 2 * 5 + 4) + (2 + 8 + 4 * 3 + 3) * (6 * 6 * 7 + 4 * 2 * 7)) * 6 + 9",
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);

            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part1_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo("1937869227"));
        }

        // [Test]
        // public void Then_output_value_for_part2_is_correct()
        // {
        //     Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo("848"));
        // }
    }
}