using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Bingo
    {
        List<int> Numbers { get; set; }
        public delegate void Announcer(int x);
        public delegate void Announcer2(int[,,] board, int lastCall);

        public Bingo(string numbers)
        {
            Numbers = new List<int>();
            var splitNumbers = numbers.Split(',');
            foreach(var number in splitNumbers)
            {
                if(!string.IsNullOrEmpty(number.Trim()))
                    Numbers.Add(int.Parse(number));
            }
        }
        public void AnnounceResult(int numberCalled)
        {
            Console.WriteLine($"The number that is called is: {numberCalled}!");
        }
        public void CalculateResult(int[,,] board, int lastCall)
        {
            List<int> unMarkedNumber = new List<int>();
            for (int rows = 0; rows < 5; rows++)
            {
                for (int columns = 0; columns < 5; columns++)
                {
                    if (board[rows, columns, 1] == -1)
                    {
                        unMarkedNumber.Add(board[rows, columns, 0]);
                    }
                }
            }
            int sum = unMarkedNumber.Sum();
            int result = sum * lastCall;
            Console.WriteLine($"The winner is x with the result {result}");
        }
        public List<int[,,]> SetupBoards(List<string> bingoGame)
        {
            int game = 1;
            int index = 0;
            List<int[,,]> boards = new List<int[,,]>();
            while (index < bingoGame.Count)
            {
                int section = game * 5;
                int[,,] board = new int[5, 5,2];
                int colPosition = 0;
                while (index < section)
                {
                    string row = bingoGame[index];
                    var splitRow = row.Split(" ");
                    List<int> parsedRow = new List<int>();
                    foreach(var splitNumber in splitRow)
                    {
                        if (!string.IsNullOrWhiteSpace(splitNumber))
                        {
                            int number = int.Parse(splitNumber.ToString());
                            parsedRow.Add(number);
                        }
                    }
                    int rowPosition = 0;
                    foreach (int number in parsedRow)
                    {
                        board[colPosition, rowPosition, 0] = number;
                        board[colPosition, rowPosition, 1] = -1;
                        rowPosition++;
                    }
                    index++;
                    colPosition++;
                }
                game++;
                boards.Add(board);
            }
            return boards;
        }
        public void PlayGame(List<int[,,]> boards)
        {
            bool winner = false;
            foreach(int gameNumber in Numbers)
            {
               var winngngBoards =  MarkBoards(gameNumber, boards);
               boards = boards.Except(winngngBoards).ToList();
            }
        }

        private List<int[,,]> MarkBoards(int gameNumber, List<int[,,]> boards)
        {
            Announcer announcer = new Announcer(AnnounceResult);
            announcer(gameNumber);
            List<int[,,]> winningBoards =   new List<int[,,]>();
            foreach (var board in boards)
            {
               var winner = MarkBoard(gameNumber, board);
                if (winner)
                {
                    winningBoards.Add(board);
                }
            }
            return winningBoards;
        }

        private bool MarkBoard(int gameNumber, int[,,] board)
        {
            bool winner = false;
            var match = FindIndexOfMatchingNumber(gameNumber, board);
            if(match.row != null && match.column != null)
            {
                board[match.row.Value, match.column.Value, 1] = 1;
                winner = CheckIfWon(board);
                if (winner)
                {
                    Announcer2 announcer = new Announcer2(CalculateResult);
                    announcer(board, gameNumber);
                }
            }
            return winner;
        }

        private (int? row, int? column) FindIndexOfMatchingNumber(int gameNumber, int[,,] board)
        {
            for(int rows = 0; rows < 5; rows++)
            {                
                for (int columns = 0; columns < 5; columns++)
                {
                    if(board[rows, columns,0] == gameNumber)
                    {
                        return (rows, columns);
                    }
                }
            }
            return (null, null);
        }

        private bool CheckIfWon(int[,,] board)
        {
            bool winner = false;
            for (int rows = 0; rows < 5; rows++)
            {
                int row = 0;
                for (int columns = 0; columns < 5; columns++)
                {
                    if(board[rows, columns, 1] == 1)
                    {
                        row++;
                    }
                }
                if(row == 5)
                    return true;
            }
            for (int columns = 0; columns < 5; columns++)
            {
                int column = 0;
                for (int rows = 0; rows < 5; rows++)
                {
                    if (board[rows, columns, 1] == 1)
                    {
                        column++;
                    }
                }
                if (column == 5)
                    return true;
            }
            return winner;
        }
    }   
}
