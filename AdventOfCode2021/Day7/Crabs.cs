using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Crabs
    {
        public int MoveCrabs(List<int> crabPositions, bool isActualUsuage)
        {
            int maxValue = crabPositions.Max();
            List<int> totalFuel = new List<int>();
            for (int target = 0; target < maxValue; target++)
            {
                int currentFuel = GetFuelUsage(target, crabPositions, isActualUsuage);
                totalFuel.Add(currentFuel);
            }

            return totalFuel.Min();
        }
        private int GetFuelUsage(int target, List<int> crabPositions, bool isAcutal)
        {
            int totalFuel = 0;
            foreach(int position in crabPositions)
            {
                if (!isAcutal)
                    totalFuel += FuelUsuage(position, target);
                else
                    totalFuel += FuelUsuageActual(position, target);
            }
            return totalFuel;
        }

        private int FuelUsuage(int position, int target)
        {
            int fuel = position - target;
            if (fuel < 0)
                fuel = fuel * -1;
            return fuel;
        }
        private int FuelUsuageActual(int position, int target)
        {
            int steps = position - target;
            if(steps < 0) 
                steps = steps * -1;
            int fuelStep = 1;
            int fuel = 0;
            while(steps > 0)
            {
                fuel = fuel + fuelStep;
                fuelStep++;
                steps--;
            }
            return fuel;
        }
        
    }
}
