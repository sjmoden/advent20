using System.Collections.Generic;

namespace Day10
{
    public class JoltTree:ITree<JoltNode>
    {
        private readonly Dictionary<int,JoltNode> _nodes = new Dictionary<int, JoltNode>();
        
        public void AddNode(JoltNode node)
        {
            _nodes.Add(node.Value, node);
        }

        public bool TryGetNode(int value, out JoltNode node)
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