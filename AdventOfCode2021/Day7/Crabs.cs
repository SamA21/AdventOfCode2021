using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Crabs
    {
        public int MoveCrabs(List<int> crabPositions)
        {
            int maxValue = crabPositions.Max();
            List<int> totalFuel = new List<int>();
            for(int target = 0; target < maxValue; target++)
            {
                int currentFuel = GetFuelUsage(target, crabPositions);
                totalFuel.Add(currentFuel);
            }
            
            return totalFuel.Min();
        }

        private int GetFuelUsage(int target, List<int> crabPositions)
        {
            int totalFuel = 0;
            foreach(int position in crabPositions)
            {
                int fuel = position - target;
                if (fuel < 0)
                    fuel = fuel * -1;
                totalFuel += fuel;
            }
            return totalFuel;
        }
    }
}
