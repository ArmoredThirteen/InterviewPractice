using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // Check if two strings are a rotation of one another.
    // For example these sets are rotations of each other: ToadFish/oadFishT, SplatterScatter/atterScatterSpl
    // Assume a Contains() method exits but only one call to it is allowed.
    class StringRotation : Example
    {
        public static string header = "String Rotation";
        public static string description = "Check if two strings are a rotation of one another";

        public static void RunExample()
        {
            PrintVerifiedCheck ("Blah", "ahBl", true);
        }

        private static void PrintVerifiedCheck(string strOne, string strTwo, bool expectedResult)
        {
            Console.WriteLine (string.Concat ("Checking if string [", strOne, "] is a rotation of [", strTwo, "]"));

            bool result = IsRotationWithContains (strOne, strTwo);

            Console.WriteLine (string.Concat ("   Result is [", result, "]"));
            if (result != expectedResult)
                Console.WriteLine(string.Concat ("   !!! -> Result was [", result, "] but should be [", expectedResult, "]"));
        }


        // Returns true if one string is a rotation of the other.
        // Does not fit implied prerequisite of needing to call Contains().
        //   However this is essentially a custom made Contains() with a dedicated purpose.
        // Time complexity of O(c1 * c2)
        //   Could likely be improved by more advanced search method.
        // Memory overhead is negligible.
        private static bool IsRotation(string strOne, string strTwo)
        {
            if (strOne.Length != strTwo.Length)
                return false;
            
            // Iterate through both charaOne and charaTwo checking for equality
            // Rolling the (i+k) index makes comparison happen as if string were circular
            for (int i = 0; i < strOne.Length; i++)
                for (int k = 0; k < strTwo.Length && strOne[(i + k) % strOne.Length] == strTwo[k]; k++)
                    if (k == strTwo.Length - 1)
                        return true;

            return false;
        }

        // Returns true if one string is a rotation of the other.
        // Calls Contains() once to better match implied prerequisite of question.
        // Time complexity of C#'s string.Contains() method. (Probably O(n) using Boyer-Moore).
        // Memory overhead is at least an additional strTwo*2.
        // This method has significantly fewer lines of code that need maintained.
        private static bool IsRotationWithContains(string strOne, string strTwo)
        {
            if (strOne.Length != strTwo.Length)
                return false;

            string strTwoConcat = strTwo + strTwo;
            return strTwoConcat.Contains (strOne);
        }
        
    }
}
