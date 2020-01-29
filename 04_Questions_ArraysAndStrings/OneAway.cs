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
            Console.WriteLine ("Checks if two strings are one character modification apart from each other");
            Console.WriteLine ();
            Console.WriteLine ();

            PrintCheck ("".ToCharArray ());

            Console.WriteLine ();
        }

        
        private static void PrintCheck(char[] charAra)
        {
            
        }

    }
}
