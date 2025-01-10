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

        // This function validates the suduko's string and makes sure every char is legal.
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

        // This function validates the suduko string's length.
        public static bool ValidateStringLength()
        {
            return boardString.Length == N * N;
        }

        // This function makes sure the suduko's string contains at least one 0.
        public static bool NeedsToBeSolved()
        {
            if (!boardString.Contains('0'))
            {
                Console.WriteLine("The suduko doesn't contains a 0, therefore doesn't need to be solved.");
                return false;
            }
            return true;
        } 

        // A function that contains all the validations.
        public static bool TotalValidation()
        {
            return ValidateCharsInString() && ValidateStringLength() && NeedsToBeSolved();
        }
    }
}
