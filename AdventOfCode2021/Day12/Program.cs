using AdventHelper;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var caveLocations = reader.GetListFromFile(inputLocation);