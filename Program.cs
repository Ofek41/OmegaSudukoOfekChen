using static OmegaSuduko.Validations;
using static OmegaSuduko.Filtering;
using static OmegaSuduko.StringAndBoard;
using static OmegaSuduko.SudukoAlgorithm;
namespace OmegaSuduko
{
    internal class Program
    {
        public static int N; // N represents the dimension of the suduko board.
        public static string boardString;// A string that represents the suduko board.
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter the suduko board dimension, enter (-1) to stop: ");
                N = int.Parse(Console.ReadLine());
                if (N == -1)
                {
                    Console.WriteLine("Goodbye, thank you for using the suduko solver!");
                    return;
                }

            }
        }
    }
}
