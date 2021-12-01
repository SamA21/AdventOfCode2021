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

    }
}
