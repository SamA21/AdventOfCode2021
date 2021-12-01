using AdventHelper;
using Day1;

AdventTextReader reader = new AdventTextReader();
string inputLocationDay1 = $"data.txt";
var numberList = reader.GetNumberListFromFile(inputLocationDay1);
Console.WriteLine(numberList.Count);
ParseDepths parseDepths = new ParseDepths();
var increases = parseDepths.CountIncreases(numberList);
Console.WriteLine(increases);