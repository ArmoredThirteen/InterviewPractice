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
        public static string description = "";

        public static void RunExample()
        {
            int[][] matrix = new int[][] {
                new int[] { 1 },
                new int[] { 1 },
                new int[] { 1 },
                new int[] { 1 }
            };

            int[][] result = new int[][] {
                new int[] { 1, 2 },
                new int[] { 1, 2 },
                new int[] { 1, 2 },
                new int[] { 1, 3 }
            };

            PrintVerifiedCheck (matrix, result);
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

        }

        private static void RotateLeft(int[][] theMatrix)
        {

        }

    }
}
