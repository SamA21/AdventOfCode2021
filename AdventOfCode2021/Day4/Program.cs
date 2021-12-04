using AdventHelper;
using Day4;

AdventTextReader reader = new AdventTextReader();
string inputLocation = $"data.txt";
var bingoGame = reader.GetListFromFile(inputLocation);
string numbers = bingoGame.First();
bingoGame.RemoveAt(0);
Bingo bingo = new Bingo(numbers);
var boards = bingo.SetupBoards(bingoGame);
bingo.PlayGame(boards);

