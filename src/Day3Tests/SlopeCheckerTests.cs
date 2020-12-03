using System.Drawing;
using Day3;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
namespace Day3Tests.SlopeCheckerTests
{
    [TestFixture]
    public class When_checking_row_values
    {
        private readonly string[] inputArray = 
        {
            "..##.........##.........##.........##.........##.........##.......",
            "#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..",
            ".#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.",
            "..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#",
            ".#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.",
            "..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....",
            ".#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#",
            ".#........#.#........#.#........#.#........#.#........#.#........#",
            "#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...",
            "#...##....##...##....##...##....##...##....##...##....##...##....#",
            ".#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#"
        };
        
        [Test]
        public void Then_tree_is_found()
        {
            Assert.That(SlopeChecker.CheckIfPositionHoldsATree(inputArray,new Point(3,0)),Is.True);
        }
        
        [Test]
        public void Then_space_is_found()
        {
            Assert.That(SlopeChecker.CheckIfPositionHoldsATree(inputArray,new Point(3,1)),Is.False);
        }
    }
    
    [TestFixture]
    public class When_checking_row_values_wrap_around
    {
        private readonly string[] inputArray = new[]
        {
            "..##.....",
            "#...#...#",
            ".#....#..",
            "..#.#...#",
            ".#...##..",
            "..#.##...",
            ".#.#.#...",
            ".#.......",
            "#.##...#.",
            "#...##...",
            ".#..#...#"
        };
        
        [Test]
        public void Then_tree_is_found()
        {
            Assert.That(SlopeChecker.CheckIfPositionHoldsATree(inputArray,new Point(10,4)),Is.True);
        }
        
        [Test]
        public void Then_space_is_found()
        {
            Assert.That(SlopeChecker.CheckIfPositionHoldsATree(inputArray,new Point(12,3)),Is.False);
        }
    }
}