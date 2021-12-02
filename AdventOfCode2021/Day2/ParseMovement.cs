using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class ParseMovement
    {
        public int GetFinalDepth(List<string> commandList)
        {
            int horizontal = 0;
            int vertical = 0;
            foreach (string command in commandList)
            {
                var splitCommand = command.Split(' ');
                int amount = 0;
                bool parsed = int.TryParse(splitCommand[1], out amount);
                if (parsed) { 
                    switch (splitCommand[0].ToLower())
                    {
                        case "forward":
                            horizontal += amount;
                            break;
                        case "down":
                            vertical += amount;
                            break;
                        case "up":
                            vertical -= amount;
                            break;
                        default:
                            break;
                    }
                }
            }
            int depth = horizontal * vertical;
            return depth;
        }
    }
}
