using AdventHelper;
using Day6;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var laternFish = reader.GetSingleIntListFromFile(inputLocation);
LanternFish lf = new LanternFish();
var spawnedFish = lf.SpawnFish(80, laternFish);
Console.WriteLine($"Spawned {spawnedFish.Count}"); 
laternFish = reader.GetSingleIntListFromFile(inputLocation);
var spawnedFishUnlimited = lf.SpawnFishUnlimited(256, laternFish);
Console.WriteLine($"Spawned {spawnedFishUnlimited}");