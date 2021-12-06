using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class LanternFish
    {
        public List<int> SpawnFish(int days, List<int> initalFish)
        {
            while(days > 0)
            {
                for(int index = 0; index < initalFish.Count; index++)
                {
                    if (initalFish[index] == 0)
                    {
                        initalFish.Add(9);
                        initalFish[index] = 6;
                    }
                    else
                    {
                        initalFish[index]--;
                    }
                }

                days--;
            }
            return initalFish;
        }
        
        /// <summary>
        /// As 256 days used to much memory due to expontial growth this method was created 
        /// </summary>
        /// <param name="days"></param>
        /// <param name="initalFish"></param>
        /// <returns></returns>
        public long SpawnFishUnlimited(int days, List<int> initalFish)
        {
            long[] fishArray = SetupFishArray(initalFish);

            while (days > 0)
            {
                fishArray = SpawnFish(fishArray);
                days--;
            }

            return fishArray.Sum();
        }

        private long[] SetupFishArray(List<int> initalFish)
        {
            long[] fishArray = new long[9];
            foreach (int fish in initalFish)
            {
                fishArray[fish]++;
            }
            return fishArray;
        }

        private long[] SpawnFish(long[] fishArray)
        {
            long zeroFish = 0;
            for (int index = 0; index < fishArray.Length; index++)
            {
                if (index == 0)
                    zeroFish = fishArray[index];
                else
                    fishArray[index - 1] += fishArray[index];
                fishArray[index] = 0;
            }
            fishArray[6] += zeroFish;
            fishArray[8] = zeroFish;
            return fishArray;
        }
    }
}
