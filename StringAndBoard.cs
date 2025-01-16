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
        /// This function converts the suduko board's string to its matrix form.
        /// </summary>
        /// <returns>The matrix form of the string.
        /// </returns>
        public static int[,] StringToBoard(int boardDimension, string boardString)
        {
            int[,] sudukoBoard = new int[boardDimension, boardDimension];
            for (int i = 0; i < boardDimension*boardDimension; i++)
            {
                sudukoBoard[i / boardDimension, i % boardDimension] = boardString[i] - '0';
            }
            return sudukoBoard;
        }

        /// <summary>
        /// This function converts the suduko board to its string form.
        /// </summary>
        /// <param name="sudukoBoard">The suduko board represented as a matrix.</param>
        /// <returns>The string form of the board.
        /// </returns>
        public static string BoardToString(int[,] sudukoBoard, int boardDimension)
        {
            string sudukoString = "";
            for (int i =0; i < boardDimension; i++)
            {
                for (int j = 0; j < boardDimension; j++)
                {
                    sudukoString += sudukoBoard[i, j].ToString();
                }
            }
            return sudukoString;
        }

        /// <summary>
        /// This function prints the integer matrix suduko board.
        /// </summary>
        public static void PrintSudukoBoard(int[,] sudukoBoard, int boardDimension)
        {
            for (int i =0; i < boardDimension; i++)
            {
                for (int j = 0; j < boardDimension; j++)
                {
                    Console.Write(sudukoBoard[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
