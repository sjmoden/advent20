using System.Collections.Generic;
using Day20;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day20Tests.TileTests
{
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