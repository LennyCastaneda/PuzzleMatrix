using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PuzzleSolver
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
        int count = 0;

        count += TraverseAllChars(puzzle);

        for (int i = 0; i < puzzle.GetLength(0); i++)
        {
            for (int j = 0; j < puzzle.GetLength(1); j++)
            {
                count += TraverseVertical(puzzle, i, j);
                count += TraverseHorizontal(puzzle, i, j);
                count += TraverseDiagonalPositive(puzzle, i, j);
                count += TraverseDiagonalNegative(puzzle, i, j);

            }
        }
        // FindWords should return the number of all non-distinct occurrences of the words found in the array, horizontally, vertically or diagonally, and also the reverse in each direction.
        // It should be capable of scaling to puzzles with dimensions such as 4x4, 6x9, 9x9.
        return count;
    }

     /**
     * Function to traverse in all 8 different direction 
     * @param row
     * @param col
     */

    // Check if every single character in the user input marix is a word in the dictionary
    public static int TraverseAllChars(char[,] puzzle)
    {
        int count = 0;
        // Iterate through all characters in the puzzle array matrix
        for (int i = 0; i < puzzle.GetLength(0); i++)
        {
            for (int j = 0; j < puzzle.GetLength(1); j++)
            {
                // If the character is is a Dictionary Word, convert to string, increase count by 1.
                if (IsWord(puzzle[i,j].ToString()))
                    count++;
            }
        }
        return count;
    }

    public static int TraverseVertical(char[,] puzzle, int row, int col)
    {
        int count = 0;
        string forward = "";
        string reverse = "";

        // Checks for all possible word combinations in any given column Y-Axis.
        for (int x = row; x >= 0; x--)
        {
            forward += puzzle[x, col];
            // Reverse word
            reverse = puzzle[x, col] + reverse;
            
            // Check if the 'forward' word has more than 1 character and if it's in the dictionary 
            if (x != row && IsWord(forward))
                count++;

            // Check if the 'reverse' word has more than 1 character and if it's in the dictionary 
            if (x != row && IsWord(reverse))
                count++;
        }
        return count;
    }

    public static int TraverseHorizontal(char[,] puzzle, int row, int col)
    {
        int count = 0;
        string forward = "";
        string reverse = "";

        // Checks for all possible word combinations in any given column X-Axis.
        for (int y = col; y >= 0; y--)
        {
            forward += puzzle[row, y];
            // Reverse word
            reverse = puzzle[row, y] + reverse;

            // Check if the 'forward' word has more than 1 character and if it's in the dictionary 
            if (y != col && IsWord(forward))
                count++;

            // Check if the 'reverse' word has more than 1 character and if it's in the dictionary 
            if (y != col && IsWord(reverse))
                count++;
        }
        return count;
    }

    public static int TraverseDiagonalNegative(char[,] puzzle, int row, int col)
    {
        int count = 0;
        string forward = "";
        string reverse = "";

        // X and y need to increment in parallel, not nested in order to get diagonal values 
        for (int x = row, y = col; x < puzzle.GetLength(0) && y < puzzle.GetLength(1); x++, y++)
        {
            forward += puzzle[x, y];
            // Reverse word
            reverse = puzzle[x, y] + reverse;

            // Check if the 'forward' word has more than 1 character and if it's in the dictionary 
            if (x != row && y != col && IsWord(forward))
            {
                count++;
            }

            // Check if the 'reverse' word has more than 1 character and if it's in the dictionary 
            if (x != row && y != col && IsWord(reverse))
            {
                count++;
            }
        }
        return count;
    }

    public static int TraverseDiagonalPositive(char[,] puzzle, int row, int col)
    {
        int count = 0;
        string forward = "";
        string reverse = "";

        // X and y need to increment in parallel, not nested in order to get diagonal values
        for (int x = row, y = col; x >= 0 && y < puzzle.GetLength(1); x--, y++)
        {
            forward += puzzle[x, y];
            // Reverse word
            reverse = puzzle[x, y] + reverse;

            // Check if the 'forward' word has more than 1 character and if it's in the dictionary 
            if (x != row && y != col && IsWord(forward))
            {
                count++;
            }

            // Check if the 'reverse' word has more than 1 character and if it's in the dictionary 
            if (x != row && y != col && IsWord(reverse))
            {;
                count++;
            }
        }
        return count;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the words you wish to search in the dictionary. Separate each word by spaces. Press enter when finished.\n");
        string temp = "";
        int numOfChar = 0;
        char[,] words;

        string[] UserInput = Console.ReadLine().Split(' ');
        // Check to see if UserInpit is not null
        try
        {
            temp = UserInput[0];

            // Instantiate a new words array taking length of UserInput as max row size with temp length as max col size.
            words = new char[UserInput.Length, temp.Length];
            numOfChar = temp.Length;

            // Populates 2D character array
            for (int i = 0; i < UserInput.Length; i++)
            {
                temp = UserInput[i];
                if (numOfChar != temp.Length)
                {
                    Console.WriteLine("All words must have the same number of characters. Please try again.");
                    break;
                }
                char[] ch = temp.ToCharArray();
                for (int j = 0; j < ch.Length; j++)
                {
                    words[i, j] = ch[j];
                }
            }

            PuzzleSolver solver = new PuzzleSolver();

            //char[,] userInput = new char[3, 8] { { 'C', 'A', 'T', 'A', 'P', 'U', 'L', 'T' }, { 'X', 'Z', 'T', 'T', 'O', 'Y', 'O', 'O' }, { 'Y', 'O', 'T', 'O', 'X', 'T', 'X', 'X' } };
            //char[,] userInput = new char[3, 3] { { 'C', 'A', 'T'}, { 'X', 'Z', 'T'}, { 'Y', 'O', 'T'} };

            Console.WriteLine(FindWords(words));
            Console.ReadLine();
        }
        catch(Exception e)
        {
            Console.WriteLine("Input invalid. Please enter a type in words to search");
        }
        Console.Read();
    }
}