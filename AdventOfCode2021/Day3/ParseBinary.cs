using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    public class ParseBinary
    {
        public (string gamma, string epsilon) GetGammaAndEpsilon(List<string> binaryStrings)
        {
            string gammaString = string.Empty;
            string epsilonString = string.Empty;
            int totalCount = binaryStrings.Count;
            string first = binaryStrings.First();
            int index = 0;
            foreach (char text in first)
            {
                int oneCount = MostCommonCount(binaryStrings, index);
                if (oneCount > totalCount / 2)
                {
                    gammaString += "1";
                    epsilonString += "0";
                }
                else
                {
                    gammaString += "0";
                    epsilonString += "1";
                }
                index++;
            }

            return (gammaString, epsilonString);
        }

        private int MostCommonCount(List<string> binaryStrings, int index)
        {
            int oneCount = 0;
            foreach (var binary in binaryStrings)
            {
                var test = binary[index];
                if (test == '1')
                    oneCount++;
            }
            return oneCount;
        }
    }
}
