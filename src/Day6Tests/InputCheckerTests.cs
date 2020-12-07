using Day6;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day6Tests
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
                "abc",
                "a\nb\nc",
                "ab\nac",
                "a\na\na\na",
                "b"
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>(),It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part1_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo("11"));
        }

        [Test]
        public void Then_output_value_for_part2_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo("6"));
        }
    }
}