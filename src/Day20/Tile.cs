using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day20
{
    public class Tile
    {
        public int Id;
        
        private string _topLine;

        public bool OneEdgeMatches(Tile tileToMatch)
        {
            var matches = 0;
            
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
                    return postRotation.oppositeLine;
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
                    return postRotation.oppositeLine;
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
                    return postRotation.oppositeLine;
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
                    return postRotation.oppositeLine;
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
        public int Rotation = 0;

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
            
            foreach (var value in input)
            {
                _leftLine += value.Substring(0,1);
                _rightLine += value.Substring(value.Length - 1,1);
            }

            _leftLine =  new string(_leftLine.ToCharArray().Reverse().ToArray());
            _bottomLine =  new string(input.Last().ToCharArray().Reverse().ToArray());
        }
    }
}