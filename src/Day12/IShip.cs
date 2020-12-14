using System.Drawing;

namespace Day12
{
    public interface IShip
    {
        Ship SetUpShip(Point startingPosition);
        int GetTaxicabDistance();
    }
}