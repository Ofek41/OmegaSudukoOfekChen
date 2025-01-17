using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSuduko
{
    public class StringAndBoard
    {
        /// <summary>
        /// This function converts the sudoku board's string to its matrix form.
        /// </summary>
        /// <returns>The matrix form of the string.
        /// </returns>
        public static int[,] StringToBoard(int boardDimension, string boardString)
        {
            int[,] sudokuBoard = new int[boardDimension, boardDimension];
            for (int i = 0; i < boardDimension*boardDimension; i++)
            {
                sudokuBoard[i / boardDimension, i % boardDimension] = boardString[i] - '0';
            }
            return sudokuBoard;
        }

        /// <summary>
        /// This function converts the sudoku board to its string form.
        /// </summary>
        /// <param name="sudokuBoard">The sudoku board represented as a matrix.</param>
        /// <returns>The string form of the board.
        /// </returns>
        public static string BoardToString(int[,] sudokuBoard, int boardDimension)
        {
            string sudokuString = "";
            for (int i =0; i < boardDimension; i++)
            {
                for (int j = 0; j < boardDimension; j++)
                {
                    sudokuString += sudokuBoard[i, j].ToString();
                }
            }
            return sudokuString;
        }

        /// <summary>
        /// This function prints the integer matrix sudoku board.
        /// </summary>
        public static void PrintSudokuBoard(int[,] sudokuBoard, int boardDimension)
        {
            for (int i =0; i < boardDimension; i++)
            {
                for (int j = 0; j < boardDimension; j++)
                {
                    Console.Write(sudokuBoard[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
