using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Vents
    {
        List<int[,]> Points { get; set; }
        public Vents()
        {
            Points = new List<int[,]>();
        }

        public int VentsOverlap(List<string> data)
        {
            int overlapCount = 0;
            foreach(var vents in data)
            {
                var startEnd = vents.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var intValues = GetXYValues(startEnd);
                int XDiff = intValues.startX - intValues.endX;
                int YDiff = intValues.startY - intValues.endY;
            }
            return overlapCount;
        }

        private (int startX, int startY, int endX, int endY) GetXYValues(string[] startEnd)
        {
            var start = startEnd[0];
            var end = startEnd[1];
            var startSplit = GetIntValues(start);
            var endSplit = GetIntValues(end);
            return (startSplit.X, startSplit.Y, endSplit.X, endSplit.Y);
        }

        private  (int X, int Y) GetIntValues(string side)
        {
            var split = side.Split(',', StringSplitOptions.TrimEntries);
            int X = int.Parse(split[0]);
            int Y = int.Parse(split[1]);
            return (X, Y);
        }
    }
}
