using SimpleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] theArray = ArrayTools.SequentialInts (10);
            Print (theArray);

            //ArrayTools.ShuffleArray<int> (theArray);
            ArrayTools.ReverseArray<int> (theArray);
            Print (theArray);

            QuickSort.Sort (theArray);
            Print (theArray);
        }

        private static void Print(int[] theArray)
        {
            Console.WriteLine (ArrayTools.GetContentsAsString<int> (theArray));
        }
    }
}
