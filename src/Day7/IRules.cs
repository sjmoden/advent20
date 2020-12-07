using System.Collections.Generic;

namespace Day7
{
    public interface IRules
    {
        IEnumerable<string> Rules { get; }
    }
}