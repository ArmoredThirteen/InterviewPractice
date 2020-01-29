using SimpleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // There are three types of edits that can be performed on strings: insert a character, remove a character, or replace a character.
    // Given two strings, write a function to check if they are one edit (or zero edits) away.
    class OneAway
    {
        public static void RunExample()
        {
            Console.WriteLine (StringTools.MakeHeader ("One Away"));
            Console.WriteLine ("Checks if two strings are one or no character modifications apart from each other");
            Console.WriteLine ();
            Console.WriteLine ();
            
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
            Console.WriteLine ();
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
            if (strOne.Length < 2 && strTwo.Length < 2)
            {
                Console.WriteLine ("   Both strings are size 0 or 1, impossible to be 2+ edits away from each other");
                return true;
            }

            bool foundDif = false;
            int dexOne = 0;
            int dexTwo = 0;

            //TODO: Feels like there are too many index++ operations
            while (dexOne < strOne.Length && dexTwo < strTwo.Length)
            {
                if (strOne[dexOne] == strTwo[dexTwo])
                {
                    dexOne++;
                    dexTwo++;
                    continue;
                }

                // Second dif so there has to be more than one char edit
                if (foundDif == true)
                    return false;
                foundDif = true;

                if (strOne.Length == strTwo.Length)
                {
                    dexOne++;
                    dexTwo++;
                }
                else if (strOne.Length > strTwo.Length)
                    dexOne++;
                else
                    dexTwo++;
            }

            return true;
        }

    }
}
