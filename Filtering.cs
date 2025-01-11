using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmegaSuduko.Program;
using static OmegaSuduko.StringAndBoard;

namespace OmegaSuduko
{
    internal class Filtering
    {
        public static int[,] sudukoBoard = StringToBoard(); // Importing the suduko board

        // Making a hashset matrix. Every cell in the matrix represents the inital possible numbers
        // that the original suduko board's cell can contain - from 1 to N.
        public static HashSet<int>[,] hashBoard = new HashSet<int>[N, N];


        /// <summary>
        /// This function inits the hashboard: if the number in the same cell in the suduko board matrix
        /// itself is not zero, so set it to this number since it is certain. If it is zero, set the 
        /// hashset to contain every possible number from 1 to N.
        /// </summary>
        public static void InitHashBoard()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (sudukoBoard[i, j] != 0)
                        hashBoard[i, j] = new HashSet<int>(new[] { sudukoBoard[i, j] });
                    else
                        hashBoard[i, j] = new HashSet<int>(Enumerable.Range(1, N));
                }
            }
        }

        /// <summary>
        /// This function checks if the number exists in the row.
        /// </summary>
        /// <param name="row">the row we are currently checking</param>
        /// <param name="number">the number we check if exists in row</param>
        /// <returns>returns true if the number exists in the row and false if not</returns>
        public static bool ExistsInRow(int row, int number)
        {
            for (int column = 0; column < N; column++)
            {
                if (sudukoBoard[row, column] == number)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// This function checks if the number exists in the column.
        /// </summary>
        /// <param name="column">the column we are currently checking</param>
        /// <param name="number">the number we check if exists in row</param>
        /// <returns>returns true if the number exists in the column and false if not</returns>
        public static bool ExistsInColumn(int column, int number)
        {
            for (int row = 0; row < N; row++)
            {
                if (sudukoBoard[row, column] == number)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// This function checks if the number exists in the inner square of the suduko board
        /// </summary>
        /// <param name="row">the row we are currently checking</param>
        /// <param name="column">the column we are currently checking</param>
        /// <param name="number">the number we check if exists in the square</param>
        /// <returns>returns true if the number exists in the inner square and false if not</returns>
        public static bool ExistsInInnerSquare(int row, int column, int number)
        {
            int squareSize = (int)Math.Sqrt(N);
            int rowSquareBegin = (row / squareSize) * squareSize;
            int columnSquareBegin = (column / squareSize) * squareSize;
            for (int i = 0; i < squareSize; i++)
            {
                for (int j = 0; j < squareSize; j++)
                {
                    if (sudukoBoard[rowSquareBegin + i, columnSquareBegin + j] == number)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This function updates the hashboard matrix that every set will contain only the possible numbers
        /// according to the suduko rules - that a certain number cannot appear twice or more in the same
        /// row, column or inner square.
        /// </summary>
        public static void UpdateHashBoardMatrix()
        {
            for (int row = 0; row < N; row++)
            {
                for (int column = 0; column < N; column++)
                {
                    if (sudukoBoard[row,column]==0)
                    {
                        HashSet<int> possibleNumbers = new HashSet<int>(hashBoard[row, column]);

                        // for every number in the set check it according to the suduko rules:
                        foreach (int number in new HashSet<int>(possibleNumbers))
                        {
                            if (ExistsInRow(row, number) || ExistsInColumn(column, number) ||
                                ExistsInInnerSquare(row, column, number))
                                hashBoard[row, column].Remove(number);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This function updates empty cells in the suduko board matrix that according to the hasboard
        /// matrix, have only one possible number that can appear in them.
        /// </summary>
        /// <returns>returns true if any update was made in the board, and false if not.</returns>
        public static bool InsertCertainNumbers()
        {
            bool isUpdated = false;
            for (int row = 0; row < N; row++)
            {
                for (int column = 0; column < N; column++)
                {
                    if (sudukoBoard[row,column]==0 && hashBoard[row,column].Count == 1)
                    {
                        // A certain number was found - so we need to update the suduko board:
                        sudukoBoard[row, column] = hashBoard[row, column].First();
                        hashBoard[row, column] = new HashSet<int> { sudukoBoard[row, column] };
                        isUpdated = true;
                    }
                }
            }
            return isUpdated;
        }
    }
}
