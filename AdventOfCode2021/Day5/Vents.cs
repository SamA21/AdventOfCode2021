using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Vents
    {
        public HashSet<Vector2> Points { get; set; }
        public HashSet<Vector2> Overlaps { get; set; }

        public Vents()
        {
            Points = new HashSet<Vector2>();
            Overlaps = new HashSet<Vector2>();
        }

        public int VentsOverlap(List<string> data)
        {
            foreach (var ventChain in data)
            {
                var startEnd = ventChain.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var coords = GetStartEndValues(startEnd);
                if(coords.start.X == coords.end.X || coords.start.Y == coords.end.Y)
                {
                    Vector2 direction = coords.end - coords.start;
                    var deltaVector = new Vector2(Math.Sign(direction.X), Math.Sign(direction.Y));
                    var currentPoint = coords.start;
                    AddPoint(currentPoint);
                    while (currentPoint != coords.end)
                    {
                        currentPoint += deltaVector;
                        AddPoint(currentPoint);
                    }
                }
                
            }
            return Overlaps.Count;
        }
        private void AddPoint(Vector2 point)
        {
            if (Points.Contains(point))
            {
                Overlaps.Add(point);
            }
            else
            {
                Points.Add(point);
            }
        }
        private (Vector2 start, Vector2 end) GetStartEndValues(string[] startEnd)
        {
            var start = startEnd[0];
            var end = startEnd[1];
            var startSplit = GetIntValues(start);
            var endSplit = GetIntValues(end);
            Vector2 startCoord = new Vector2(startSplit.X, startSplit.Y);
            Vector2 endCoord = new Vector2(endSplit.X, endSplit.Y);
            return (startCoord, endCoord);
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
