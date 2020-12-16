using Day16;
using Moq;
using NUnit.Framework;
using Tools;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day16Tests.InputCheckerTests
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
                @"class: 1-3 or 5-7",
                @"row: 6-11 or 33-44",
                @"seat: 13-40 or 45-50",
                @" ",
                @"your ticket:",
                @" ",
                @"7,1,14",
                @" ",
                @"nearby tickets:",
                @"7,3,47",
                @"40,4,50",
                @"55,2,20",
                @"38,6,12"
            };
            
            var mockPuzzleInput = new Mock<IPuzzleInput>();
            mockPuzzleInput.Setup(p => p.GetPuzzleInputAsArray(It.IsAny<string>())).Returns(inputArray);
            
            _sut = new InputChecker(mockPuzzleInput.Object, new TicketValidator());
        }

        [Test]
        public void Then_output_value_for_part1_is_correct()
        {
            Assert.That(_sut.CheckInputToGetAnswerPart1(), Is.EqualTo("71"));
        }
    }
}