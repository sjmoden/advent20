using System.Linq;
using Day7;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day7Tests.BagTests
{
    [TestFixture]
    public class When_creating_a_bag
    {
        private IBag _sut;
        
        private readonly string[] _inputArray =
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        [SetUp]
        public void SetUp()
        {
            var mockRules = new Mock<IRules>();
            mockRules.Setup(r => r.Rules).Returns(_inputArray);
            _sut=  new Bag("light red bags contain 1 bright white bag, 2 muted yellow bags.", mockRules.Object);
        }

        [Test]
        public void Then_bag_name_is_correct()
        {
            Assert.That(_sut.BagName, Is.EqualTo("light red"));
        }
        
        [Test]
        public void Then_bag_contains_one_bright_white_bag()
        {
            Assert.That(_sut.Contents.Count(c => c.BagName.Equals("bright white")), Is.EqualTo(1));
        }
        
        [Test]
        public void Then_bag_contains_two_muted_yellow_bags()
        {
            Assert.That(_sut.Contents.Count(c => c.BagName.Equals("muted yellow")), Is.EqualTo(2));
        }
        
        [Test]
        public void Then_ContainsAGoldBag_is_true()
        {
            Assert.That(_sut.ContainsAGoldBag, Is.True);
        }
        
        [Test]
        public void Then_NumberOfBagsRecursive_is_correct()
        {
            Assert.That(_sut.NumberOfBagsInTheContextsRecursive, Is.EqualTo(186));
        }
    }
}