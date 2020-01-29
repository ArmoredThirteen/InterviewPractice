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
            
            PrintCheck ("".ToCharArray (), "".ToCharArray ());
            PrintCheck ("a".ToCharArray (), "r".ToCharArray ());

            PrintCheck ("toot".ToCharArray (), "tooooot".ToCharArray ());
            PrintCheck ("tooooot".ToCharArray (), "toot".ToCharArray ());
            PrintCheck ("ReversE".ToCharArray (), "EsreveR".ToCharArray ());
            
            PrintCheck ("Insert".ToCharArray (), "1Insert".ToCharArray ());
            PrintCheck ("Insert".ToCharArray (), "Ins2ert".ToCharArray ());
            PrintCheck ("Insert".ToCharArray (), "Insert3".ToCharArray ());
            
            PrintCheck ("Remove".ToCharArray (), "emove".ToCharArray ());
            PrintCheck ("Remove".ToCharArray (), "Remve".ToCharArray ());
            PrintCheck ("Remove".ToCharArray (), "Remov".ToCharArray ());
            
            PrintCheck ("Replace".ToCharArray (), "Zeplace".ToCharArray ());
            PrintCheck ("Replace".ToCharArray (), "Rep ace".ToCharArray ());
            PrintCheck ("Replace".ToCharArray (), "Replacc".ToCharArray ());

            Console.WriteLine ();
        }

        
        private static void PrintCheck(char[] strOne, char[] strTwo)
        {
            Console.WriteLine (string.Concat("Are chars of [", StringTools.CharAraToString(strOne), "] one or no edits away from [", StringTools.CharAraToString(strTwo), "]"));
            
            if (Math.Abs (strOne.Length - strTwo.Length) > 1)
            {
                Console.WriteLine ("False: String size difference is greater than 1");
                Console.WriteLine ();
                return;
            }

            if (strOne.Length < 2 && strTwo.Length < 2)
            {
                Console.WriteLine ("True: Both strings are size 0 or 1, impossible to be 2+ edits away from each other");
                Console.WriteLine ();
                return;
            }

            // Find the character count differences between the two strings
            int[] counts = new int[char.MaxValue];
            StringTools.CharCountsAdd    (strOne, counts);
            StringTools.CharCountsRemove (strTwo, counts);

            // Count how different individual characters are from each other
            int difference = 0;
            Array.ForEach(counts, delegate(int i) { difference += Math.Abs(i); });

            if (difference > 1)
                Console.WriteLine ("False");
            else
                Console.WriteLine ("True");

            Console.WriteLine ();
        }

    }
}
