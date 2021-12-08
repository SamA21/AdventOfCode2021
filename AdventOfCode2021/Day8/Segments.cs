using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Segments
    {
        private List<Tuple<string, string>> CodedNumbers { get; set; }
        private Dictionary<string, int> Values { get; set; }


        public Segments(List<string> input)
        {
            CodedNumbers = new List<Tuple<string, string>>();
            foreach (string code in input)
            {
                var split = code.Split('|', StringSplitOptions.RemoveEmptyEntries);
                CodedNumbers.Add(Tuple.Create(split[0].Trim(), split[1].Trim()));
            }
            Values = new Dictionary<string, int>();
            Values.Add("abcefg", 0); 
            Values.Add("cf", 1);
            Values.Add("acdeg", 2);
            Values.Add("acdfg", 3);
            Values.Add("bcdf", 4);
            Values.Add("abdfg", 5);
            Values.Add("abdefg", 6);
            Values.Add("acf", 7);
            Values.Add("abcdefg", 8);
            Values.Add("abcdfg", 9);

        }

        public int FindeUnquieNumbers(bool easyNumbersOnly)
        {
            if (easyNumbersOnly)
            {
                return FindUnquieEasyNumbers();
            }
            else
            {
                return FindUnquieAllNumbers();
            }


        }
        private int FindUnquieEasyNumbers()
        {
            int totalUnquie = 0;
            Dictionary<string, int> easyNumbers = SetEasyNumbers();
            foreach (var item in CodedNumbers)
            {
                List<string> numbers = SetUpNumbers(item.Item1);
                List<int> foundNumbers = CheckNumbers(numbers, item.Item2, easyNumbers);
                totalUnquie += foundNumbers.Count;
            }
            return totalUnquie;
        }

        private Dictionary<string, int> SetEasyNumbers()
        {
            Dictionary<string, int> easyNumbers = new Dictionary<string, int>();
            foreach (var brokenNumber in Values)
            {
                bool matched = true;
                foreach (var checkNumber in Values)
                {
                    if (checkNumber.Key != brokenNumber.Key && checkNumber.Key.Length == brokenNumber.Key.Length)
                    {
                        matched = false;
                    }
                }

                if (matched)
                    easyNumbers.Add(brokenNumber.Key, brokenNumber.Value);

            }
            return easyNumbers;
        }
        private List<string> SetUpNumbers(string inital)
        {
            List<string> numbers = new List<string>();
            var splitInital = inital.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in splitInital)
            {
                numbers.Add(number.Trim());
            }
            return numbers;
        }

        private List<int> CheckNumbers(List<string> numbers, string codedNumbers, Dictionary<string, int> easyNumbers)
        {
            List<int> foundNumbers = new List<int>();
            var splitCoded = codedNumbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach(string code in splitCoded)
            {
                var number = easyNumbers.Where(x => x.Key.Length == code.Length);
                if(number.Count() == 1)
                    foundNumbers.Add(number.First().Value);
            }
            return foundNumbers;
        }

        private int FindUnquieAllNumbers()
        {
            return 0;
        }
    }
}
