using System.Collections.Generic;

namespace Day7
{
    public interface IBag
    {
        string BagName { get; }
        IEnumerable<IBag>Contents { get; }
        int NumberOfBagsInTheContextsRecursive { get; }
        bool ContainsAGoldBag { get; }
    }
}