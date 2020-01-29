using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleHelpers;

namespace _04_Questions_ArraysAndStrings
{
    // Given a string, write a function to check if it is a permutation of a palindrome.
    // A palindrome is a word or phrase that is the same forwards and backwards.
    // A permutation is a rearrangement of letters.
    // The palindrome does not need to be limited to just dictionary words.
    // * the given example also appears to ignore white-space, which I may not implement here
    class PalindromePermutation
    {
        public static void RunExample()
        {
            Console.WriteLine (StringTools.MakeHeader ("Palindrome Permutation"));
            Console.WriteLine ("Checks if a string is a permutation of a palindrome");
            Console.WriteLine ();
            Console.WriteLine ();

            PrintCheck ("hello".ToCharArray ());
            PrintCheck ("aabbcd".ToCharArray ());
            PrintCheck ("abc".ToCharArray ());
            PrintCheck ("l".ToCharArray ());
            PrintCheck ("tacocat".ToCharArray ());
            PrintCheck ("$$##@@@@@".ToCharArray ());
            PrintCheck ("$$####@@@@@".ToCharArray ());
            PrintCheck ("$$#####@@@@@".ToCharArray ());

            Console.WriteLine ();
        }

        // A palindrome can only happen when the pattern in the middle is a single char or two of the same char
        // Individual char occurrences are counted. A char with an even number of characters can always form a pair in the mirrored pattern.
        // A char with an odd number means the one char has to be the middle in the palindrome to maintain symetry.
        // If there is more than one char with an odd number of occurences, then no mirror pattern can be formed.
        // Time complexity is O(n) where n is Max(charAra.Length, char.MaxValue)
        private static void PrintCheck(char[] charAra)
        {
            Console.WriteLine (string.Concat ("Processing string [", StringTools.CharAraToString (charAra), "]"));

            // Index of a specific char is found by casting char to int
            int[] odds = new int[char.MaxValue];

            for (int i = 0; i < charAra.Length; i++)
            {
                odds[charAra[i]] = (odds[charAra[i]] + 1) % 2;
            }

            // Check for more than one odd number
            bool oddFound = false;
            for (int i = 0; i < odds.Length; i++)
            {
                bool isOdd = odds[i] == 1;
                if (isOdd)
                {
                    if (oddFound)
                    {
                        Console.WriteLine ("False: More than one character had odd count");
                        Console.WriteLine ();
                        return;
                    }
                    oddFound = true;
                }
            }

            Console.WriteLine ("True");
            Console.WriteLine ();
        }

    }
}
