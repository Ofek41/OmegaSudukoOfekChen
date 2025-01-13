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
    }
}
