﻿using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day20
{
    public class InputChecker:IInputChecker
    {
        //This might be one of the ugliest thing I have written in years.
        //It took a while to get a result and the code became more and more spag like while the days went on
        //I might come back and tidy it, but I probably will not want to look at this ever again
        
        private const string InputUrl = "https://adventofcode.com/2020/day/20/input";
        private readonly IPuzzleInput _puzzleInput;

        public InputChecker(IPuzzleInput puzzleInput)
        {
            _puzzleInput = puzzleInput;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            return Map.GetCorners().Select(t => (long)t.Id).Aggregate((a,b)=> a*b).ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            return Map.RotateAndFindMonsters().ToString();
        }

        private void PopulateMap()
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

            _map = new SquareMap((int) Math.Sqrt(tiles.Count));
            _map.BuildMap(tiles);
        }

        private SquareMap _map;

        private SquareMap Map
        {
            get
            {
                if (_map == null)
                {
                    PopulateMap();
                }

                return _map;
            }
        }
        
        private string[] _input;
        private IEnumerable<string> Input => _input ??= _puzzleInput.GetPuzzleInputAsArray(InputUrl);
    }
}