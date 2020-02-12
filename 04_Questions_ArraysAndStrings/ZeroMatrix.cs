using Sorting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // Given an MxN matrix, find all 0 values and set values in col/row to all 0 as well.f
    class ZeroMatrix : Example
    {
        public static string header = "Zero Matrix";
        public static string description = "Convert aligned rows/cols to 0 if a 0 value is found";

        public static void RunExample()
        {
            PrintVerifiedCheck (MakeExampleOne (), MakeExampleOneResult ());
            PrintVerifiedCheck (MakeExampleTwo (), MakeExampleTwoResult ());
            PrintVerifiedCheck (MakeExampleThree (), MakeExampleThreeResult ());
            PrintVerifiedCheck (MakeExampleFour (), MakeExampleFourResult ());
        }

        private static void PrintVerifiedCheck(int[][] theMatrix, int[][] expectedResult)
        {
            Console.WriteLine ("Processing matrix:");
            Console.Write (ArrayTools.GetContentsAsString<int> (theMatrix));
            Console.WriteLine ();

            Zeroify (theMatrix);

            Console.WriteLine ("Result is:");
            Console.WriteLine (ArrayTools.GetContentsAsString<int> (theMatrix));

            if (!ArrayTools.AreMatricesEqual (theMatrix, expectedResult))
            {
                Console.WriteLine ("Result was not expected result of:");
                Console.WriteLine (ArrayTools.GetContentsAsString<int> (expectedResult));
            }

            Console.WriteLine ();
        }


        // Time complexity of O(2 * x * y) => O(xy)
        // Memory overhead has x+y additional bits, plus BitArray object overhead
        private static void Zeroify(int[][] theMatrix)
        {
            BitArray xZeroIndex = new BitArray (theMatrix[0].Length);
            BitArray yZeroIndex = new BitArray (theMatrix.Length);

            // Set index values
            for (int y = 0; y < theMatrix.Length; y++)
                for (int x = 0; x < theMatrix[y].Length; x++)
                    if (theMatrix[y][x] == 0)
                    {
                        xZeroIndex[x] = true;
                        yZeroIndex[y] = true;
                    }

            // Convert to 0 when matching with a zeroIndex
            for (int y = 0; y < theMatrix.Length; y++)
                for (int x = 0; x < theMatrix[y].Length; x++)
                    if (xZeroIndex[x] || yZeroIndex[y])
                        theMatrix[y][x] = 0;
        }


        private static int[][] MakeExampleOne()
        {
            return new int[][] {
                new int[] { 1,  2,  3,  4 },
                new int[] { 5,  0,  7,  8 },
                new int[] { 9,  10, 11, 12 },
                new int[] { 13, 14, 15, 0 },
            };
        }

        private static int[][] MakeExampleOneResult()
        {
            return new int[][] {
                new int[] { 1,  0, 3,  0 },
                new int[] { 0,  0, 0,  0 },
                new int[] { 9,  0, 11, 0 },
                new int[] { 0,  0, 0,  0 },
            };
        }

        private static int[][] MakeExampleTwo()
        {
            return new int[][] {
                new int[] { 5, 5, 0, 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 5, 5, 5, 5, 5, 5 },
            };
        }

        private static int[][] MakeExampleTwoResult()
        {
            return new int[][] {
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 5, 5, 0, 5, 5, 5, 5, 5 },
                new int[] { 5, 5, 0, 5, 5, 5, 5, 5 },
            };
        }

        private static int[][] MakeExampleThree()
        {
            return new int[][] { new int[] { 1 } };
        }

        private static int[][] MakeExampleThreeResult()
        {
            return new int[][] { new int[] { 1 } };
        }

        private static int[][] MakeExampleFour()
        {
            return new int[][] { new int[] { 1, 0, 1, 1 } };
        }

        private static int[][] MakeExampleFourResult()
        {
            return new int[][] { new int[] { 0, 0, 0, 0 } };
        }

    }
}
