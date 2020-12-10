using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Day10
{
    public class InputChecker:IInputChecker
    {
        private const string InputUrl = "https://adventofcode.com/2020/day/10/input";
        private readonly IPuzzleInput _puzzleInput;
        private readonly ITree<JoltNode> _joltTree;
        private readonly ITree<PathNode> _pathTree;

        public InputChecker(IPuzzleInput puzzleInput, ITree<JoltNode> joltTree, ITree<PathNode> pathTree)
        {
            _puzzleInput = puzzleInput;
            _joltTree = joltTree;
            _pathTree = pathTree;
        }
        
        public string CheckInputToGetAnswerPart1()
        {
            var countOfOneJolts=0;
            var countOfThreeJolts=0;
            int? currentValue = null;
            foreach (var value in Input.OrderBy(i => i))
            {
                if (currentValue == null)
                {
                    currentValue = value;
                    continue;
                }
                
                var difference = value - currentValue;
                switch (difference)
                {
                    case 1:
                        countOfOneJolts++;
                        break;
                    case 2:
                        break;
                    case 3:
                        countOfThreeJolts++;
                        break;
                    default:
                        throw new Exception($"A jolt cannot be larger than 3: {difference}");
                }

                currentValue = value;
            }
            
            return (countOfOneJolts * countOfThreeJolts).ToString();
        }

        public string CheckInputToGetAnswerPart2()
        {
            PopulateTree();
            if (!_joltTree.TryGetNode(0, out var zeroNode))
            {
                throw new Exception();
            }
            var answer =zeroNode.PathCount.ToString();
            return answer;
        }

        private void PopulateTree()
        {
            foreach (var value in Input.OrderByDescending(i => i))
            {
                var node = new JoltNode(_joltTree, value, _pathTree);
                node.PopulateProceedingNodes(Input.ToList());
                node.PopulatePathCount();
            }
        }


        private List<int> _input;

        private IEnumerable<int> Input
        {
            get
            {
                if (_input == null)
                {
                    var values = Array.ConvertAll(_puzzleInput.GetPuzzleInputAsArray(InputUrl), int.Parse);
                    _input = new List<int> {0, values.Max() + 3};
                    _input.AddRange(values);
                }

                return _input;
            }
        }
    }
}