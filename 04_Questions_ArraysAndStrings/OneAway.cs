using SimpleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // Check if between two strings there is only one or zero edits.
    // An edit is taking a character and inserting, removing, or replacing it.
    class OneAway : Example
    {
        public static string header = "One Away";
        public static string description = "Checks if two strings are one or no character modifications apart from each other";

        public static void RunExample()
        {
            PrintVerifiedCheck ("",  "",  true);
            PrintVerifiedCheck ("a", "",  true);
            PrintVerifiedCheck ("a", "r", true);
            Console.WriteLine ();

            PrintVerifiedCheck ("toot",    "tooooot", false);
            PrintVerifiedCheck ("tooooot", "toot",    false);
            PrintVerifiedCheck ("ReversE", "EsreveR", false);
            Console.WriteLine ();
            
            PrintVerifiedCheck ("Insert", "1Insert", true);
            PrintVerifiedCheck ("Insert", "Ins2ert", true);
            PrintVerifiedCheck ("Insert", "Insert3", true);
            Console.WriteLine ();
            
            PrintVerifiedCheck ("Remove", "emove", true);
            PrintVerifiedCheck ("Remove", "Remve", true);
            PrintVerifiedCheck ("Remove", "Remov", true);
            Console.WriteLine ();
            
            PrintVerifiedCheck ("Replace", "Zeplace", true);
            PrintVerifiedCheck ("Replace", "Rep ace", true);
            PrintVerifiedCheck ("Replace", "Replacc", true);
        }

        
        private static void PrintVerifiedCheck(string strOne, string strTwo, bool expectedResult)
        {
            Console.WriteLine (string.Concat("Are [", strOne, "] and [", strTwo, "] one or fewer edits different"));
            bool result = IsOneChangeAway (strOne.ToCharArray (), strTwo.ToCharArray ());
            Console.WriteLine (string.Concat ("   ", result));
            if (result != expectedResult)
                Console.WriteLine (string.Concat("   !!! -> Result was [", result, "] but should be [", expectedResult, "]"));
        }

        private static bool IsOneChangeAway(char[] strOne, char[] strTwo)
        {
            if (Math.Abs (strOne.Length - strTwo.Length) > 1)
            {
                Console.WriteLine ("   String size difference is greater than 1");
                return false;
            }

            bool foundDif = false;
            int dexOne = -1;
            int dexTwo = -1;

            while (dexOne < strOne.Length - 1 && dexTwo < strTwo.Length - 1)
            {
                dexOne++;
                dexTwo++;

                if (strOne[dexOne] == strTwo[dexTwo])
                    continue;

                // Second dif so there has to be more than one char edit
                if (foundDif == true)
                    return false;
                foundDif = true;

                if (strOne.Length < strTwo.Length)
                    dexOne--;
                else if (strTwo.Length < strOne.Length)
                    dexTwo--;
            }

            return true;
        }

    }
}
