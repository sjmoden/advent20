using System.Drawing;
using Day12;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day12Tests.ShipTests
{
    [TestFixture]
    public class When_checking_taxicab_distance
    {
        [Test]
        public void Then_the_distance_is_correct()
        {
            var shipMover = new Mock<IShipMover>();
            shipMover.Setup(s => s.GetPosition()).Returns(new Point(-5,5));
            var ship = new Ship(shipMover.Object).SetUpShip(new Point(1,1));
            Assert.That(ship.GetTaxicabDistance(), Is.EqualTo(10));
        }
    }
}