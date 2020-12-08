using Day8;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day8Test.BootTests
{
    
    [TestFixture(BootCommand.Jump,5,5,0)]
    [TestFixture(BootCommand.Accumulate,5,1,5)]
    [TestFixture(BootCommand.NoOperation,0,1,0)]
    public class When_parsing_inputs
    {
        private readonly BootCommand _command;
        private readonly int _argument;
        private readonly int _positionExpected;
        private readonly int _accumulatorExpected;
        private int _position;
        private int _accumulator;
        
        public When_parsing_inputs(BootCommand command, int argument, int positionExpected, int accumulatorExpected)
        {
            _command = command;
            _argument = argument;
            _positionExpected = positionExpected;
            _accumulatorExpected = accumulatorExpected;
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            Boot.ExecuteSingle(_command, ref _position, ref _accumulator, _argument);
        }
        

        [Test]
        public void Then_position_is_correct()
        {
            Assert.That(_position, Is.EqualTo(_positionExpected));
        }

        [Test]
        public void Then_accumulator_is_correct()
        {
            Assert.That(_accumulator, Is.EqualTo(_accumulatorExpected));
        }
    }
    
    [TestFixture]
    public class When_running_try_execute_with_infinite_loop
    {
        private bool _output;
        private int _accumulatorValue;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            _output = Boot.TryExecute(inputArray, out _accumulatorValue);
        }

        [Test]
        public void Then_output_is_correct()
        {
            Assert.That(_output, Is.EqualTo(false));
        }

        [Test]
        public void Then_accumulator_is_correct()
        {
            Assert.That(_accumulatorValue, Is.EqualTo(5));
        }
    }
    
    [TestFixture]
    public class When_running_try_execute_with_finite_loop
    {
        private bool _output;
        private int _accumulatorValue;

        [SetUp]
        public void SetUp()
        {
            var inputArray = new[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "nop -4",
                "acc +6"
            };

            _output = Boot.TryExecute(inputArray, out _accumulatorValue);
        }

        [Test]
        public void Then_output_is_correct()
        {
            Assert.That(_output, Is.EqualTo(true));
        }

        [Test]
        public void Then_accumulator_is_correct()
        {
            Assert.That(_accumulatorValue, Is.EqualTo(8));
        }
    }
}