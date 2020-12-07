namespace Day7
{
    public interface ITree
    {
        public void AddNode(IBag bag);
        public bool TryGetNode(string bagName, out IBag bag);
    }
}