using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmegaSuduko.StringAndBoard;

namespace OmegaSuduko
{
    public class SudokuGame
    {
        private int boardDimension;
        private int[,] sudukoBoard;
        private HashSet<int>[,] hashBoard;

        // The class's constructor:
        public SudokuGame(int boardDimension, string boardString)
        {
            this.boardDimension = boardDimension;
            // Create the board once using the existing function:
            this.sudukoBoard = StringToBoard(boardDimension, boardString);
            // Create the hashBoard with the correct size:
            this.hashBoard = new HashSet<int>[boardDimension, boardDimension];
        }

        /// <summary>
        /// This function inits the hashboard: if the number in the same cell in the suduko board matrix
        /// itself is not zero, so set it to this number since it is certain. If it is zero, set the 
        /// hashset to contain every possible number from 1 to N.
        /// </summary>
        /// <param name="boardDimension">the dimension of the board</param>
        public void InitHashBoard(int boardDimension)
        {
            for (int i = 0; i < boardDimension; i++)
            {
                for (int j = 0; j < boardDimension; j++)
                {
                    if (sudukoBoard[i, j] != 0)
                        hashBoard[i, j] = new HashSet<int>(new[] { sudukoBoard[i, j] });
                    else
                        hashBoard[i, j] = new HashSet<int>(Enumerable.Range(1, boardDimension));
                }
            }
        }

