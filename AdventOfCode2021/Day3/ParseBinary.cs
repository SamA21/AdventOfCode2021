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
              
        public int GetLifeSupportRating(List<string> binaryStrings)
        {
            List<string> OxyRatingsList = binaryStrings;
            List<string> Co2RatingsList = binaryStrings;
            var firstLength = binaryStrings.First().Length;
            for (int index = 0; index < firstLength; index++)
            {
                if (OxyRatingsList.Count > 1)
                {
                    OxyRatingsList = ReduceRatings(OxyRatingsList, index, false);
                }

                if (Co2RatingsList.Count > 1)
                {
                    Co2RatingsList = ReduceRatings(Co2RatingsList, index, true);
                }
            }
            return Convert.ToInt32(OxyRatingsList.First(), 2) * Convert.ToInt32(Co2RatingsList.First(), 2);
        }

        private List<string> ReduceRatings(List<string> ratings, int index, bool isCo2)
        {
            var bitFrequency = FindBits(ratings, index);
            if(isCo2)
                ratings = ratings.Where(x => x[index] == bitFrequency.least).ToList();
            else
                ratings = ratings.Where(x => x[index] == bitFrequency.most).ToList();
            return ratings;
        }

        private (char most, char least) FindBits(List<string> binaryStrings, int index)
        {
            var middlePoint = (float)binaryStrings.Count / 2;
            var find1s = binaryStrings.Count(x => x[index] == '1');
            return find1s >= middlePoint ? ('1', '0') : ('0', '1');
        }
    }
}
