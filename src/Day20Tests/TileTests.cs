using System.Collections.Generic;
using Day20;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day20Tests.TileTests
{
    [TestFixture]
    public class EasyReadableTests
    {
        private readonly List<string>_input = new List<string>
        {
            "abc",
            "def",
            "ghi"
        };
        
        private readonly Tile _tile = new Tile();
        
        [OneTimeSetUp]
        public void Setup()
        {
            _tile.ReadTile(_input);
        }
        
        [TestCase(0,false,false,"abc")]
        [TestCase(1,false,false,"cfi")]
        [TestCase(2,false,false,"ihg")]
        [TestCase(3,false,false,"gda")]
        [TestCase(0,true,false,"cba")]
        [TestCase(1,true,false,"ifc")]
        [TestCase(2,true,false,"ghi")]
        [TestCase(3,true,false,"adg")]
        [TestCase(0,false,true,"ghi")]
        [TestCase(1,false,true,"adg")]
        [TestCase(2,false,true,"cba")]
        [TestCase(3,false,true,"ifc")]
        public void Then_the_top_is_correct(int rotation,bool flipHorizontal, bool flipVertical ,string expectedOutput)
        {
            _tile.Rotation = rotation;
            _tile.FlipHorizontal = flipHorizontal;
            _tile.FlipVertical = flipVertical;
            Assert.That(_tile.TopLine, Is.EqualTo(expectedOutput));
        }
        
        [TestCase(0,false,false,"ihg")]
        [TestCase(1,false,false,"gda")]
        [TestCase(2,false,false,"abc")]
        [TestCase(3,false,false,"cfi")]
        [TestCase(0,true,false,"ghi")]
        [TestCase(1,true,false,"adg")]
        [TestCase(2,true,false,"cba")]
        [TestCase(3,true,false,"ifc")]
        [TestCase(0,false,true,"cba")]
        [TestCase(1,false,true,"ifc")]
        [TestCase(2,false,true,"ghi")]
        [TestCase(3,false,true,"adg")]
        public void Then_the_bottom_is_correct(int rotation,bool flipHorizontal, bool flipVertical ,string expectedOutput)
        {
            _tile.Rotation = rotation;
            _tile.FlipHorizontal = flipHorizontal;
            _tile.FlipVertical = flipVertical;
            Assert.That(_tile.BottomLine, Is.EqualTo(expectedOutput));
        }
        
        [TestCase(0,false,false,"gda")]
        [TestCase(1,false,false,"abc")]
        [TestCase(2,false,false,"cfi")]
        [TestCase(3,false,false,"ihg")]
        [TestCase(0,true,false,"ifc")]
        [TestCase(1,true,false,"ghi")]
        [TestCase(2,true,false,"adg")]
        [TestCase(3,true,false,"cba")]
        [TestCase(0,false,true,"adg")]
        [TestCase(1,false,true,"cba")]
        [TestCase(2,false,true,"ifc")]
        [TestCase(3,false,true,"ghi")]
        public void Then_the_left_is_correct(int rotation,bool flipHorizontal, bool flipVertical ,string expectedOutput)
        {
            _tile.Rotation = rotation;
            _tile.FlipHorizontal = flipHorizontal;
            _tile.FlipVertical = flipVertical;
            Assert.That(_tile.LeftLine, Is.EqualTo(expectedOutput));
        }
        
        [TestCase(0,false,false,"cfi")]
        [TestCase(1,false,false,"ihg")]
        [TestCase(2,false,false,"gda")]
        [TestCase(3,false,false,"abc")]
        [TestCase(0,true,false,"adg")]
        [TestCase(1,true,false,"cba")]
        [TestCase(2,true,false,"ifc")]
        [TestCase(3,true,false,"ghi")]
        [TestCase(0,false,true,"ifc")]
        [TestCase(1,false,true,"ghi")]
        [TestCase(2,false,true,"adg")]
        [TestCase(3,false,true,"cba")]
        public void Then_the_right_is_correct(int rotation,bool flipHorizontal, bool flipVertical ,string expectedOutput)
        {
            _tile.Rotation = rotation;
            _tile.FlipHorizontal = flipHorizontal;
            _tile.FlipVertical = flipVertical;
            var sd = _tile.Map;
            Assert.That(_tile.RightLine, Is.EqualTo(expectedOutput));
        }
    }
    
    [TestFixture]
    public class When_populating_tile_data
    {
        private readonly List<string>_input = new List<string>
        {
            ".#...##.#.",
            "#.#..#...#",
            "##....#..#",
            ".#...##..#",
            "..###....#",
            "..##..#...",
            "#.#...##.#",
            "..##..##..",
            ".#.....##.",
            "#.###....."
        };
        
        private readonly Tile _tile = new Tile();
        
        
        [OneTimeSetUp]
        public void Setup()
        {
            _tile.ReadTile(_input);
        }

        [Test]
        public void Then_the_top_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.TopLine, Is.EqualTo(".#...##.#."));
        }
        
        [Test]
        public void Then_the_top_flipped_vertically_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = true;
            Assert.That(_tile.TopLine, Is.EqualTo(".....###.#"));
        }
        
        [Test]
        public void Then_the_top_flipped_horizontally_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = true;
            _tile.FlipVertical = false;
            Assert.That(_tile.TopLine, Is.EqualTo(".#.##...#."));
        }

        [Test]
        public void Then_the_top_rotated_is_correct()
        {
            _tile.Rotation = 1;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.TopLine, Is.EqualTo(".####.#..."));

        }

        [Test]
        public void Then_the_top_rotated_twice_is_correct()
        {
            _tile.Rotation = 2;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.TopLine, Is.EqualTo(".....###.#"));
        }

        [Test]
        public void Then_the_top_rotated_thrice_is_correct()
        {
            _tile.Rotation = 3;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.TopLine, Is.EqualTo("#..#...##."));
        }

        [Test]
        public void Then_the_bottom_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.BottomLine, Is.EqualTo(".....###.#"));
        }

        [Test]
        public void Then_the_bottom_flipped_horizontally_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = true;
            _tile.FlipVertical = false;
            Assert.That(_tile.BottomLine, Is.EqualTo("#.###....."));
        }

        [Test]
        public void Then_the_bottom_flipped_vertically_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = true;
            Assert.That(_tile.BottomLine, Is.EqualTo(".#...##.#."));
        }
        
        [Test]
        public void Then_the_bottom_rotated_is_correct()
        {
            _tile.Rotation = 1;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.BottomLine, Is.EqualTo("#..#...##."));
        }
        
        [Test]
        public void Then_the_bottom_rotated_twice_is_correct()
        {
            _tile.Rotation = 2;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.BottomLine, Is.EqualTo(".#...##.#."));
        }
        
        [Test]
        public void Then_the_bottom_rotated_thrice_is_correct()
        {
            _tile.Rotation = 3;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.BottomLine, Is.EqualTo(".####.#..."));
        }

        [Test]
        public void Then_the_right_rotated_is_correct()
        {
            _tile.Rotation = 1;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.RightLine, Is.EqualTo(".....###.#"));
        }

        [Test]
        public void Then_the_right_rotated_twice_is_correct()
        {
            _tile.Rotation = 2;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.RightLine, Is.EqualTo("#..#...##."));
        }

        [Test]
        public void Then_the_right_rotated_thrice_is_correct()
        {
            _tile.Rotation = 3;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.RightLine, Is.EqualTo(".#...##.#."));
        }

        [Test]
        public void Then_the_right_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.RightLine, Is.EqualTo(".####.#..."));
        }

        [Test]
        public void Then_the_right_flipped_vertically_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = true;
            Assert.That(_tile.RightLine, Is.EqualTo("...#.####."));
        }

        [Test]
        public void Then_the_right_flipped_horizontally_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = true;
            _tile.FlipVertical = false;
            Assert.That(_tile.RightLine, Is.EqualTo("#..#...##."));
        }

        [Test]
        public void Then_the_left_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.LeftLine, Is.EqualTo("#..#...##."));
        }

        [Test]
        public void Then_the_left_flipped_horizontally_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = true;
            _tile.FlipVertical = false;
            Assert.That(_tile.LeftLine, Is.EqualTo(".####.#..."));
        }

        [Test]
        public void Then_the_left_flipped_vertically_is_correct()
        {
            _tile.Rotation = 0;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = true;
            Assert.That(_tile.LeftLine, Is.EqualTo(".##...#..#"));
        }
        
        [Test]
        public void Then_the_left_rotated_is_correct()
        {
            _tile.Rotation = 1;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.LeftLine, Is.EqualTo(".#...##.#."));
        }
        [Test]
        public void Then_the_left_rotated_twice_is_correct()
        {
            _tile.Rotation = 2;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.LeftLine, Is.EqualTo(".####.#..."));
        }
        [Test]
        public void Then_the_left_rotated_thrice_is_correct()
        {
            _tile.Rotation = 3;
            _tile.FlipHorizontal = false;
            _tile.FlipVertical = false;
            Assert.That(_tile.LeftLine, Is.EqualTo(".....###.#"));
        }
    }
}