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
}