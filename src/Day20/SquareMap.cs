using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day20
{
    public class SquareMap
    {
        private readonly Tile[,] _map;
        private readonly int _size;

        private IEnumerable<int> AlreadyMapped
        {
            get
            {
                for (var y = 0; y < _size; y++)
                {
                    for (var x = 0; x < _size; x++)
                    {
                        if (_map[y, x] == null)
                        {
                            continue;
                        }
                        
                        yield return _map[y,x].Id;
                    }
                } 
            }
        }

        public SquareMap(int size)
        {
            _size = size;
            _map = new Tile[size,size];
        }

        public IEnumerable<Tile> GetCorners()
        {
            return new List<Tile>
            {
                _map[0,0],
                _map[0,_size-1],
                _map[_size-1,0],
                _map[_size-1,_size-1]
            };
        }

        private List<string> GetMap()
        {
            var sizeOfInnerMaps = _map[0,0].Map.Count;
            var map = Enumerable.Range(0,_size * sizeOfInnerMaps).Select(s => string.Empty).ToList();
            for (var y = 0; y < _size; y++)
            {
                for (var x = 0; x < _size; x++)
                {
                    for (var z = 0; z < sizeOfInnerMaps; z++)
                    {
                        map[z+(y*sizeOfInnerMaps)]+= _map[y, x].Map[z];
                    }
                }    
            }

            return map;
        }

        public int RotateAndFindMonsters()
        {
            var numberOfMonsters = 0;
            var index = 0;
            var mapAsList = GetMap();
            while (numberOfMonsters == 0)
            {
                var rotation = index % 4;
                var flipVertical = index == 4 || index == 5 || index == 6 || index == 7 ;
                var flipHorizontal = index == 8 || index == 9 || index == 10 || index == 11;

                var map = Transformer.TransformList(mapAsList, rotation, flipHorizontal, flipVertical).ToList();
                
                numberOfMonsters = GetMonsters(map);
                index++;
            }
            return numberOfMonsters;
        }

        private int GetMonsters(List<string> fullMap)
        {
            var count = 0;
            for (var row = 2; row < fullMap.Count; row++)
            {
                var matches = Regex.Matches(fullMap[row], @".#.{2}#.{2}#.{2}#.{2}#.{2}#.{3}");
                foreach (Match match in matches)
                {
                    var startIndex = match.Index;
                    var bottomString = fullMap[row].Substring(startIndex, 20);
                    var middleString = fullMap[row - 1].Substring(startIndex, 20);
                    var topString = fullMap[row - 2].Substring(startIndex, 20);

                    if (Regex.IsMatch(topString, @".{18}#.") && Regex.IsMatch(middleString, @"#.{4}##.{4}##.{4}###"))
                    {
                        var topStringArray = topString.ToCharArray();
                        topStringArray[18] = 'O';
                        topString = new string(topStringArray);
                        
                        var middleStringArray = middleString.ToCharArray();
                        middleStringArray[0] = 'O';
                        middleStringArray[5] = 'O';
                        middleStringArray[6] = 'O';
                        middleStringArray[11] = 'O';
                        middleStringArray[12] = 'O';
                        middleStringArray[17] = 'O';
                        middleStringArray[18] = 'O';
                        middleStringArray[19] = 'O';
                        middleString = new string(middleStringArray);
                        
                        var bottomStringArray = bottomString.ToCharArray();
                        bottomStringArray[1] = 'O';
                        bottomStringArray[4] = 'O';
                        bottomStringArray[7] = 'O';
                        bottomStringArray[10] = 'O';
                        bottomStringArray[13] = 'O';
                        bottomStringArray[16] = 'O';
                        bottomString = new string(bottomStringArray);
                        
                        fullMap[row - 2] = $"{fullMap[row - 2].Substring(0,startIndex)}{topString}{fullMap[row - 2].Substring(startIndex+20)}";
                        fullMap[row - 1] = $"{fullMap[row - 1].Substring(0,startIndex)}{middleString}{fullMap[row - 1].Substring(startIndex+20)}";
                        fullMap[row] = $"{fullMap[row].Substring(0,startIndex)}{bottomString}{fullMap[row].Substring(startIndex+20)}";
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                return 0;
            }

            foreach (var row in fullMap)
            {
                Console.WriteLine(row);
            }
            
            return fullMap.SelectMany(s => s.ToCharArray()).Count(c => c == '#');
        }
        
        public void BuildMap(List<Tile> tiles)
        {
            var mapInfo = new List<(Tile Tile, List<Tile> LinkedTiles)>();
            foreach (var tileToReview in tiles)
            {
                AddToMapInfo(tiles, tileToReview, mapInfo);
            }

            var first = mapInfo.First(m => m.LinkedTiles.Count == 2);
            var right = first.LinkedTiles.First();
            var bottom = first.LinkedTiles.Last();
            first.Tile.GetCornerOrientation(right,bottom);
            _map[0, 0] = first.Tile.Copy();

            for (var y = 0; y < _size; y++)
            {
                for (var x = 0; x < _size; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    if (x == 1 && y == 1)
                    {
                        OrientateX1Y1BecauseItsFrigginFixesEverythingInPlace(mapInfo);
                    }

                    var matchToAbove = x == 0 || y == _size-1;
                    var previous = matchToAbove? _map[y-1,x]:_map[y, x - 1];
                    
                    var (_, linkedTiles) = mapInfo.Single(m => m.Tile.Id == previous.Id);

                    foreach (var linkedTile in linkedTiles.Where(l => !AlreadyMapped.Contains(l.Id)))
                    {
                        var success = linkedTile.GetOrientationFromSingleSide(matchToAbove ? Side.Top : Side.Left,
                            matchToAbove ? previous.BottomLine : previous.RightLine);
                        if (success)
                        {
                            _map[y, x] = linkedTile.Copy();
                            break;
                        }
                    }
                }
            }
            
            // for (var i = 1; i < _size; i++)
            // {
            //     var (tile, linkedTiles) = mapInfo.Single(m => m.Tile.Id == right.Id);
            //     tile.GetOrientationFromSingleSide(Side.Left, _map[0, i - 1].RightLine);
            //     _map[0, i] = tile;
            //     
            //     
            //     var sfs = mapInfo
            // }
        }

        private void OrientateX1Y1BecauseItsFrigginFixesEverythingInPlace(List<(Tile Tile, List<Tile> LinkedTiles)> mapInfo)
        {
            var above = _map[0,1];
            var left = _map[1,0];
                    
            var (_, linkedTilesAbove) = mapInfo.Single(m => m.Tile.Id == above.Id);
            var (_, linkedTilesLeft) = mapInfo.Single(m => m.Tile.Id == left.Id);
            var intercept = linkedTilesAbove.Where(la => !AlreadyMapped.Contains(la.Id)).Single(la => linkedTilesLeft.Any(ll => ll.Id == la.Id));
            var successAbove = intercept.GetOrientationFromSingleSide(Side.Top, above.BottomLine);
            if (!successAbove)
            {
                for (var x = 0; x < _size; x++)
                {
                    var tile = _map[0, x];
                    tile.FlipVertical = !tile.FlipVertical;
                }
            }
            
            var successLeft = intercept.GetOrientationFromSingleSide(Side.Left, left.RightLine);
            if (!successLeft)
            {
                for (var y = 0; y < 2; y++)
                {
                    var tile = _map[y,0];
                    tile.FlipHorizontal = !tile.FlipHorizontal;
                }
            }
        }
        
        private static void AddToMapInfo(List<Tile> tiles, Tile tileToReview, List<(Tile Tile, List<Tile> LinkedTiles)> mapInfo)
        {
            var count = 0;
            var linkedTiles = new List<Tile>(); 
            foreach (var tileToCompare in tiles)
            {
                if (count == 4)
                {
                    break;
                }
                
                if (tileToReview.Id == tileToCompare.Id)
                {
                    continue;
                }

                if (tileToReview.OneEdgeMatches(tileToCompare))
                {
                    linkedTiles.Add(tileToCompare);
                    count++;
                }
            }
            
            mapInfo.Add((tileToReview, linkedTiles));
        }
    }
}