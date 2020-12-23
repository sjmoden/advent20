using System.Collections.Generic;
using System.Linq;
using Day23;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day23Tests.CupCollectionTests
{
    public class When_using_cup_collection
    {
        private CupCollection _sut = new CupCollection(new List<int> {5, 8, 3, 7, 4, 1, 9, 2, 6});
        
        [Test]
        public void Then_output_cups_is_correct()
        {
            Assert.That(_sut.OutputCups(), Is.EqualTo("92658374"));
        }

        [Test]
        public void Then_TakeValue_returns_correct_value()
        {
            Assert.That(_sut.TakeValue(2),Is.EqualTo(8));
        }

        [Test]
        public void Then_TakeNextThree_returns_correct_value()
        {
            Assert.That(_sut.TakeNextThree(2).SequenceEqual(new List<int>{3,7,4}),Is.True);
        }

        [Test]
        public void Then_PutListIntoCupCollectionAndReturnNewCollection_returns_correct_cups()
        {
            Assert.That(_sut.PutListIntoCupCollectionAndReturnNewCollection(6, out _).OutputCups(), Is.EqualTo("58926374"));
        }
    }
}