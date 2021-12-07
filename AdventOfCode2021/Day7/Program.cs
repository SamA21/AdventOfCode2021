using AdventHelper;
using Day7;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var crabSubs = reader.GetSingleIntListFromFile(inputLocation);
Crabs crabs = new Crabs();
var fuelUsed = crabs.MoveCrabs(crabSubs);
Console.WriteLine($"Used {fuelUsed}");