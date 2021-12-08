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
        private Dictionary<string, int> Values2 { get; set; }


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
                return FindTotalOfCodedNumbers();
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

        private int FindTotalOfCodedNumbers()
        {
            int totalCoded = 0;
            foreach (var item in CodedNumbers)
            {
                var values = SetupValues(item.Item1);
                var splitItem = item.Item2.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string textNumber = "";
                foreach(var code in splitItem)
                {
                    int? number = FindNumber(code, values);
                    if (number != null)
                        textNumber = $"{textNumber}{number}";
                    else
                        throw new Exception("Shouldn't be here");
                }
                int parsedNumber = int.Parse(textNumber);
                totalCoded += parsedNumber;
            }
            return totalCoded;
        }

        private Dictionary<string, int> SetupValues(string codedValues)
        {
            var splitCodes = codedValues.Split(' ',StringSplitOptions.RemoveEmptyEntries); 
            Dictionary<string, int> values = new Dictionary<string,int>();
            values = SetupEasyNumbers(splitCodes, values);
            values = SetupOtherNumbers(splitCodes, values);
            return values;
        }

        private Dictionary<string, int> SetupEasyNumbers(string[] splitCodes, Dictionary<string, int> values)
        {
            foreach(var splitCode in splitCodes)
            {
                switch (splitCode.Length)
                {
                    case 2:
                        values.Add(string.Join("", splitCode.OrderBy(x => x)), 1);
                        break;
                    case 3:
                        values.Add(string.Join("", splitCode.OrderBy(x => x)), 7);
                        break;
                    case 4:
                        values.Add(string.Join("", splitCode.OrderBy(x => x)), 4);
                        break;
                    case 7:
                        values.Add(string.Join("", splitCode.OrderBy(x => x)), 8);
                        break;
                    default:
                        //do nothing as not easy number
                        break;
                }
            }
            return values;
        }

        private Dictionary<string, int> SetupOtherNumbers(string[] splitCodes, Dictionary<string, int> values)
        {
            //contains 2, 3 and 5
            var lenghth5 = splitCodes.Where(x => x.Length == 5).ToList();
            //contains 0, 6 and 9
            var lenghth6 = splitCodes.Where(x => x.Length == 6).ToList();

            //3 contains all of 1
            values = FindValue(ref lenghth5, values, 1, 3);
            //9 contains all of 3
            values = FindValue(ref lenghth6, values, 3, 9);        
            //0 contains all of 9
            values = FindValue(ref lenghth6, values, 1, 0);
            if(lenghth6.Count == 1)          
                values.Add(string.Join("", lenghth6[0].OrderBy(x => x)), 6);
            //5 contains all of 6 otherwise is 2
            values = FindLast2(ref lenghth5, values, 6, 5,2);

            return values;
        }

        private Dictionary<string, int> FindLast2(ref List<string> splitCodes, Dictionary<string, int> values, int searchNumber, int findingNumber1, int findingNumber2)
        {
            var searchValue = values.First(y => y.Value == searchNumber).Key;
            foreach(var code in splitCodes)
            {
                bool matched = code.All(searchValue.Contains);
                if (matched)
                    values.Add(string.Join("",code.OrderBy(x=>x)), findingNumber1);
                else
                    values.Add(string.Join("", code.OrderBy(x => x)), findingNumber2);
            }
            return values;
        }

        private Dictionary<string, int> FindValue(ref List<string> splitCodes, Dictionary<string, int> values, int searchNumber, int findingNumber)
        {
            var searchValue = values.First(y => y.Value == searchNumber).Key;
            var value = splitCodes.First(x => searchValue.All(x.Contains));
            values.Add(string.Join("", value.OrderBy(x => x)), findingNumber);
            splitCodes.Remove(value);
            return values;
        }

        private int? FindNumber(string codedNumber, Dictionary<string, int> values)
        {
            var numbers = values.Where(x => x.Key.Length == codedNumber.Length).OrderBy(x => x.Value);

            if(numbers.Count() == 1)
                return numbers.First().Value;
            else
            {
                codedNumber = string.Join("", codedNumber.OrderBy(x => x));
                foreach(var number in numbers)
                {
                    if(number.Key == codedNumber)
                        return number.Value;
                }
                return null;
            }
        }

    }
}
