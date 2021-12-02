// See https://aka.ms/new-console-template for more information
using AdventHelper;
using Day2;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var commandList = reader.GetListFromFile(inputLocation);
ParseMovement submarine = new ParseMovement();
int totalDepth = submarine.GetFinalDepth(commandList);
Console.WriteLine(totalDepth);