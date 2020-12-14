using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public class Memory
    {
        private readonly Dictionary<long, long> _memory = new Dictionary<long, long>();

        public void UpdateMemory(int position, long value)
        {
            if (!_memory.TryAdd(position, value))
            {
                _memory[position] = value;
            }
        }

        public long ReturnMemorySum()
        {
            
            return _memory.Values.Sum();
        }
    }
}