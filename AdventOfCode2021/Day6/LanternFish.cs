using System;
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
    }
}
