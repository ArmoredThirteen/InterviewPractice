using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    class ArrayTools
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
            String returnStr = "";

            for (int i = 0; i < theArray.Length; i++)
            {
                returnStr += theArray[i].ToString ();
            }

            return returnStr;
        }

    }
}
