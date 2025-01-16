using static OmegaSuduko.Validations;
using static OmegaSuduko.SudokuGame;
using static OmegaSuduko.StringAndBoard;
namespace OmegaSuduko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string boardString = "";
            int boardDimension;
            while (true)
            {
                Console.Write("Please enter the suduk board's dimension, enter (-1) to stop: ");
                boardDimension = int.Parse(Console.ReadLine());
                if (boardDimension == -1)
                {
                    Console.WriteLine("Goodbye, thank you for using the suduko solver!");
                    return;
                }
                if (ValidateBoardDimension(boardDimension))
                {
                    Console.Write("Please enter the suduko board's representing string: ");
                    boardString = Console.ReadLine();
                }
                if (TotalValidation(boardString, boardDimension))
                {
                    OmegaSuduko.SudokuGame suduko = new SudokuGame(boardDimension, boardString);
                    int[,] board = suduko.GetSudukoBoard();
                    Console.WriteLine("\nThe board you inserted is: ");
                    PrintSudukoBoard(board, boardDimension);
                    suduko.FilterTheBoard(boardDimension);
                    suduko.Solve(boardDimension);
                    Console.WriteLine("\nThe solved board is: ");
                    PrintSudukoBoard(board, boardDimension);
                    Console.Write("\nThe solved board's representing string is: " + BoardToString(board, boardDimension));
                    Console.WriteLine();
                }
            }
        }
    }
}
