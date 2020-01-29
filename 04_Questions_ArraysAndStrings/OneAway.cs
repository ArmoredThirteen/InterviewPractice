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
            
            PrintVerifiedCheck ("".ToCharArray (),  "".ToCharArray (),  true);
            PrintVerifiedCheck ("a".ToCharArray (), "".ToCharArray (),  true);
            PrintVerifiedCheck ("a".ToCharArray (), "r".ToCharArray (), true);
            Console.WriteLine ();

            PrintVerifiedCheck ("toot".ToCharArray (),    "tooooot".ToCharArray (), false);
            PrintVerifiedCheck ("tooooot".ToCharArray (), "toot".ToCharArray (),    false);
            PrintVerifiedCheck ("ReversE".ToCharArray (), "EsreveR".ToCharArray (), false);
            Console.WriteLine ();
            
            PrintVerifiedCheck ("Insert".ToCharArray (), "1Insert".ToCharArray (), true);
            PrintVerifiedCheck ("Insert".ToCharArray (), "Ins2ert".ToCharArray (), true);
            PrintVerifiedCheck ("Insert".ToCharArray (), "Insert3".ToCharArray (), true);
            Console.WriteLine ();
            
            PrintVerifiedCheck ("Remove".ToCharArray (), "emove".ToCharArray (), true);
            PrintVerifiedCheck ("Remove".ToCharArray (), "Remve".ToCharArray (), true);
            PrintVerifiedCheck ("Remove".ToCharArray (), "Remov".ToCharArray (), true);
            Console.WriteLine ();
            
            PrintVerifiedCheck ("Replace".ToCharArray (), "Zeplace".ToCharArray (), true);
            PrintVerifiedCheck ("Replace".ToCharArray (), "Rep ace".ToCharArray (), true);
            PrintVerifiedCheck ("Replace".ToCharArray (), "Replacc".ToCharArray (), true);
            Console.WriteLine ();
        }

        
        private static void PrintVerifiedCheck(char[] strOne, char[] strTwo, bool expectedResult)
        {
            Console.WriteLine (string.Concat("Are [", StringTools.CharAraToString(strOne), "] and [", StringTools.CharAraToString(strTwo), "] one or fewer edits different"));
            bool result = IsOneChangeAway (strOne, strTwo);
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

            // Find the character count differences between the two strings
            int[] counts = new int[char.MaxValue];
            StringTools.CharCountsAdd    (strOne, counts);
            StringTools.CharCountsRemove (strTwo, counts);

            // Count how different individual characters are from each other
            int difference = 0;
            Array.ForEach(counts, delegate(int i) { difference += Math.Abs(i); });

            if (difference > 1)
                return false;
            return true;
        }

    }
}
