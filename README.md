# PuzzleMatrix

Given the following:
public static class PuzzleSolver
{
public static string[] DICTIONARY = {"OX","CAT","TOY","AT","DOG","CATAPULT","T"};

static bool IsWord(string testWord)
{
if (DICTIONARY.Contains(testWord))
return true;
return false;
}
}

**Implement the function public static int FindWords(char[,] puzzle)

FindWords should return the number of all non-distinct occurrences of the words found in the array, horizontally, vertically or diagonally, and also the reverse in each direction.

Example Input 1:
CAT
XZT
YOT
Example Output 1:
8
(AT, AT, CAT, OX, TOY, T, T, T)

Example Input 2:
CATAPULT
XZTTOYOO
YOTOXTXX  

Example Output 2:
22
