using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmegaSuduko.StringAndBoard;
using static OmegaSuduko.Program;

namespace OmegaSuduko
{
    internal class FirstFiltering
    {
        public int[,] sudukoBoard = StringToBoard();

        // Creating a matrix of HashSets. Every hashset represents the possible numbers that the
        //suduko board's cell can contain.
        public HashSet<int>[,] hashSudukoBoard = new HashSet<int>[N, N];
    }
}
