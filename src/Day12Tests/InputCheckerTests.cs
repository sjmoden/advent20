

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

using Day12;
using Moq;
using NUnit.Framework;
using Tools;

namespace Day12Tests.InputCheckerTests
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
                @"F10",
                @"N3",
                @"F7",
                @"R90",
                @"F11"
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object, new Ship(new ShipMover()), new Ship(new ShipMoverUsingWaypoint()));
        }

        [Test]
        public void Then_output_value_for_part1_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo("25"));
        }

        [Test]
        public void Then_output_value_for_part2_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart2(), Is.EqualTo("286"));
        }
    }
}