using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

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
            PrintVerifiedCheck (MakeThreeMatrix (), MakeThreeMatrixResult ());
            PrintVerifiedCheck (MakeFourMatrix (), MakeFourMatrixResult ());
            PrintVerifiedCheck (MakeFiveMatrix (), MakeFiveMatrixResult ());
        }

        private static void PrintVerifiedCheck(int[][] theMatrix, int[][] expectedResult)
        {
            Console.WriteLine ("Processing matrix:");
            Console.Write (ArrayTools.GetContentsAsString<int> (theMatrix));
            Console.WriteLine ();

            Rotate (theMatrix, true);

            Console.WriteLine ("Result is:");
            Console.WriteLine (ArrayTools.GetContentsAsString<int> (theMatrix));

            if (!ArrayTools.AreMatricesEqual (theMatrix, expectedResult))
            {
                Console.WriteLine ("Result was not expected result of:");
                Console.WriteLine (ArrayTools.GetContentsAsString<int> (expectedResult));
            }

            Console.WriteLine ();
        }


        private static void Rotate(int[][] theMatrix, bool toRight)
        {
            // The +1 is to ensure the quandrant's chosen cells are biased to one side
            // If both had +1 than the iterated quadrant would have more than 1/4 the cells
            // If neither had +1 than the iterated quadrant would have less than 1/4 the cells
            int quadYLen = theMatrix.Length / 2;
            int quadXLen = (theMatrix[0].Length + 1) / 2;

            for (int y = 0; y < quadYLen; y++)
                for (int x = 0; x < quadXLen; x++)
                    RotateValue (theMatrix, toRight, x, y);
        }

        private static void RotateValue(int[][] theMatrix, bool toRight, int currX, int currY)
        {
            int firstVal = theMatrix[currY][currX];
            int newX;
            int newY;

            // Move left to find values to bring back to location to the right
            for (int i = 0; i < 3; i++)
            {
                if (toRight)
                {
                    newX = currY;
                    newY = (theMatrix.Length - 1) - currX;
                }
                else
                {
                    newX = (theMatrix.Length - 1) - currY;
                    newY = currX;
                }

                theMatrix[currY][currX] = theMatrix[newY][newX];

                currX = newX;
                currY = newY;
            }

            theMatrix[currY][currX] = firstVal;
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
