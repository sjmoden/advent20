using System.Drawing;
using Day12;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day12Tests.ShipMoverUsingWaypointTests
{
    [TestFixture]
    public class When_moving_the_ship
    {
        [Test]
        public void Then_the_ship_moves_east()
        {
            const int distance = 5;
            var shipMover = new ShipMoverUsingWaypoint();
            shipMover.InitialisePosition(new Point(0, 0));
            shipMover.MoveEast(distance);
            shipMover.MoveForward(1);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(10+distance, 1)));
        }

        [Test]
        public void Then_the_ship_moves_north()
        {
            const int distance = 5;
            var shipMover = new ShipMoverUsingWaypoint();
            shipMover.InitialisePosition(new Point(0, 0));
            shipMover.MoveNorth(distance);
            shipMover.MoveForward(1);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(10, 1 + distance)));
        }

        [Test]
        public void Then_the_ship_moves_south()
        {
            const int distance = 5;
            var shipMover = new ShipMoverUsingWaypoint();
            shipMover.InitialisePosition(new Point(0, 0));
            shipMover.MoveSouth(distance);
            shipMover.MoveForward(1);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(10, 1-distance)));
        }

        [Test]
        public void Then_the_ship_moves_west()
        {
            const int distance = 5;
            var shipMover = new ShipMoverUsingWaypoint();
            shipMover.InitialisePosition(new Point(0, 0));
            shipMover.MoveWest(distance);
            shipMover.MoveForward(1);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(10 - distance, 1)));
        }

        [Test]
        public void Then_the_ship_moves_forward()
        {
            const int distance = 5;
            var shipMover = new ShipMoverUsingWaypoint();
            shipMover.InitialisePosition(new Point(0, 0));
            shipMover.MoveForward(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(50, 5)));
        }

        [Test]
        public void Then_the_ship_moves_forward_after_rotation_left()
        {
            //the ship starts facing east
            const int distance = 5;
            var shipMover = new ShipMoverUsingWaypoint();
            shipMover.InitialisePosition(new Point(0, 0));
            shipMover.RotateLeft(270);
            shipMover.MoveForward(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(5, -50)));
        }

        [Test]
        public void Then_the_ship_moves_forward_after_rotation_right()
        {

            const int distance = 5;
            var shipMover = new ShipMoverUsingWaypoint();
            shipMover.InitialisePosition(new Point(0, 0));
            shipMover.RotateRight(270);
            shipMover.MoveForward(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(-5, 50)));
        }
    }
}