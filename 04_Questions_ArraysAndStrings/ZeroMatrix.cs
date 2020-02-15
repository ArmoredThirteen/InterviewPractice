using Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // Given an MxN matrix, find all 0 values and set values in col/row to all 0 as well.f
    class ZeroMatrix : Quest<int[][], int[][]>
    {
        public override string Header => "Zero Matrix";
        public override string Description => "Convert aligned rows/cols to 0 if a 0 value is found";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (MakeExampleOne (),   MakeExampleOneResult ());
            AddDataPair (MakeExampleTwo (),   MakeExampleTwoResult ());
            AddDataPair (MakeExampleThree (), MakeExampleThreeResult ());
            AddDataPair (MakeExampleFour (),  MakeExampleFourResult ());
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(int[][] runData)
        {
            Console.WriteLine ("- Processing matrix:");
            Console.Write (ArrayTools.Stringify<int> (runData, "  "));
            Console.WriteLine ();
        }

        // Use runData to perform desired operation and return the result.
        protected override int[][] RunStep(int[][] runData)
        {
            Zeroify (runData);
            return runData;
        }


        // True if result matches expectedResult.
        protected override bool CompareResult(int[][] result, int[][] expectedResult)
        {
            return ArrayTools.AreMatricesEqual (result, expectedResult);
        }

        // Write the resulting data.
        protected override void StateResult(int[][] result)
        {
            Console.WriteLine ("  Result is:");
            Console.WriteLine (ArrayTools.Stringify<int> (result, "  "));
        }

        // Write warning of algorithm failure, result was not as expected.
        protected override void AdmitFailure(int[][] expectedResult)
        {
            Console.WriteLine (" !!! -> Result was not expected result of:");
            Console.WriteLine (ArrayTools.Stringify<int> (expectedResult, "  "));
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
            // The larger the matrix and the fewer 0 values, the less ideal this becomes
            /*for (int y = 0; y < theMatrix.Length; y++)
                for (int x = 0; x < theMatrix[y].Length; x++)
                    if (xZeroIndex[x] || yZeroIndex[y])
                        theMatrix[y][x] = 0;*/
            
            // More code, a little harder to read, but only digs into main matrix when necessary
            // Time complexity is still O(xy) but on average will be linearly less depending on number of 0s
            // For x index zeros
            for (int x = 0; x < xZeroIndex.Length; x++)
                if (xZeroIndex[x])
                    for (int y = 0; y < theMatrix.Length; y++)
                        theMatrix[y][x] = 0;

            // For y index zeros
            for (int y = 0; y < yZeroIndex.Length; y++)
                if (yZeroIndex[y])
                    for (int x = 0; x < theMatrix[y].Length; x++)
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
