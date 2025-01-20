using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSuduko
{
    public static class BoardValidations
    {
        /// <summary>
        /// This function validates that the inital board does not contain duplicated numbers in the a
        /// same row.
        /// </summary>
        /// <param name="board">the sudoku board</param>
        /// <param name="boardDimension">the board dimension</param>
        /// <returns>retrun true if the board is valid and false if not</returns>
        public static bool ValidateBoardRows(int[,] board, int boardDimension)
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
                            Console.WriteLine($"Invalid board - The same number ({number}) in row {row+1}.");
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
        public static bool ValidateBoardColumns(int[,] board, int boardDimension)
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
                            Console.WriteLine($"Invalid board - The same number ({number}) in column {column + 1}.");
                            return false;
                        }
                        seenNumbers.Add(number);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// This function validates that a specific inner square in the board does not contain duplicated
        /// numbers.
        /// </summary>
        /// <param name="board">the sudoku board</param>
        /// <param name="beginRow">the row we begin checking from</param>
        /// <param name="beginColumn">the column we begin checking from</param>
        /// <param name="squareSize">the inner square size</param>
        /// <returns>returns true if the board is valid and false if not</returns>
        public static bool ValidateSingleInnerSquare(int[,] board, int beginRow, int beginColumn, int squareSize)
        {
            HashSet<int> seenNumbers = new HashSet<int>();
            for (int row = beginRow; row < beginRow + squareSize; row++)
            {
                for (int column = beginColumn; column < beginColumn + squareSize; column++)
                {
                    int number = board[row, column];
                    if (number!=0)
                    {
                        if (seenNumbers.Contains(number))
                        {
                            Console.WriteLine($"Invalid board - The same number ({number}) in inner square from" +
                                $"{beginRow + 1}, {beginColumn + 1}.");
                            return false;
                        }
                        seenNumbers.Add(number);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// This function validates all the inner squares in the board using the function which validates a
        /// single one.
        /// </summary>
        /// <param name="board">the sudoku board</param>
        /// <param name="boardDimension">the board dimension</param>
        /// <returns>returns true if all the inner squares are valid and false if not.</returns>
        public static bool ValidateAllInnerSquares(int[,] board, int boardDimension)
        {
            int squareSize = (int)Math.Sqrt(boardDimension);
            for (int beginRow = 0; beginRow < boardDimension; beginRow+=squareSize)
            {
                for (int beginColumn = 0; beginColumn < boardDimension; beginColumn+=squareSize)
                {
                    if (!ValidateSingleInnerSquare(board, beginRow, beginColumn, squareSize))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This function validates all the rows, columns and inner squares in the initial board using
        /// the previous functions.
        /// </summary>
        /// <param name="board">the sudoku board</param>
        /// <param name="boardDimension">the board dimension</param>
        /// <returns>returns true if the board is valid and false if not</returns>
        public static bool ValidateAllTheBoard(int[,] board, int boardDimension)
        {
            return ValidateBoardRows(board, boardDimension) && ValidateBoardColumns(board, boardDimension) &&
                ValidateAllInnerSquares(board, boardDimension);
        }
    }
}