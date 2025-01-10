using System;
using System.Collections.Generic;
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
                        hashBoard[i, j] = new HashSet<int>(sudukoBoard[i, j]);
                    else
                        hashBoard[i, j] = new HashSet<int>(Enumerable.Range(1, N));
                }
            }
        }
    }
}
