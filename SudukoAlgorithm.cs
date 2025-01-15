using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmegaSuduko.Filtering;
using static OmegaSuduko.Program;

namespace OmegaSuduko
{
    internal class SudukoAlgorithm
    {
        /// <summary>
        /// This function if a number in a cell is valid according to the suduko rules.
        /// </summary>
        /// <param name="row">the row's index of the number we are currently checking</param>
        /// <param name="column">the column's index of the number we are currently checking</param>
        /// <param name="number">the number we are currently checking</param>
        /// <returns>returns true if the number is valid and false if not</returns>
        public static bool IsNumberValid(int row, int column, int number)
        {
            return !ExistsInRow(row, number) &&
                !ExistsInColumn(column, number) &&
                !ExistsInInnerSquare(row, column, number);
        }

        /// <summary>
        /// This function finds the cell in the board with the least options of numbers, and that is for
        /// making the algorithm more efficent.
        /// </summary>
        /// <param name="row">the row index of the cell found</param>
        /// <param name="column">the column index of the cell found</param>
        /// <returns>returns true if a cell was found and false if not</returns>
        public static bool FindNextSmallestCell(out int row, out int column)
        {
            row = -1;
            column = -1;
            int counterMinimumOptions = N+1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (sudukoBoard[i,j] == 0 && hashBoard[i,j].Count > 0)
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
        /// <returns>returns true if the board was solved successfully and false if not.</returns>
        public static bool Solve()
        {
            if (!FindNextSmallestCell(out int row, out int column))
                return true;
            foreach (int number in hashBoard[row,column])
            {
                if (IsNumberValid(row, column, number))
                {
                    sudukoBoard[row, column] = number;

                    if (Solve())
                        return true;

                    sudukoBoard[row, column] = 0;
                }
            }
            return false;
        }
    }
}
