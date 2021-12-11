using AdventHelper;
using Day10;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var navigationSignals = reader.GetListFromFile(inputLocation);
NavigationSubsystem nav = new NavigationSubsystem();
var total = nav.FindTotalSyntaxErrorScore(navigationSignals);
Console.WriteLine($"The total syntax error score is {total}");