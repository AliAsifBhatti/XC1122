using System;
using System.Linq;

namespace Sudoku
{
    class SudokuPuzzleValidator
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };
            Console.WriteLine(ValidateSudoku(goodSudoku1));
            Console.WriteLine(ValidateSudoku(goodSudoku2));
            Console.WriteLine(ValidateSudoku(badSudoku1));
            Console.WriteLine(ValidateSudoku(badSudoku2));
            Console.Read();
        }

        /// <summary>
        /// Validate the soduko
        /// </summary>
        /// <param name="puzzle">soduko</param>
        /// <returns>True if sudoku is valid else False</returns>
        static bool ValidateSudoku(int[][] puzzle)
        {
            var flag = true;
            for (int i = 0; i < puzzle.Length; i++)
            {
                flag = ValidateRules(puzzle[i]);
                if (!flag)
                    return false;
                var results = puzzle.Select(column => column.Skip(i).FirstOrDefault());
                flag = ValidateRules(results.ToArray());
                if (!flag)
                    return false;
            };
            return true;
        }

        /// <summary>
        /// This function validate rules of soduko on an an int[]
        /// 1) All the values in the array are distinct
        /// 2) Each value in array is greater than 0 and is less than the size of an array
        /// </summary>
        /// <param name="array">int[]</param>
        /// <returns>True if array fulfills the criteria oherwise false</returns>
        static bool ValidateRules(int[] array)
        {
            if (array.Distinct().Count() != array.Length || array.Where(d => d > 0 && d <= array.Length).Count() != array.Length)
                return false;
            return true;
        }
    }
}