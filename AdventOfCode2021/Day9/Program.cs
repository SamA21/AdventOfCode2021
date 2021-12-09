using AdventHelper;
using Day9;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var lavaTubes = reader.GetListFromFile(inputLocation);
SmokeBasin smokeBasin = new SmokeBasin(lavaTubes);
var riskLevelTotal = smokeBasin.FindLowPoints();
Console.WriteLine($"The sum of the risk levels is {riskLevelTotal}");