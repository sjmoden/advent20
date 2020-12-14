using System.Collections.Generic;
using System.Linq;
using Day14;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day14Tests.BitMaskerTests
{
    [TestFixture]
    public class When_applying_bitmask
    {
        [TestCase("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",11,73)]
        [TestCase("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",101,101)]
        [TestCase("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",0,64)]
        public void Then_correct_value_is_returned(string bitMask, int initialValue, int outValue)
        {
            Assert.That(BitMasker.ApplyBitmask(bitMask,initialValue), Is.EqualTo(outValue));
        }
    }

    [TestFixture]
    public class When_applying_ApplyMultipleBitMasks
    {
        private string _mask = "000000000000000000000000000000X1001X";
        private List<long> _output;
        
        [SetUp]
        public void SetUp()
        {
            _output = BitMasker.ApplyMultipleBitMasks(_mask,42).ToList();
        }

        [Test]
        public void The_output_is_correct()
        {
            Assert.That(_output.SequenceEqual(new long[]{26,27,58,59}),Is.True);
        }
    }

    [TestFixture]
    public class When_applying_ApplyMultipleBitMasks2
    {
        private string _mask = "00000000000000000000000000000000X0XX";
        private List<long> _output;
        
        [SetUp]
        public void SetUp()
        {
            _output = BitMasker.ApplyMultipleBitMasks(_mask,26).ToList();
        }

        [Test]
        public void The_output_is_correct()
        {
            Assert.That(_output.SequenceEqual(new long[]{16,17,18,19,24,25,26,27}),Is.True);
        }
    }
}