using AdventHelper;
using Day8;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var segmentSignals = reader.GetListFromFile(inputLocation);
Segments segments = new Segments(segmentSignals);
var unquieNumbers = segments.FindeUnquieNumbers(true);
Console.WriteLine($"There are {unquieNumbers} unquie numbers");
var codedTotal = segments.FindeUnquieNumbers(false);
Console.WriteLine($"The coded total is {codedTotal}");