using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day20
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/20/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            var tiles = new List<Tile>();
            var tile = new Tile();
            var tileData = new List<string>();
            foreach (var line in Input)
            {
                if (line.StartsWith("Tile", StringComparison.InvariantCultureIgnoreCase))
                {
                    tile.ReadId(line);
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    tile.ReadTile(tileData);
                    tileData = new List<string>();
                    tiles.Add(tile);
                    tile = new Tile();
                    continue;
                }
                
                tileData.Add(line);
                
            }

            var tileInfo = new List<(int countOfMatches, long Id)>();
            foreach (var tileToReview in tiles)
            {
                tileInfo.Add((GetCountOfMatches(tiles, tileToReview), tileToReview.Id));
            }

            return tileInfo.Where(t => t.countOfMatches == 2).Select(t => t.Id).Aggregate((a,b)=> a*b).ToString();
        }

        private static int GetCountOfMatches(List<Tile> tiles, Tile tileToReview)
        {
            var count = 0;
            foreach (var tileToCompare in tiles)
            {
                if (count == 4)
                {
                    return count;
                }
                
                if (tileToReview.Id == tileToCompare.Id)
                {
                    continue;
                }

                if (tileToReview.OneEdgeMatches(tileToCompare))
                {
                    count++;
                }
            }

            return count;
        }

        public string CheckInputToGetAnswerPart2()
        {
            throw new System.NotImplementedException();
        }
        
        private string[] _input;
        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}