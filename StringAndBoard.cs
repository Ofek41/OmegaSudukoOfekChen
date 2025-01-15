using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmegaSuduko.Program;
using static OmegaSuduko.Filtering;

namespace OmegaSuduko
{
    public class StringAndBoard
    {
        /// <summary>
        /// This function converts the suduko board's string to its matrix form.
        /// </summary>
        /// <returns>The matrix form of the string.
        /// </returns>
        public static int[,] StringToBoard()
        {
            int[,] sudukoBoard = new int[N, N];
            for (int i = 0; i < N*N; i++)
            {
                sudukoBoard[i / N, i % N] = boardString[i] - '0';
            }
            return sudukoBoard;
        }

        /// <summary>
        /// This function converts the suduko board to its string form.
        /// </summary>
        /// <param name="sudukoBoard">The suduko board represented as a matrix.</param>
        /// <returns>The string form of the board.
        /// </returns>
        public static string BoardToString(int[,] sudukoBoard)
        {
            string sudukoString = "";
            for (int i =0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sudukoString += sudukoBoard[i, j].ToString();
                }
            }
            return sudukoString;
        }

        /// <summary>
        /// This function prints the integer matrix suduko board.
        /// </summary>
        public static void PrintRegularSudukoBoard()
        {
            for (int i =0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(sudukoBoard[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// This function prints the hashsets matrix suduko board in form of regular integer one.
        /// </summary>
        public static void PrintSetsSudukoBoard()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(hashBoard[i,j].First() + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
