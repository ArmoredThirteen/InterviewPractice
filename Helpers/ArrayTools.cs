using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public class ArrayTools
    {
        public static int[] SequentialInts(int length)
        {
            int[] newArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                newArray[i] = i;
            }

            return newArray;
        }

        public static int[] RandomInt(int length, int minValue, int maxValue)
        {
            Random rand = new Random ();
            int[] newArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                newArray[i] = rand.Next (minValue, maxValue);
            }

            return newArray;
        }


        public static void ShuffleArray<E> (E[] theArray)
        {
            Random rand = new Random ();

            for (int i = 0; i < theArray.Length; i++)
            {
                int swapIndex = rand.Next (0, theArray.Length);
                Swap<E> (theArray, i, swapIndex);
            }
        }

        public static void ReverseArray<E> (E[] theArray)
        {
            int halfLen = theArray.Length / 2;
            for (int i = 0; i < halfLen; i++)
            {
                int swapIndex = (theArray.Length-1) - i;
                //Console.WriteLine ("i:" + i + ", swapI:" + swapIndex);
                Swap<E> (theArray, i, swapIndex);
            }
        }


        public static void Swap<E>(E[] theArray, int indOne, int indTwo)
        {
            E stored = theArray[indOne];
            theArray[indOne] = theArray[indTwo];
            theArray[indTwo] = stored;
        }


        public static String GetContentsAsString<T>(T[] theArray)
        {
            StringBuilder builder = new StringBuilder ();

            for (int i = 0; i < theArray.Length; i++)
            {
                builder.Append (theArray[i].ToString ());
            }

            return builder.ToString ();
        }

        public static String GetContentsAsString<T>(T[][] theMatrix, string linePrefix = "", int spaceBuffer = 5)
        {
            StringBuilder builder = new StringBuilder ();

            for (int y = 0; y < theMatrix.Length; y++)
            {
                builder.Append (linePrefix);

                for (int x = 0; x < theMatrix[y].Length; x++)
                {
                    String theStr = theMatrix[y][x].ToString ();
                    builder.Append (theStr);
                    builder.Append (' ', spaceBuffer - theStr.Length);
                }

                builder.Append (Environment.NewLine);
            }

            return builder.ToString ();
        }

        public static bool AreMatricesEqual(int[][] matrixOne, int[][] matrixTwo)
        {
            if (matrixOne.Length != matrixTwo.Length)
                return false;
            if (matrixOne.Length == 0)
                return true;

            if (matrixOne[0].Length != matrixTwo[0].Length)
                return false;
            if (matrixOne[0].Length == 0)
                return true;

            for (int y = 0; y < matrixOne.Length; y++)
                for (int x = 0; x < matrixOne[y].Length; x++)
                    if (matrixOne[y][x] != matrixTwo[y][x])
                        return false;

            return true;
        }

    }
}
