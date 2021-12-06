using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventHelper
{
    public class AdventTextReader
    {
        public List<int> GetNumberListFromFile(string textFile)
        {
            List<int> codes = new List<int>();
            FileStream fileStream = new FileStream(textFile, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (int.TryParse(line, out int code))
                        {
                            codes.Add(code);
                        }
                    }
                }
            }
            return codes;
        }
        public List<string> GetListFromFile(string textFile)
        {
            List<string> lines = new List<string>();
            FileStream fileStream = new FileStream(textFile, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lines.Add(line);
                    }
                }
            }
            return lines;
        }
        public List<int> GetSingleIntListFromFile(string textFile)
        {
            List<int> lines = new List<int>();
            FileStream fileStream = new FileStream(textFile, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] text = line.Split(',');
                        foreach(var numberText in text)
                        {
                            int number = int.Parse(numberText);
                            lines.Add(number);
                        }
                    }
                }
            }
            return lines;
        }
    }
}
