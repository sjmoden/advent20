using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Day17.InputParsers
{
    public class InputParser3D:IInputParser
    {
        public IEnumerable<PocketDimension> ParseInput(string[] input)
        {
            for (var y = 0; y < input.Count(); y++)
            {
                var valuesInLine = input[y];
                for (var x = 0; x < valuesInLine.Length; x++)
                {
                    if (valuesInLine[x] == '#')
                    {
                        yield return new PocketDimension(new Vector3(x,y,0), true);                        
                    }
                }
            }
        }
    }
}