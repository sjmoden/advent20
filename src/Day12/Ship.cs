using System;
using System.Drawing;

namespace Day12
{
    public class Ship:IShip
    {
        public readonly IShipMover ShipMover;
        private Point _startingPosition;

        public Ship(IShipMover shipMover)
        {
            ShipMover = shipMover;
        }

        public Ship SetUpShip(Point startingPosition)
        {
            _startingPosition = startingPosition;
            ShipMover.InitialisePosition(startingPosition);
            return this;
        }

        public int GetTaxicabDistance()
        {
            return Math.Abs(ShipMover.GetPosition().X - _startingPosition.X)  + Math.Abs(ShipMover.GetPosition().Y - _startingPosition.Y);
        }
    }
}