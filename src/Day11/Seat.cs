using System;
using System.Drawing;

namespace Day11
{
    public class Seat
    {
        public Point Position;
        public SeatStatus Status;

        public Seat CreateSeat(SeatStatus status, Point position)
        {
            Position = position;
            Status = status;
            return this;
        }
        
        public Seat CreateSeat(char status, Point position)
        {
            Position = position;
            switch (status)
            {
                case 'L':
                    Status = SeatStatus.Empty;
                    break;
                case '#':
                    Status = SeatStatus.Occupied;
                    break;
                case '.':
                    return null;
                default:
                    throw new ArgumentException($"Status not recognised: {status}");

            }
            
            return this;
        }
    }
}