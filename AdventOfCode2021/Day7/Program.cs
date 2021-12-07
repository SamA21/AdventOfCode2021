using AdventHelper;
using Day7;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var crabSubs = reader.GetSingleIntListFromFile(inputLocation);
Crabs crabs = new Crabs();
var fuelUsed = crabs.MoveCrabs(crabSubs, false);
Console.WriteLine($"Used {fuelUsed}");
crabSubs = reader.GetSingleIntListFromFile(inputLocation);
fuelUsed = crabs.MoveCrabs(crabSubs, true);
Console.WriteLine($"Used with actual fuel rate {fuelUsed}");
