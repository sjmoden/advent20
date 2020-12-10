using System.Collections.Generic;

namespace Day10
{
    public class PathTree:ITree<PathNode>
    {
        private readonly Dictionary<int,PathNode> _nodes = new Dictionary<int, PathNode>(); 
        
        public void AddNode(PathNode node)
        {
            _nodes.Add(node.Value, node);
        }

        public bool TryGetNode(int value, out PathNode node)
        {
            if (_nodes.ContainsKey(value))
            {
                node = _nodes[value];
                return true;
            }

            node = null;
            return false;
        }
    }
}