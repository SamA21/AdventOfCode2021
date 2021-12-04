using AdventHelper;
using Day3;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var binaryList = reader.GetListFromFile(inputLocation);
ParseBinary parseBinary = new ParseBinary();
(string gamma, string epsilon) = parseBinary.GetGammaAndEpsilon(binaryList);
Console.WriteLine(gamma);
Console.WriteLine(epsilon);
int gammaNumber = Convert.ToInt32(gamma, 2);
int epsilonNumber = Convert.ToInt32(epsilon, 2);
int powerRate = gammaNumber * epsilonNumber;
Console.WriteLine(powerRate);
int lifeSupport = parseBinary.GetLifeSupportRating(binaryList);
Console.WriteLine(lifeSupport);
