using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleHelpers;

namespace _04_Questions_ArraysAndStrings
{
    // Given two strings, write a method to decide if one is a permutation of the other
    class CheckPermutation
    {
        public static void RunExample()
        {
            Console.WriteLine (StringTools.MakeHeader ("Check Permutation"));
            Console.WriteLine ("Checks if two strings are permutations of each other");
            Console.WriteLine ();
            Console.WriteLine ();

            PrintCheck ("", "");
            PrintCheck ("a", "1");
            PrintCheck ("apple", "apple");
            PrintCheck ("apple", "zapple");
            PrintCheck ("apples", "zapple");
            PrintCheck ("haa", "aha");
            PrintCheck ("haa", "aah");

            Console.WriteLine ();
        }

        private static void PrintCheck(string strOne, string strTwo)
        {
            Console.WriteLine (string.Concat ("-Are chars of [", strOne, "] a permutation of [", strTwo, "]"));
            Console.WriteLine (IsPermutation (strOne, strTwo));
            Console.WriteLine ();
        }


        // Time complexity O(n+k) where n is length of strOne and k is length of strTwo
        // Returns true if both strings are null or empty
        // Initializes int array of size equal to number of possible chars
        // Iterate strOne and add one to value at index of each (int)char
        // Iterate strTwo and subtract one from value at index of each (int)char
        // Iterate int array and return true if all values are zero
        public static bool IsPermutation(string strOne, string strTwo)
        {
            if (string.IsNullOrEmpty (strOne) && string.IsNullOrEmpty (strTwo))
                return true;
            if (strOne.Length != strTwo.Length)
                return false;

            // Probably way to reduce size of array, seems wasteful initializing so much
            int[] charCounts = new int[char.MaxValue];

            for (int i = 0; i < strOne.Length; i++)
                charCounts[strOne[i]]++;

            for (int i = 0; i < strTwo.Length; i++)
                charCounts[strTwo[i]]--;

            for (int i = 0; i < charCounts.Length; i++)
                if (charCounts[i] != 0)
                    return false;

            return true;
        }

    }
}
