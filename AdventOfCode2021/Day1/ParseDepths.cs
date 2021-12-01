using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class ParseDepths
    {
        public int CountIncreases(List<int> depthList)
        {
            int increases = 0;
            bool first = true;
            int lastValue = 0;
            foreach (int depth in depthList)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    if(depth > lastValue)
                    {
                        increases++;
                    }
                }
                lastValue = depth;
            }
            return increases;
        }
    }
}
