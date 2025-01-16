using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSuduko
{
    internal class Validations
    {

        /// <summary>
        /// The function gets the suduko board's string from the user and validates that every char is valid.
        /// if not, a message pops up with all the information.
        /// </summary>
        /// <returns>returns true if the string is legal and false if not.
        /// </returns>
        public static bool ValidateCharsInString(string boardString, int boardDimension)
        {
            // A hashset that contains all the legal characters that can appear in the suduko's string:
            HashSet<int> validCharsInString = new HashSet<int>(Enumerable.Range(0, boardDimension + 1));
            bool isLegal = true;
            for (int i = 0; i<boardString.Length; i++)
            {
                char character = boardString[i];
                if (!validCharsInString.Contains(character - '0'))
                {
                    Console.WriteLine($"Invalid character '{character}' in position {i+1}.");
                    isLegal = false;
                }
            }
            return isLegal;
        }

        /// <summary>
        /// This function checks if the suduko board's string's length is legal and equals to the
        /// dimension squared.
        /// </summary>
        /// <returns>returns true if the length is valid and false if not.</returns>
        public static bool ValidateStringLength(string boardString, int boardDimension)
        {
            return boardString.Length == boardDimension * boardDimension;
        }

        /// <summary>
        /// This function checks if the suduko board's string contains a zero. If not, it means that the board
        /// is full and does not need to be solved.
        /// </summary>
        /// <returns>returns true if the string contains a 0 and false if not.</returns>
        public static bool NeedsToBeSolved(string boardString)
        {
            if (!boardString.Contains('0'))
            {
                Console.WriteLine("The suduko doesn't contains a 0, therefore doesn't need to be solved.");
                return false;
            }
            return true;
        } 
        

        /// <summary>
        /// This function gathers all the validations.
        /// </summary>
        /// <returns>returns true if all the validations passed successfully, and false if not.</returns>
        public static bool TotalValidation(string boardString, int boardDimension)
        {
            return ValidateCharsInString(boardString, boardDimension)
                && ValidateStringLength(boardString, boardDimension) && NeedsToBeSolved(boardString);
        }

        /// <summary>
        /// This function checks if the N, dimension of the board, is a perfect square so it will be able
        /// to make a board.
        /// </summary>
        /// <returns>returns true if the condition is true, and false if not.</returns>
        public static bool ValidateBoardDimension(int boardDimension)
        {
            if (boardDimension < 0 && boardDimension!=-1)
            {
                Console.WriteLine("Suduko board dimension cannot be a negative number.");
                return false;
            }
            int sqrt = (int)Math.Sqrt(boardDimension);
            if (sqrt * sqrt!=boardDimension)
            {
                Console.WriteLine("Suduko board dimension has to be a perfect square.");
                return false;
            }
            return true;
        }
    }
}
