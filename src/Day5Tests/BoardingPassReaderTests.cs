using System;
using Day5;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day5Tests.BoardingPassReaderTests
{
    [TestFixture]
    public class When_getting_boarding_pass_id_for_valid_entry
    {
        [Test]
        public void Then_the_id_is_correct()
        {
            Assert.That(BoardingPassReader.GetBoardingPassId("FBFBBFFRLR"), Is.EqualTo(357));
        }
    }
    
    [TestFixture]
    public class When_getting_boarding_pass_id_with_incorrect_values
    {
        [TestCase("FBFBBFFRLRR","The input must be exactly 10 characters long.")]
        [TestCase("FBFBBFFRL","The input must be exactly 10 characters long.")]
        [TestCase("FBRBBFFRLR","The input characters can only contain f or b.")]
        [TestCase("FBFBBFFFLR","The input characters can only contain l or r.")]
        public void Then_the_id_is_correct(string input, string errorMessage)
        {
            var error = Assert.Throws<ArgumentException>(() => BoardingPassReader.GetBoardingPassId(input));
            Assert.That(error.Message, Is.EqualTo(errorMessage));
        }
    }
}