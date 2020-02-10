using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleHelpers;

namespace _04_Questions_ArraysAndStrings
{
    // Compress a string by counting repeated characters.
    // So like [abbccccddd] would become [a1b2c4d3].
    // If string would not become shorter, return original string.
    // String can only have characters a-z and A-Z.
    class StringCompression : Example
    {
        public static string header = "String Compression";
        public static string description = "Replaces chars with 'char'+'charCount', compressing strings with enough repeating characters";

        public static void RunExample()
        {
            PrintVerifiedCheck ("", "");
            PrintVerifiedCheck ("a", "a");
            PrintVerifiedCheck ("sup", "sup");
            PrintVerifiedCheck ("ssssuup", "s4u2p1");
            PrintVerifiedCheck ("SsSsSsupppppppppppp", "S1s1S1s1S1s1u1p12");
        }

        
        private static void PrintVerifiedCheck(string theStr, string expectedResult)
        {
            Console.WriteLine (string.Concat("Processing string [", theStr, "]"));
            string result = GetCompressedString (theStr);
            Console.WriteLine (string.Concat ("   Result is [", result, "]"));
            if (!string.Equals(result, expectedResult))
                Console.WriteLine(string.Concat ("   !!! -> Result was [", result, "] but should be [", expectedResult, "]"));
        }

        private static string GetCompressedString(string theStr)
        {
            if (string.IsNullOrEmpty (theStr))
                return theStr;
            if (theStr.Length < 3)
                return theStr;

            StringBuilder result = new StringBuilder ();
            char currChar = theStr[0];
            int count = 1;

            // Start at 1 since curr values are already primed with first character
            for (int i = 1; i < theStr.Length; i++)
            {
                if (currChar == theStr[i])
                    count++;
                else
                {
                    result.Append (currChar);
                    result.Append (count);
                    currChar = theStr[i];
                    count = 1;
                }
            }

            result.Append (currChar);
            result.Append (count);

            return result.Length < theStr.Length ? result.ToString () : theStr;
        }

    }
}
