using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day20
{
    public class Tile
    {
        public int Id;

        private readonly List<string> _map = new List<string>();

        public List<string> Map
        {
            get
            {
                var transformed= Transformer.TransformList(_map, Rotation, FlipHorizontal, FlipVertical).ToList();
                
                var map = new List<string>();
                foreach (var row in transformed.Skip(1).Take(transformed.Count - 2))
                {
                    map.Add(row.Substring(1, transformed.Count - 2));
                }

                return map;
            }
        }


        private string _topLine;

        public Tile Copy()
        {
            return (Tile)MemberwiseClone();
        }
        
        public bool GetOrientationFromSingleSide(Side side, string value)
        {
            var index = 0;
            while (GetSide(side) != new string(value.ToCharArray().Reverse().ToArray()))
            {
                if (index == 12)
                {
                    return false;
                }
                RotationSetUp(index);
                index++;
            }

            return true;
        }

        private string GetSide(Side side)
        {
            switch (side)
            {
                case Side.Top:
                    return TopLine;
                case Side.Left:
                    return LeftLine;
                case Side.Right:
                    return RightLine;
                case Side.Bottom:
                    return BottomLine;
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), side, null);
            }
        }
        
        
        public void GetCornerOrientation(Tile right, Tile bottom)
        {
            //RightHandMatch
            var index = 0;
            var rightIndex = 0;
            while (RightLine != new string(right.LeftLine.ToCharArray().Reverse().ToArray()))
            {
                RotationSetUp(index);
                right.RotationSetUp(rightIndex);

                if (index % 12 == 11)
                {
                    rightIndex++;
                }
                
                index++;
            }
            
            index = 0;
            var bottomIndex = 0;
            while (bottom.TopLine != new string(BottomLine.ToCharArray().Reverse().ToArray()))
            {
                switch (index %2)
                {
                    case 0:
                        FlipHorizontal = false;
                        FlipVertical = false;
                        break;
                    case 1:
                        FlipHorizontal = false;
                        FlipVertical = true;
                        break;
                }
                
                bottom.RotationSetUp(bottomIndex);
                if (index % 2 == 1)
                {
                    bottomIndex++;
                }

                index++;
            }
        }
        
        

        public void RotationSetUp(int index)
        {
            Rotation = index % 4;
            FlipVertical = index == 4 || index == 5 || index == 6 || index == 7 ;
            FlipHorizontal = index == 8 || index == 9 || index == 10 || index == 11;
        }

        public bool OneEdgeMatches(Tile tileToMatch)
        {
            tileToMatch.FlipHorizontal = false;
            tileToMatch.FlipVertical = false;
            if (RotationsAndMatch(tileToMatch))
            {
                return true;
            }
            
            tileToMatch.FlipHorizontal = true;
            tileToMatch.FlipVertical = false;
            if (RotationsAndMatch(tileToMatch))
            {
                return true;
            }
            
            tileToMatch.FlipHorizontal = false;
            tileToMatch.FlipVertical = true;
            if (RotationsAndMatch(tileToMatch))
            {
                return true;
            }

            return false;
        }

        private bool RotationsAndMatch(Tile tileToMatch)
        {
            int matches;
            for (var i = 0; i < 4; i++)
            {
                tileToMatch.Rotation = i;
                matches = NumberOfMatchesInternal(tileToMatch);

                if (matches == 1)
                {
                    return true;
                }

                if (matches > 1)
                {
                    throw new Exception("hmmm, I didnt think this was possible");
                }
            }

            return false;
        }

        private int NumberOfMatchesInternal(Tile tileToMatch)
        {
            var matches = 0;
            if (LeftLine == new string(tileToMatch.RightLine.ToCharArray().Reverse().ToArray()))
            {
                matches++;
            }

            if (RightLine == new string(tileToMatch.LeftLine.ToCharArray().Reverse().ToArray()))
            {
                matches++;
            }

            if (TopLine == new string(tileToMatch.BottomLine.ToCharArray().Reverse().ToArray()))
            {
                matches++;
            }

            if (BottomLine == new string(tileToMatch.TopLine.ToCharArray().Reverse().ToArray()))
            {
                matches++;
            }

            return matches;
        }

        public string TopLine
        {
            get
            {
                (string currentLine, string oppositeLine) postRotation = Rotation switch
                {
                    0 => (_topLine,_bottomLine),
                    1 =>( _rightLine,_leftLine),
                    2 => (_bottomLine,_topLine),
                    3 => (_leftLine,_rightLine),
                    _ => throw new ArgumentException("Cannot do more than 3 rotations")
                };

                if (FlipVertical)
                {
                    return new string(postRotation.oppositeLine.ToCharArray().Reverse().ToArray());
                }

                if (FlipHorizontal)
                {
                    return new string(postRotation.currentLine.ToCharArray().Reverse().ToArray());
                }
            
                return postRotation.currentLine;   
            }
        }
        
        private string _bottomLine;

        public string BottomLine
        {
            get
            {
                (string currentLine, string oppositeLine) postRotation = Rotation switch
                {
                    2 => (_topLine,_bottomLine),
                    3 =>( _rightLine,_leftLine),
                    0 => (_bottomLine,_topLine),
                    1 => (_leftLine,_rightLine),
                    _ => throw new ArgumentException("Cannot do more than 3 rotations")
                };

                if (FlipVertical)
                {
                    return  new string(postRotation.oppositeLine.ToCharArray().Reverse().ToArray());
                }

                if (FlipHorizontal)
                {
                    return  new string(postRotation.currentLine.ToCharArray().Reverse().ToArray());
                }
            
                return postRotation.currentLine;    
            }
        }

        private string _leftLine;
        public string LeftLine
        {
            get
            {
                (string currentLine, string oppositeLine) postRotation = Rotation switch
                {
                    1 => (_topLine,_bottomLine),
                    2 =>( _rightLine,_leftLine),
                    3 => (_bottomLine,_topLine),
                    0 => (_leftLine,_rightLine),
                    _ => throw new ArgumentException("Cannot do more than 3 rotations")
                };

                if (FlipHorizontal)
                {
                    return new string(postRotation.oppositeLine.ToCharArray().Reverse().ToArray());
                }

                if (FlipVertical)
                {
                    return new string(postRotation.currentLine.ToCharArray().Reverse().ToArray());
                }
            
                return postRotation.currentLine;    
            }
        }
        
        private string _rightLine;
        public string RightLine
        {
            get
            {
                (string currentLine, string oppositeLine) postRotation = Rotation switch
                {
                    3 => (_topLine,_bottomLine),
                    0 =>( _rightLine,_leftLine),
                    1 => (_bottomLine,_topLine),
                    2 => (_leftLine,_rightLine),
                    _ => throw new ArgumentException("Cannot do more than 3 rotations")
                };

                if (FlipHorizontal)
                {
                    return  new string(postRotation.oppositeLine.ToCharArray().Reverse().ToArray());
                }

                if (FlipVertical)
                {
                    return  new string(postRotation.currentLine.ToCharArray().Reverse().ToArray());
                }
            
                return postRotation.currentLine;    
            }
        }
        
        public bool FlipVertical;
        public bool FlipHorizontal;
        public int Rotation;

        public void ReadId(string input)
        {
            var matches = Regex.Match(input, "Tile (?'Number'[0-9]+):");
            if (!matches.Groups["Number"].Success)
            {
                throw new ArgumentException("Input not in the correct format");
            }

            if (!int.TryParse(matches.Groups["Number"].Value, out var value))
            {
                throw new ArgumentException("Number is not a integer");
            }

            Id = value;
        }
        
        public void ReadTile(IEnumerable<string> input)
        {
            _topLine = input.First();
            var y = 0;
            foreach (var value in input)
            {
                _map.Add(value);

                y++;
                _leftLine += value.Substring(0,1);
                _rightLine += value.Substring(value.Length - 1,1);
            }

            _leftLine =  new string(_leftLine.ToCharArray().Reverse().ToArray());
            _bottomLine =  new string(input.Last().ToCharArray().Reverse().ToArray());
        }
    }
}