#region Problem
/*
You are given a Sudoku grid with some empty cells. 
You need to write a code such that all the cells are filled in a proper fashion according to Sudoku rules which are:
    Each of the digits 1-9 must occur exactly once in each row.
    Each of the digits 1-9 must occur exactly once in each column.
    Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
*/
#endregion

#region Solution

namespace SudokuSolver;

public class Program
{
    public static void Main()
    {
        int[][] sudoku = {
            new int[] { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            new int[] { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            new int[] { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            new int[] { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            new int[] { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            new int[] { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            new int[] { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            new int[] { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            new int[] { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Problem.Solve(sudoku);
    }
}

#endregion
