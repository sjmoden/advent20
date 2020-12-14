using Day13;
using Moq;
using NUnit.Framework;
using Tools;


// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day13Tests
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
                @"939",
                @"7,13,x,x,59,x,31,19"
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
        }

        [Test]
        public void Then_output_value_for_part1_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo("295"));
        }
    }
    
    [TestFixture]
    public class When_running_input_checker_with_example_values_part2
    {
        private InputChecker _sut;

        private  string[] _input ;


        [TestCase("17,x,13,19","3417")]
        [TestCase("67,7,59,61 ","754018")]
        [TestCase("67,x,7,59,61","779210")]
        [TestCase("67,7,x,59,61","1261476")]
        [TestCase("1789,37,47,1889","1202161486")]
        public void Then_output_value_for_part2_is_correct(string input, string result)
        {
            _input = new[] {string.Empty, input};
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(_input);
            
            _sut = new InputChecker(mockPuzzleInput.Object);
            
            Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo(result));
        }
    }
}