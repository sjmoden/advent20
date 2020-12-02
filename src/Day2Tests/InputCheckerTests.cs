using Day2;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day2Tests.InputCheckerTests
{
    [TestFixture]
    public class When_running_input_checker_with_example_values_for_part1
    {
        private InputChecker _sut;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[] {"1-3 a: abcde", "1-3 b: cdefg","2-9 c: ccccccccc"};
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo(2));
        }
    }
}