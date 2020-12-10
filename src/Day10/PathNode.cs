namespace Day10
{
    public class PathNode:INode
    {
        public PathNode(int value, long pathDepth)
        {
            Value = value;
            PathDepth = pathDepth;
        }
        public int Value { get; }
        public long PathDepth { get; }
    }
}