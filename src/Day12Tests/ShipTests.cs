using System.Drawing;
using Day12;
using Moq;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day12Tests.ShipTests
{
    [TestFixture]
    public class When_changing_direction_and_moving_forward
    {
        private Ship _ship ;
        private const Direction NewDirection = Direction.North;
        private Mock<IShipMover> _shipMover = new Mock<IShipMover>();
        private int _distance = 5;

        [OneTimeSetUp]
        public void Setup()
        {
            _ship = new Ship(_shipMover.Object);
            Assume.That(_ship.Direction, Is.EqualTo(Direction.East));
            _ship.ChangeDirection(NewDirection);
            _ship.MoveForward(_distance);
        }

        [Test]
        public void That_direction_is_changed_correctly()
        {
            Assert.That(_ship.Direction, Is.EqualTo(NewDirection));
        }

        [Test]
        public void Then_the_move_is_made()
        {
            _shipMover.Verify(m => m.Move(NewDirection, _distance, It.IsAny<Point>()), Times.Once);
        }
    }

    [TestFixture]
    public class When_checking_taxicab_distance
    {
        [Test]
        public void Then_the_distance_is_correct()
        {
            var ship = new Ship(new Mock<IShipMover>().Object);
            ship.Position = new Point(-5,5);
            Assert.That(ship.GetTaxicabDistance(), Is.EqualTo(10));
        }
    }
}