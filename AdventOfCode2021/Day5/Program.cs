using AdventHelper;
using Day5;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var ventLocations = reader.GetListFromFile(inputLocation);
Vents vents = new Vents();
var overlapCount = vents.VentsOverlap(ventLocations);
Console.WriteLine($"{overlapCount} vents overlap");