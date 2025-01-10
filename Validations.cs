using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OmegaSuduko.Program;

namespace OmegaSuduko
{
    internal class Validations
    {
        // A hashset that contains all the legal characters that can appear in the suduko's string.
        public static HashSet<int> validCharsInString = new HashSet<int>(Enumerable.Range(0, N + 1));

        /// <summary>
        /// The function gets the suduko board's string from the user and validates that every char is valid.
        /// if not, a message pops up with all the information.
        /// </summary>
        /// <returns>returns true if the string is legal and false if not.
        /// </returns>
        public static bool ValidateCharsInString()
        {
            bool isLegal = true;
            for (int i = 0; i<boardString.Length; i++)
            {
                char ch = boardString[i];
                if (!validCharsInString.Contains(ch - '0'))
                {
                    Console.WriteLine($"Invalid character {ch} in position {i+1}!");
                    isLegal = false;
                }
            }
            return isLegal;
        }

        /// <summary>
        /// This function checks if the suduko board's string's length is legald and equals to the
        /// dimension squared.
        /// </summary>
        /// <returns>returns true if the length is valid and false if not.</returns>
        public static bool ValidateStringLength()
        {
            return boardString.Length == N * N;
        }

        /// <summary>
        /// This function checks if the suduko board's string contains a zero. If not, it means that the board
        /// is full and does not need to be solved.
        /// </summary>
        /// <returns>returns true if the string contains a 0 and false if not.</returns>
        public static bool NeedsToBeSolved()
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
        public static bool TotalValidation()
        {
            return ValidateCharsInString() && ValidateStringLength() && NeedsToBeSolved();
        }
    }
}