        /// <summary>
        /// This function checks if the number exists in the row.
        /// </summary>
        /// <param name="row">the row we are currently checking</param>
        /// <param name="number">the number we check if exists in row</param>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if the number exists in the row and false if not</returns>
        public bool ExistsInRow(int row, int number, int boardDimension)
        {
            for (int column = 0; column < boardDimension; column++)
            {
                if (sudukoBoard[row, column] == number)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This function checks if the number exists in the column.
        /// </summary>
        /// <param name="column">the column we are currently checking</param>
        /// <param name="number">the number we check if exists in row</param>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if the number exists in the column and false if not</returns>
        public bool ExistsInColumn(int column, int number, int boardDimension)
        {
            for (int row = 0; row < boardDimension; row++)
            {
                if (sudukoBoard[row, column] == number)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This function checks if the number exists in the inner square of the suduko board
        /// </summary>
        /// <param name="row">the row we are currently checking</param>
        /// <param name="column">the column we are currently checking</param>
        /// <param name="number">the number we check if exists in the square</param>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if the number exists in the inner square and false if not</returns>
        public bool ExistsInInnerSquare(int row, int column, int number, int boardDimension)
        {
            int squareSize = (int)Math.Sqrt(boardDimension);
            int rowSquareBegin = (row / squareSize) * squareSize;
            int columnSquareBegin = (column / squareSize) * squareSize;

            for (int i = 0; i < squareSize; i++)
            {
                for (int j = 0; j < squareSize; j++)
                {
                    if (sudukoBoard[rowSquareBegin + i, columnSquareBegin + j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This function updates the hashboard matrix that every set will contain only the possible numbers
        /// according to the suduko rules - that a certain number cannot appear twice or more in the same
        /// row, column or inner square.
        /// </summary>
        /// <param name="boardDimension">the dimension of the board</param>
        public void UpdateHashBoardMatrix(int boardDimension)
        {
            for (int row = 0; row < boardDimension; row++)
            {
                for (int column = 0; column < boardDimension; column++)
                {
                    if (sudukoBoard[row, column] == 0)
                    {
                        HashSet<int> possibleNumbers = new HashSet<int>(hashBoard[row, column]);

                        foreach (int number in new HashSet<int>(possibleNumbers))
                        {
                            if (ExistsInRow(row, number, boardDimension)
                                || ExistsInColumn(column, number, boardDimension)
                                || ExistsInInnerSquare(row, column, number, boardDimension))
                            {
                                hashBoard[row, column].Remove(number);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This function updates empty cells in the suduko board matrix that according to the hasboard
        /// matrix, have only one possible number that can appear in them.
        /// </summary>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if any update was made in the board, and false if not.</returns>
        public bool InsertCertainNumbers(int boardDimension)
        {
            bool isUpdated = false;
            for (int row = 0; row < boardDimension; row++)
            {
                for (int column = 0; column < boardDimension; column++)
                {
                    if (sudukoBoard[row, column] == 0 && hashBoard[row, column].Count == 1)
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

        /// <summary>
        /// This function checks if the hashset board contains any empty set. If so, it means that
        /// the specific cell cannot contain any possible number and the suduko is not solvable.
        /// </summary>
        /// <param name="boardDimensioh">the dimension of the board</param>
        /// <returns>returns true if an empty set was found and false if not.</returns>
        public bool DoesContainEmptySet(int boardDimensioh)
        {
            for (int row = 0; row < boardDimensioh; row++)
            {
                for (int column = 0; column < boardDimensioh; column++)
                {
                    if (sudukoBoard[row, column] == 0 && hashBoard[row, column].Count == 0)
                    {
                        Console.WriteLine($"Impossible insertion was found at row {row + 1}" +
                            $" column {column + 1}.");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// This function gathers all the filtering functions for the boards.
        /// </summary>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if the filtering was performed successfully and false if not.</returns>
        public bool FilterTheBoard(int boardDimension)
        {
            InitHashBoard(boardDimension);
            bool isUpdated;
            do
            {
                UpdateHashBoardMatrix(boardDimension);
                isUpdated = InsertCertainNumbers(boardDimension);
                if (DoesContainEmptySet(boardDimension))
                {
                    Console.WriteLine("This suduko board is not solvable.");
                    return false;
                }
            }
            while (isUpdated);
            return true;
        }


        /// <summary>
        /// This function if a number in a cell is valid according to the suduko rules.
        /// </summary>
        /// <param name="row">the row's index of the number we are currently checking</param>
        /// <param name="column">the column's index of the number we are currently checking</param>
        /// <param name="number">the number we are currently checking</param>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if the number is valid and false if not</returns>
        public bool IsNumberValid(int row, int column, int number, int boardDimension)
        {
            return !ExistsInRow(row, number, boardDimension) &&
                !ExistsInColumn(column, number, boardDimension) &&
                !ExistsInInnerSquare(row, column, number, boardDimension);
        }

        /// <summary>
        /// This function finds the cell in the board with the least options of numbers, and that is for
        /// making the algorithm more efficent.
        /// </summary>
        /// <param name="row">the row index of the cell found</param>
        /// <param name="column">the column index of the cell found</param>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if a cell was found and false if not</returns>
        public bool FindNextSmallestCell(out int row, out int column, int boardDimension)
        {
            row = -1;
            column = -1;
            int counterMinimumOptions = boardDimension + 1;
            for (int i = 0; i < boardDimension; i++)
            {
                for (int j = 0; j < boardDimension; j++)
                {
                    if (sudukoBoard[i, j] == 0 && hashBoard[i, j].Count > 0)
                    {
                        // Choosing the cell with the least possible options:
                        counterMinimumOptions = hashBoard[i, j].Count;
                        row = i;
                        column = j;
                    }
                }
            }
            return row != -1 && column != -1;
        }

        /// <summary>
        /// This function solves the suduko board while using the BACKTRACKING algorithm,
        /// using all the previous functions.
        /// </summary>
        /// <param name="boardDimension">the dimension of the board</param>
        /// <returns>returns true if the board was solved successfully and false if not.</returns>
        public bool Solve(int boardDimension)
        {
            if (!FindNextSmallestCell(out int row, out int column, boardDimension))
                return true;
            foreach (int number in hashBoard[row, column])
            {
                if (IsNumberValid(row, column, number, boardDimension))
                {
                    sudukoBoard[row, column] = number;

                    if (Solve(boardDimension))
                        return true;

                    sudukoBoard[row, column] = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the sudoku board matrix.
        /// </summary>
        public int[,] GetSudukoBoard()
        {
            return sudukoBoard;
        }
    }
}