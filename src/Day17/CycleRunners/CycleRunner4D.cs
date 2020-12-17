using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day17.CycleRunners
{
    public class CycleRunner4D : ICycleRunner
    {
        private static IEnumerable<PocketDimension> GetNewMatrix(PocketDimension[] pocketDimensions)
        {
            var newEntries = new List<PocketDimension>();

            foreach (var pocketDimension in pocketDimensions)
            {
                var vectorsToCheck = GetVectorsToCheck(pocketDimension.Position4);
                
                newEntries.AddRange(vectorsToCheck.Where(v => pocketDimensions.All(p => p.Position4 != v)  && newEntries.All(p => p.Position4 != v))
                    .Select(v => new PocketDimension(v, false)));
                
                newEntries.Add(new PocketDimension(pocketDimension.Position4, pocketDimension.Active));
            }

            return newEntries;
        }

        private static IEnumerable<Vector4> GetVectorsToCheck(Vector4 vector)
        {
            var checkRange = new[] {-1, 0, 1};

            return (from x in checkRange
                from y in checkRange
                from z in checkRange
                from w in checkRange
                where x != 0 || y != 0 || z != 0 || w!=0
                select new Vector4(vector.X + x, vector.Y + y, vector.Z + z, vector.W + w)).ToList();
        }

        public IEnumerable<PocketDimension> Run(IEnumerable<PocketDimension> pocketDimensions)
        {
            var newPocketDimensions = GetNewMatrix(pocketDimensions.ToArray()).ToArray();

            foreach (var pocketDimension in newPocketDimensions)
            {
                var vectorsToCheck = GetVectorsToCheck(pocketDimension.Position4);
                var count = pocketDimensions.Where(p => vectorsToCheck.Any(v => v == p.Position4)).Count(p => p.Active);

                if (pocketDimension.Active && !(count == 2 || count == 3))
                {
                    pocketDimension.Active = false;
                }

                if (!pocketDimension.Active && count == 3)
                {
                    pocketDimension.Active = true;
                }
            }

            return newPocketDimensions.Where(p => p.Active);
        }
    }
}