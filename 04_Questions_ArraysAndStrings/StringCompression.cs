using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleHelpers;

namespace _04_Questions_ArraysAndStrings
{
    // Implement a method to perform basic string compression using the counts of repeated characters.
    // For example, the string aabcccccaaa would become a2b1c5a3.
    // If the "compressed" string would not become smaller than the original string, your method should return the original string.
    // You can assume the string has only uppercase and lowercase letters (a-z).
    class StringCompression
    {
        public static void RunExample()
        {
            Console.WriteLine (StringTools.MakeHeader ("String Compression"));
            Console.WriteLine ("Replaces chars with 'char'+'charCount', compressing strings with enough repeating characters");
            Console.WriteLine ();
            Console.WriteLine ();

            PrintVerifiedCheck ("ssssuup", "s4u2p1");

            Console.WriteLine ();
        }

        
        private static void PrintVerifiedCheck(string theStr, string expectedResult)
        {
            Console.WriteLine (string.Concat("Processing string [", theStr, "]"));
            string result = GetCompressedString (theStr);
            Console.WriteLine (string.Concat ("   Result is: ", result));
            if (!string.Equals(result, expectedResult))
                Console.WriteLine(string.Concat ("   !!! -> Result was [", result, "] but should be [", expectedResult, "]"));
        }

        private static string GetCompressedString(string theStr)
        {
            return theStr;
        }

    }
}
