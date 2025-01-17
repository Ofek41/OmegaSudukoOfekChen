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
        protected int boardDimension;
        protected int[,] sudokuBoard;
        protected HashSet<int>[,] hashBoard;

        // The class's constructor:
        public SudokuGame(int boardDimension, string boardString)
        {
            this.boardDimension = boardDimension;
            this.sudokuBoard = StringToBoard(boardDimension, boardString);
            this.hashBoard = new HashSet<int>[boardDimension, boardDimension];
        }

        /// <summary>
        /// Returns the sudoku board matrix.
        /// </summary>
        public int[,] GetSudokuBoard()
        {
            return sudokuBoard;
        }
    }
}