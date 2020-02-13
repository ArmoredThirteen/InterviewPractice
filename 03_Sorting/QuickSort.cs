using SimpleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    public static class QuickSort
    {
        public static void Sort(int[] unsorted)
        {
            Quick (unsorted, 0, unsorted.Length - 1);
        }

        private static void Quick(int[] theArray, int low, int high)
        {
            if (low >= high)
                return;

            int part = Partition (theArray, low, high);
            Quick (theArray, low, part - 1);
            Quick (theArray, part + 1, high);
        }

        private static int Partition(int[] theArray, int low, int high)
        {
            int pivot = theArray[high];

            int i = low;
            for (int j = low; j < high; j++)
            {
                if (theArray[j] < pivot)
                {
                    ArrayTools.Swap<int> (theArray, i, j);
                    i++;
                }
            }

            ArrayTools.Swap<int> (theArray, i, high);
            return i;
        }
    }
}
