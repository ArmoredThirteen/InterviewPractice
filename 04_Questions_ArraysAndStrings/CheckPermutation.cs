using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    class CheckPermutation
    {
        #region Run Example
        public static void RunExample()
        {
            PrintCheck ("", "");
        }

        private static void PrintCheck(string strOne, string strTwo)
        {
            Console.WriteLine (string.Concat ("-Are chars of [", strOne, "] a permutation of [", strTwo, "]"));
            Console.WriteLine (IsPermutation (strOne, strTwo));
        }
        #endregion


        // Given two strings, write a method to decide if one is a permutation of the other
        // Returns true if both strings are null or empty
        // Initialize bucket array of size equal to string character count
        public static bool IsPermutation(string strOne, string strTwo)
        {
            if (string.IsNullOrEmpty (strOne) && string.IsNullOrEmpty (strTwo))
                return true;

            return true;
        }

    }
}
