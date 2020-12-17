using System.Collections.Generic;

namespace Day17.CycleRunners
{
    public interface ICycleRunner
    {
        IEnumerable<PocketDimension> Run(IEnumerable<PocketDimension> pocketDimensions);
    }
}