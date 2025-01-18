using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSuduko
{
    internal class BoardValidations
    {
        /// <summary>
        /// This function validates that the inital board does not contain duplicated numbers in the a
        /// same row.
        /// </summary>
        /// <param name="board">the sudoku board</param>
        /// <param name="boardDimension">the board dimension</param>
        /// <returns>retrun true if the board is valid and false if not</returns>
        public bool ValidateBoardRows(int[,] board, int boardDimension)
        {
            for (int row = 0; row < boardDimension; row++)
            {
                HashSet<int> seenNumbers = new HashSet<int>();
                for (int column = 0; column < boardDimension; column++)
                {
                    int number = board[row, column];
                    if (number!=0)
                    {
                        if (seenNumbers.Contains(number))
                        {
                            Console.WriteLine($"The same number {number} in row {row+1}.");
                            return false;
                        }
                        seenNumbers.Add(number);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// This function validates that the inital board does not contain duplicated numbers in the a
        /// column.
        /// </summary>
        /// <param name="board">the sudoku board</param>
        /// <param name="boardDimension">the board dimension</param>
        /// <returns>retrun true if the board is valid and false if not</returns>
        public bool ValidateColumns(int[,] board, int boardDimension)
        {
            for (int column = 0; column < boardDimension; column++)
            {
                HashSet<int> seenNumbers = new HashSet<int>();
                for (int row = 0; row < boardDimension; row++)
                {
                    int number = board[row, column];
                    if (number != 0)
                    {
                        if (seenNumbers.Contains(number))
                        {
                            Console.WriteLine($"The same number {number} in column {column + 1}.");
                            return false;
                        }
                        seenNumbers.Add(number);
                    }
                }
            }
            return true;
        }
    }
}
