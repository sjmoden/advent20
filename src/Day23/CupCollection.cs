using System;
using System.Collections.Generic;
using System.Linq;

namespace Day23
{
    public class CupCollection
    {
        private readonly List<int> _cups;

        public CupCollection(List<int> cups)
        {
            _cups = cups;
        }

        public int TakeValue(int index)
        {
            if (index-1 > _cups.Count)
            {
                throw  new ArgumentException("Index is greater than number of cups");
            }
            
            return _cups[index-1];
        }

        public IEnumerable<int> TakeNextThree(int index)
        {
            if (index > _cups.Count)
            {
                throw  new ArgumentException("Index is greater than number of cups");
            }
            return _cups.Skip(index).Concat(_cups.Take(index)).Take(3);
        }

        private int TakeOneOfValue(int value)
        {
            value--;

            return value == 0 ? _cups.Count : value;
        }

        private int GetCycledValue(int value)
        {
            return value % _cups.Count == 0 ? _cups.Count : value % _cups.Count;
        }
        
        public CupCollection PutListIntoCupCollectionAndReturnNewCollection(int indexRaw, out int resetIndex)
        {
            var index = GetCycledValue(indexRaw);
            Console.WriteLine($"Cups: {string.Join("", TakeNextThree(index))}");
            var valueToFind = TakeOneOfValue(TakeValue(index));
            var nextThree = TakeNextThree(index).ToList();
            var tempCups = _cups.Where(c => !nextThree.Contains(c)).ToList();

            while (nextThree.Contains(valueToFind))
            {
                valueToFind = TakeOneOfValue(valueToFind);
            }
            Console.WriteLine($"Destination: {valueToFind}");

            var indexOfValueToFind = tempCups.IndexOf(valueToFind);
            var newCupList = tempCups.Take(indexOfValueToFind + 1).Concat(nextThree)
                .Concat(tempCups.Skip(indexOfValueToFind + 1)).ToList();

            resetIndex = newCupList.IndexOf(TakeValue(index))+1;

            return new CupCollection(newCupList);
        }

        public string OutputCupsInCurrentState()
        {
            return string.Join("", _cups);
        }

        public string OutputCups()
        {
            var indexOfOne = _cups.IndexOf(1);
            return string.Join("", _cups.Skip(indexOfOne+1).Concat(_cups.Take(indexOfOne)));
        }
    }
}