using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsCodingPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the words you wish to search in the array. Separate each word by spaces. When finished typing all searchable words press enter.");
        }
    }

    public static class PuzzleSolver
    {
        public static string[] DICTIONARY = { "OX", "CAT", "TOY", "AT", "DOG", "CATAPULT", "T" };

        static bool IsWord(string testWord)
        {
            if (DICTIONARY.Contains(testWord))
                return true;
            return false;
        }

        /** Load the dictionary into tree, Process the array in all directions and add the word to a list, 
         * Method will take row and column numbers as input and it will return the all the unique dictionary words in all directions */
        public static int FindWords(char[,] puzzle)
        {
            string UserInput;
            int NumberOfOccurrances = 0;

            UserInput = Console.ReadLine();

            // FindWords should return the number of all non-distinct occurrences of the words found in the array, horizontally, vertically or diagonally, and also the reverse in each direction.
            // It should be capable of scaling to puzzles with dimensions such as 4x4, 6x9, 9x9.
            return NumberOfOccurrances;
        }
    }
}
