namespace Day10
{
    public interface ITree<T> where T : INode
    {
        public void AddNode(T node);
        public bool TryGetNode(int value, out T node);
    }
}