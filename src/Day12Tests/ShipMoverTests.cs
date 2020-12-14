using System;
using System.Drawing;
using Day12;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day12Tests.ShipMoverTests
{
    [TestFixture]
    public class When_moving_the_ship_east
    {
        [Test]
        public void Then_the_ship_moves_east()
        {
            const int distance = 5;
            var shipMover = new ShipMover();
            var position = shipMover.Move(Direction.East, distance, new Point(0, 0));
            Assert.That(position, Is.EqualTo(new Point(distance, 0)));
        }
    }
    
    [TestFixture]
    public class When_moving_the_ship_north
    {
        [Test]
        public void Then_the_ship_moves_north()
        {
            const int distance = 5;
            var shipMover = new ShipMover();
            var position = shipMover.Move(Direction.North, distance, new Point(0, 0));
            Assert.That(position, Is.EqualTo(new Point(0, distance)));
        }
    }
    
    [TestFixture]
    public class When_moving_the_ship_west
    {
        [Test]
        public void Then_the_ship_moves_west()
        {
            const int distance = -5;
            var shipMover = new ShipMover();
            var position = shipMover.Move(Direction.West, Math.Abs(distance), new Point(0, 0));
            Assert.That(position, Is.EqualTo(new Point(distance, 0)));
        }
    }
    
    [TestFixture]
    public class When_moving_the_ship_south
    {
        [Test]
        public void Then_the_ship_moves_south()
        {
            const int distance = -5;
            var shipMover = new ShipMover();
            var position = shipMover.Move(Direction.South, Math.Abs(distance), new Point(0, 0));
            Assert.That(position, Is.EqualTo(new Point(0, distance)));
        }
    }

    [TestFixture]
    public class When_rotating
    {
        [TestCase(0,true, Direction.North)]
        [TestCase(90,true, Direction.West)]
        [TestCase(180,true, Direction.South)]
        [TestCase(270,true, Direction.East)]
        [TestCase(0,false, Direction.North)]
        [TestCase(90,false, Direction.East)]
        [TestCase(180,false, Direction.South)]
        [TestCase(270,false, Direction.West)]
        public void Then_the_rotation_is_correct(int degrees, bool rotateLeft, Direction expectedResult)
        {
            var shipMover = new ShipMover();
            Assert.That(shipMover.Rotate(Direction.North, degrees, rotateLeft), Is.EqualTo(expectedResult));
        }
    }
}