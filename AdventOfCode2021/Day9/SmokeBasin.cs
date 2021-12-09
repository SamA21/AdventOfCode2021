using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class SmokeBasin
    {
        public List<Tuple<int, int, int>> HeightMap { get; set; }

        public SmokeBasin(List<string> data) 
        {
            HeightMap = new List<Tuple<int,int,int>>();

            for(var rowIndex = 0; rowIndex < data.Count; rowIndex++)
            {
                var row = data[rowIndex];                
                for(var columnIndex = 0; columnIndex < row.Length; columnIndex++)
                {
                    var numberToConvert = row[columnIndex];
                    int parsedNumber = int.Parse(numberToConvert.ToString());
                    HeightMap.Add(new Tuple<int, int, int>(rowIndex, columnIndex, parsedNumber));
                } 
            }
        }

        public int FindLowPoints()
        {
            List<Tuple<int, int, int>> isPossibleList = new List<Tuple<int, int, int>>();
            foreach (var map in HeightMap)
            {
                var isPossible =  FindPossibleLowPoints(map);
                if(isPossible != null)
                    isPossibleList.Add(isPossible);
            }
            List<int> lowPoints = isPossibleList.Select(x => x.Item3).ToList();
            return lowPoints.Sum(x => x += 1);
        }

        private Tuple<int, int, int>? FindPossibleLowPoints(Tuple<int,int,int> map)
        {
            var xCheck = map.Item1;
            var yCheck = map.Item2; 
            List<Tuple<int,int,int>> adjValues = new List<Tuple<int, int, int>>();
            if(xCheck - 1 < 0)
            {
                adjValues.AddRange(HeightMap.Where(x => (x.Item1 == xCheck || x.Item1 == xCheck + 1) && x.Item2 == yCheck));
            }
            else
            {
                adjValues.AddRange(HeightMap.Where(x => (x.Item1 == xCheck || x.Item1 == xCheck + 1 || x.Item1 == xCheck -1) && x.Item2 == yCheck));
            }

            if (yCheck - 1 < 0)
            {
                adjValues.AddRange(HeightMap.Where(x => (x.Item2 == yCheck || x.Item2 == yCheck + 1) && x.Item1 == xCheck));
            }
            else
            {
                adjValues.AddRange(HeightMap.Where(x => (x.Item2 == yCheck || x.Item2 == yCheck + 1 || x.Item2 == yCheck - 1) && x.Item1 == xCheck));
            }
            adjValues = adjValues.Distinct().ToList();
            var numbers = adjValues.Select(x => x.Item3);
            var min = numbers.Min();
            if (min == map.Item3 && numbers.Count(x => x == min) == 1)
                return map;
            else
                return null;
        }
    }
}
