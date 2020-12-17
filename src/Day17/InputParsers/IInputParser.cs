using System.Collections.Generic;

namespace Day17.InputParsers
{
    public interface IInputParser
    {
        IEnumerable<PocketDimension> ParseInput(string[] input);
    }
}