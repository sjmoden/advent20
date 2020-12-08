using Day8;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day8Test.BootCommandParserTests
{
    
    [TestFixture("nop +0",true,BootCommand.NoOperation,0)]
    [TestFixture("acc +3",true,BootCommand.Accumulate,3)]
    [TestFixture("acc -3",true,BootCommand.Accumulate,-3)]
    [TestFixture("jmp -5",true,BootCommand.Jump,-5)]
    [TestFixture("jmp +5",true,BootCommand.Jump,5)]
    [TestFixture("pn +5",false,default(BootCommand),default(int))]
    public class When_parsing_inputs
    {
        private readonly string _input;
        private readonly bool _result;
        private readonly BootCommand _command;
        private readonly int _argument;
        public When_parsing_inputs(string input, bool result, BootCommand command, int argument)
        {
            _input = input;
            _result = result;
            _command = command;
            _argument = argument;
        }

        [Test]
        public void Then_the_return_value_is_correct()
        {
            Assert.That(BootCommandParser.TryParse(_input, out _, out _),Is.EqualTo(_result));
        }

        [Test]
        public void Then_the_command_is_correct()
        {
            BootCommandParser.TryParse(_input, out var command, out _);
            Assert.That(command,Is.EqualTo(_command));
        }

        [Test]
        public void Then_the_argument_is_correct()
        {
            BootCommandParser.TryParse(_input, out var _, out var argument);
            Assert.That(argument,Is.EqualTo(_argument));
        }
    }
}