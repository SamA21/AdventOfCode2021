using AdventHelper;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var octopusFlashes = reader.GetListFromFile(inputLocation);