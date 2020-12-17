using System.Numerics;

namespace Day17
{
    public class PocketDimension
    {
        public readonly Vector3 Position3;
        public readonly Vector4 Position4;
        public bool Active;

        public PocketDimension(Vector4 position, bool active)
        {
            Position4 = position;
            Active = active;
        }
        
        public PocketDimension(Vector3 position, bool active)
        {
            Position3 = position;
            Active = active;
        }
    }
}