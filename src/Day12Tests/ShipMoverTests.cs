using System.Drawing;
using Day12;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day12Tests.ShipMoverTests
{
    [TestFixture]
    public class When_moving_the_ship
    {
        [Test]
        public void Then_the_ship_moves_east()
        {
            const int distance = 5;
            var shipMover = new ShipMover();
            shipMover.InitialisePosition(new Point(0,0));
            shipMover.MoveEast(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(distance, 0)));
        }
        
        [Test]
        public void Then_the_ship_moves_north()
        {
            const int distance = 5;
            var shipMover = new ShipMover();
            shipMover.InitialisePosition(new Point(0,0));
            shipMover.MoveNorth(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(0, distance)));
        }
        
        [Test]
        public void Then_the_ship_moves_south()
        {
            const int distance = 5;
            var shipMover = new ShipMover();
            shipMover.InitialisePosition(new Point(0,0));
            shipMover.MoveSouth(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(0, -1 * distance)));
        }
        
        [Test]
        public void Then_the_ship_moves_west()
        {
            const int distance = 5;
            var shipMover = new ShipMover();
            shipMover.InitialisePosition(new Point(0,0));
            shipMover.MoveWest(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(-1 * distance,0)));
        }
        
        [Test]
        public void Then_the_ship_moves_forward()
        {
            //the ship starts facing east
            const int distance = 5;
            var shipMover = new ShipMover();
            shipMover.InitialisePosition(new Point(0,0));
            shipMover.MoveForward(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(distance,0)));
        }
        
        [Test]
        public void Then_the_ship_moves_forward_after_rotation_left()
        {
            //the ship starts facing east
            const int distance = 5;
            var shipMover = new ShipMover();
            shipMover.InitialisePosition(new Point(0,0));
            shipMover.RotateLeft(270);
            shipMover.MoveForward(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(0,-1 * distance)));
        }
        
        [Test]
        public void Then_the_ship_moves_forward_after_rotation_right()
        {
            //the ship starts facing east
            const int distance = 5;
            var shipMover = new ShipMover();
            shipMover.InitialisePosition(new Point(0,0));
            shipMover.RotateRight(270);
            shipMover.MoveForward(distance);
            Assert.That(shipMover.GetPosition(), Is.EqualTo(new Point(0,distance)));
        }
    }
}