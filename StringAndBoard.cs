using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmegaSuduko.Program;

namespace OmegaSuduko
{
    public class StringAndBoard
    {
        // This function converts the suduko board's string to the board itself.
        public static int[,] StringToBoard()
        {
            int[,] sudukoBoard = new int[N, N];
            for (int i = 0; i < N*N; i++)
            {
                sudukoBoard[i / N, i % N] = boardString[i] - '0';
            }
            return sudukoBoard;
        }

        // This function converts the suduko board to the string that represents it.
        public static string BoardToString(int[,] sudukoBoard)
        {
            string sudukoString = "";
            for (int i =0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    sudukoString += sudukoBoard[i, j].ToString();
                }
            }
            return sudukoString;
        }
    }
}
