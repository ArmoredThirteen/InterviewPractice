using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting;

namespace _04_Questions_ArraysAndStrings
{
    // Rotate an NxN matrix 90 degrees left or right.
    // Perform rotation in place to ensure overhead is minimal.
    class RotateMatrix : Example
    {
        public static string header = "Rotate Matrix";
        public static string description = "Rotate given NxN matrix 90 degrees";

        public static void RunExample()
        {
            PrintVerifiedCheck (MakeFiveMatrix (), MakeFiveMatrixResult ());
        }

        private static void PrintVerifiedCheck(int[][] theMatrix, int[][] expectedResult)
        {
            Console.WriteLine ("Processing matrix:");
            Console.WriteLine (ArrayTools.GetContentsAsString<int> (theMatrix));
            Console.WriteLine ();

            RotateRight (theMatrix);

            Console.WriteLine ("Result is:");
            Console.WriteLine (ArrayTools.GetContentsAsString<int> (theMatrix));
            Console.WriteLine ();

            if (!ArrayTools.AreMatricesEqual (theMatrix, expectedResult))
            {
                Console.WriteLine ("Result was not expected result of:");
                Console.WriteLine (ArrayTools.GetContentsAsString<int> (expectedResult));
            }

            Console.WriteLine ();
        }


        private static void RotateRight(int[][] theMatrix)
        {
            // The +1 is to ensure the quandrant's chosen cells are biased to one side
            // If both had +1 than the iterated quadrant would have more than 1/4 the cells
            // If neither had +1 than the iterated quadrant would have less than 1/4 the cells
            for (int x = 0; x < theMatrix.Length / 2; x++)
            {
                for (int y = 0; y < (theMatrix[x].Length + 1) / 2; y++)
                {
                    Console.Write (theMatrix[x][y].ToString () + new string (' ', 5 - theMatrix[x][y].ToString ().Length));
                }
                Console.WriteLine ();
            }
        }


        private static int[][] MakeThreeMatrix()
        {
            return new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };
        }

        private static int[][] MakeThreeMatrixResult()
        {
            return new int[][] {
                new int[] { 7, 4, 1 },
                new int[] { 8, 5, 2 },
                new int[] { 9, 6, 3 },
            };
        }

        private static int[][] MakeFourMatrix()
        {
            return new int[][] {
                new int[] { 1,  2,  3,  4 },
                new int[] { 5,  6,  7,  8 },
                new int[] { 9,  10, 11, 12 },
                new int[] { 13, 14, 15, 16 },
            };
        }

        private static int[][] MakeFourMatrixResult()
        {
            return new int[][] {
                new int[] { 13, 9,  5, 1 },
                new int[] { 14, 10, 6, 2 },
                new int[] { 15, 11, 7, 3 },
                new int[] { 16, 12, 8, 4 },
            };
        }

        private static int[][] MakeFiveMatrix()
        {
            return new int[][] {
                new int[] { 1,  2,  3,  4,  5 },
                new int[] { 6,  7,  8,  9,  10 },
                new int[] { 11, 12, 13, 14, 15 },
                new int[] { 16, 17, 18, 19, 20 },
                new int[] { 21, 22, 23, 24, 25 },
            };
        }

        private static int[][] MakeFiveMatrixResult()
        {
            return new int[][] {
                new int[] { 21, 16, 11, 6,  1 },
                new int[] { 22, 17, 12, 7,  2 },
                new int[] { 23, 18, 13, 8,  3 },
                new int[] { 24, 19, 14, 9,  4 },
                new int[] { 25, 20, 15, 10, 5 },
            };
        }

    }
}
