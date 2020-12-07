using System.Collections.Generic;

namespace Day7
{
    public class Tree:ITree
    {
        private Dictionary<string,IBag> _bags = new Dictionary<string, IBag>();
        
        public void AddNode(IBag bag)
        {
            _bags.Add(bag.BagName,bag);
        }

        public bool TryGetNode(string bagName, out IBag bag)
        {
            if (_bags.ContainsKey(bagName))
            {
                bag = _bags[bagName];
                return true;
            }

            bag = null;
            return false;
        }
    }
}