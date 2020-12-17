using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Day17;
using Day17.InputParsers;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day17Tests.InputParserTests
{
    [TestFixture]
    public class When_running_parse_3D
    {
        private readonly string[] input =
        {
            @".#.",
            @"..#",
            @"###",
        };

        private IEnumerable<PocketDimension> _pocketDimensions;

        [OneTimeSetUp]
        public void SetUp()
        {
            _pocketDimensions = new InputParser3D().ParseInput(input);
        }

        [Test]
        public void Then_the_correct_amount_is_returned()
        {
            Assert.That(_pocketDimensions.Count(), Is.EqualTo(5));
        }
        
        [Test]
        public void Then_an_active_value_is_correct()
        {
            Assert.That(_pocketDimensions.SingleOrDefault(s =>s.Position3 == new Vector3(1,0,0))?.Active, Is.True);
        }
    }
    
    [TestFixture]
    public class When_running_parse_4D
    {
        private readonly string[] input =
        {
            @".#.",
            @"..#",
            @"###",
        };

        private IEnumerable<PocketDimension> _pocketDimensions;

        [OneTimeSetUp]
        public void SetUp()
        {
            _pocketDimensions = new InputParser4D().ParseInput(input);
        }

        [Test]
        public void Then_the_correct_amount_is_returned()
        {
            Assert.That(_pocketDimensions.Count(), Is.EqualTo(5));
        }
        
        [Test]
        public void Then_an_active_value_is_correct()
        {
            Assert.That(_pocketDimensions.SingleOrDefault(s =>s.Position4 == new Vector4(1,0,0,0))?.Active, Is.True);
        }
    }
}