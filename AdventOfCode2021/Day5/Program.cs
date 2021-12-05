using AdventHelper;
using Day5;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var ventLocations = reader.GetListFromFile(inputLocation);
Vents vents = new Vents();
var overlapCount = vents.VentsOverlap(ventLocations, false);
Console.WriteLine($"{overlapCount} vents overlap"); 
vents = new Vents();//clear previous internal hashmaps
var overlapDiagonalCount = vents.VentsOverlap(ventLocations, true);
Console.WriteLine($"{overlapDiagonalCount} vents overlap in the diagonal");