using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace _04_Questions_ArraysAndStrings
{
    // Check if string is a permutation of a palindrome.
    // Does not have to create real words.
    class PalindromePermutation : Quest<string, bool>
    {
        public override string Header => "Palindrome Permutation";
        public override string Description => "Checks if a string is a permutation of a palindrome";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun ("hello",  false);
            AddTestRun ("aabbcd", false);
            AddTestRun ("abc",    false);
            AddTestRun ("l",      true);
            AddTestRun ("tacocat",      true);
            AddTestRun ("$$##@@@@@",    true);
            AddTestRun ("$$####@@@@@",  true);
            AddTestRun ("$$#####@@@@@", false);
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunTest(string runData)
        {
            return IsPalindromePermutation (runData.ToCharArray ());
        }


        // A palindrome can only happen when the pattern in the middle is a single char or two of the same char
        // Individual char occurrences are counted. A char with an even number of characters can always form a pair in the mirrored pattern.
        // A char with an odd number means the one char has to be the middle in the palindrome to maintain symetry.
        // If there is more than one char with an odd number of occurences, then no mirror pattern can be formed.
        // Time complexity is O(n) where n is Max(charAra.Length, char.MaxValue)
        private static bool IsPalindromePermutation(char[] charAra)
        {
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
                        return false;
                    }
                    oddFound = true;
                }
            }

            return true;
        }

    }
}
