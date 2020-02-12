using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // Assuming an IsString() method, check if two strings are a rotation of one another.
    // For example these sets are rotations of each other: ToadFish/oadFishT, SplatterScatter/atterScatterSpl
    // Only one call to IsString() is allowed.
    class StringRotation : Example
    {
        public static string header = "String Rotation";
        public static string description = "Check if two strings are a rotation of one another";

        public static void RunExample()
        {
            PrintVerifiedCheck ("Blah".ToCharArray (), "ahBl".ToCharArray (), true);
        }

        private static void PrintVerifiedCheck(char[] charaOne, char[] charaTwo, bool expectedResult)
        {
            String strOne = ArrayTools.GetContentsAsString<char> (charaOne);
            String strTwo = ArrayTools.GetContentsAsString<char> (charaTwo);

            Console.WriteLine (string.Concat ("Checking if string [", strOne, "] is a rotation of [", strTwo, "]"));
            bool result = IsRotation (charaOne, charaTwo);
            Console.WriteLine (string.Concat ("   Result is [", result, "]"));
            if (result != expectedResult)
                Console.WriteLine(string.Concat ("   !!! -> Result was [", result, "] but should be [", expectedResult, "]"));
        }


        // Returns true if one string is a rotation of the other
        private static bool IsRotation(char[] charaOne, char[] charaTwo)
        {
            if (charaOne.Length != charaTwo.Length)
                return false;

            return true;
        }
        
    }
}
