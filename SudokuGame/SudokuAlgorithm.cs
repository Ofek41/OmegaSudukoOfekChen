using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSuduko
{
    internal class SudokuAlgorithm : SudokuFiltering
    {
        // Inherting constructor:
        public SudokuAlgorithm(int boardDimension, string boardString)
        : base(boardDimension, boardString)
        {
        }
        /// <summary>
        /// This function if a number in a cell is valid according to the sudoku rules.
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
                    if (sudokuBoard[i, j] == 0 && hashBoard[i, j].Count > 0)
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
        /// This function solves the sudoku board while using the BACKTRACKING algorithm,
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
                    sudokuBoard[row, column] = number;

                    if (Solve(boardDimension))
                        return true;

                    sudokuBoard[row, column] = 0;
                }
            }
            return false;
        }

    }
}
