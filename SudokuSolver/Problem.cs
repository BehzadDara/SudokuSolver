using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public static class Problem
    {
        #region Init

        public static int[][] Solve(int[][] sudoku)
        {
            #region Begin
            Console.WriteLine($"Answer of the sudoku is:");
            #endregion

            #region Solve
            var result = FindSolution(sudoku, Tuple.Create(0, 0), 1);
            #endregion

            #region End
            PrintResult(result);
            return result;
            #endregion
        }

        #endregion

        #region Solution

        private static int[][] FindSolution(int[][] sudoku, Tuple<int, int> position, int k)
        {
            if (IsAnswer(sudoku))
                return sudoku;

            if (sudoku[position.Item1][position.Item2] == 0)
            {
                if (k == 10)
                    return sudoku;

                if (IsSafeChoice(sudoku, position, k))
                {
                    sudoku[position.Item1][position.Item2] = k;

                    var result = FindSolution(sudoku, NextPosition(position), 1);
                    if (IsAnswer(result))
                        return result;

                    sudoku[position.Item1][position.Item2] = 0;
                }

                return FindSolution(sudoku, position, k + 1);

            }
            else
            {
                return FindSolution(sudoku, NextPosition(position), 1);
            }

        }

        private static Tuple<int, int> NextPosition(Tuple<int, int> position)
        {
            var i = position.Item1;
            var j = position.Item2;

            if (i == 8)
            {
                if (j == 8)
                {
                    throw new Exception();
                }

                j++;
                i = 0;

            }
            else
            {
                i++;
            }

            return Tuple.Create(i, j);
        }

        private static bool IsSafeChoice(int[][] sudoku, Tuple<int, int> position, int k)
        {
            var i = position.Item1;
            var j = position.Item2;

            #region check the row
            if (sudoku[i].Contains(k))
                return false;
            #endregion

            #region check the column
            foreach (var row in sudoku)
            {
                if (row[j] == k)
                    return false;
            }
            #endregion

            #region check the square
            var baseI = i / 3;
            var baseJ = j / 3;
            for (var p = 0; p < 3; p++)
            {
                for (var q = 0; q < 3; q++)
                {
                    if (sudoku[3 * baseI + p][3 * baseJ + q] == k)
                        return false;
                }
            }
            #endregion

            return true;
        }

        private static bool IsAnswer(int[][] sudoku)
        {
            foreach(var row in sudoku)
            {
                if (row.Contains(0))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        private static void PrintResult(int[][] result)
        {
            for(var i = 0; i < 9; i++)
            {
                for(var j = 0; j < 9; j++)
                {
                    Console.Write($"{result[i][j]}  ");
                    if(j == 2 || j == 5)
                    {
                        Console.Write("|  ");
                    }
                }
                Console.WriteLine();
                if(i == 2 || i == 5)
                {
                    Console.WriteLine("--------------------------------");
                }
            }
        }
    }
}
