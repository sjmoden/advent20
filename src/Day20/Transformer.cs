using System.Collections.Generic;
using System.Linq;

namespace Day20
{
    public static class Transformer
    {
        public static IEnumerable<string> TransformList(IEnumerable<string> inputSquareMap, int rotation, bool flipHorizontal,
            bool flipVertical)
        {
            var map = new List<string>();
            var tempMap = inputSquareMap.Select(item => (string) item.Clone()).ToList();
            //Rotate
            for (var r = 0; r < rotation; r++)
            {
                var rotationMap = Enumerable.Range(1, tempMap.Count).Select(s => string.Empty).ToList();
                for (var i = 0; i < tempMap.Count(); i++)
                {
                    rotationMap[i] = new string(tempMap.Select(s => s[tempMap.Count - i - 1]).ToArray());
                }

                tempMap = rotationMap;
            }

            //Horizontal Flip
            if (flipHorizontal)
            {
                tempMap = tempMap.Select(s => new string(s.ToCharArray().Reverse().ToArray())).ToList();
            }

            //VerticalFlip
            if (flipVertical)
            {
                tempMap.Reverse();
            }
            foreach (var row in tempMap.Take(tempMap.Count))
            {
                map.Add(row);
            }

            return map;
        }
    }
}