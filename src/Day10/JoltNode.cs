using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class JoltNode:INode
    {
        private readonly ITree<JoltNode> _joltTree;
        private readonly ITree<PathNode> _pathTree;

        public int Value { get; }
        private readonly List<JoltNode> _proceedingNodes = new List<JoltNode>();

        private long _pathCount;

        public long PathCount
        {
            get
            {
                if (_pathCount == default)
                {
                    PopulatePathCount();
                }

                return _pathCount;
            }
        }

        public JoltNode(ITree<JoltNode> joltTree, int value, ITree<PathNode> pathTree)
        {
            _joltTree = joltTree;
            Value = value;
            _pathTree = pathTree;
        }

        public void PopulatePathCount()
        {
            if (_pathTree.TryGetNode(Value, out var pathNode))
            {
                _pathCount = pathNode.PathDepth;
                return;
            }
            
            _pathCount= Math.Max(_proceedingNodes.Sum(p => p.PathCount),1);
            
            _pathTree.AddNode(new PathNode(Value,PathCount));
            
        }

        public void PopulateProceedingNodes(List<int> input)
        {
            for (var i = 1; i < 4; i++)
            {
                if (!input.Contains(Value + i))
                {
                    continue;
                }

                if (_joltTree.TryGetNode(Value+i,out var existingNode))
                {
                    _proceedingNodes.Add(existingNode);
                    continue;
                }

                var newNode = new JoltNode(_joltTree, Value + 1,_pathTree);
                newNode.PopulateProceedingNodes(input);
                _proceedingNodes.Add(newNode);
            }
            
            _joltTree.AddNode(this);
        }
    }
}