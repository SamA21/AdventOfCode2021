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

        public List<int> ThreeList(List<int> depthList)
        {
            List<int> threeList = new List<int>();
            int indexA = 0;
            int length = depthList.Count;
            foreach (int depth in depthList)
            {
                if (IsLongerThanList(length, indexA + 1) || IsLongerThanList(length, indexA + 2))
                {
                    //do nothing as to long to add
                }
                else
                {
                    int depthA1 = depth;
                    int depthA2 = depthList[indexA + 1];
                    int depthA3 = depthList[indexA + 2];
                    int threeMeasure = depthA1 + depthA2 + depthA3;
                    threeList.Add(threeMeasure);
                }
                indexA++;
            }
            return threeList;
        }

        private bool IsLongerThanList(int length, int index)
        {
            if(index > length - 1)
                return true;
            else
                return false;
        }
    }
}
