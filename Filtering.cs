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
        public int[,] sudukoBoard = StringToBoard(); // Importing the suduko board

        // Making a hashset matrix. Every cell in the matrix represents the inital possible numbers
        // that the original suduko board's cell can contain - from 1 to N.
        public HashSet<int>[,] hashBoard = new HashSet<int>[N, N];
    }
}
