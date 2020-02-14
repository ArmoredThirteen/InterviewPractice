using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace _04_Questions_ArraysAndStrings
{
    // Check if two strings are a permutation of each other.
    class CheckPermutation : Quest<string[], bool>
    {
        public override string Header => "Check Permutation";
        public override string Description => "Checks if two strings are permutations of each other";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (new string[] { "",       "" },       true);
            AddDataPair (new string[] { "a",      "1" },      false);
            AddDataPair (new string[] { "apple",  "apple" },  true);
            AddDataPair (new string[] { "apple",  "zapple" }, false);
            AddDataPair (new string[] { "apples", "zapple" }, false);
            AddDataPair (new string[] { "haa",    "aha" },    true);
            AddDataPair (new string[] { "haa",    "aah" },    true);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(string[] runData)
        {
            Console.WriteLine ("- Are chars of [" + runData[0] + "] a permutation of [" + runData[1] + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunStep(string[] runData)
        {
            return IsPermutation (runData[0], runData[1]);
        }


        // Time complexity O(n+k) where n is length of strOne and k is length of strTwo
        // Returns true if both strings are null or empty
        // Initializes int array of size equal to number of possible chars
        // Iterate strOne and add one to value at index of each (int)char
        // Iterate strTwo and subtract one from value at index of each (int)char
        // Iterate int array and return true if all values are zero
        public static bool IsPermutation(string strOne, string strTwo)
        {
            if (string.IsNullOrEmpty (strOne) && string.IsNullOrEmpty (strTwo))
                return true;
            if (strOne.Length != strTwo.Length)
                return false;

            // Probably way to reduce size of array, seems wasteful initializing so much
            int[] charCounts = new int[char.MaxValue];

            for (int i = 0; i < strOne.Length; i++)
                charCounts[strOne[i]]++;

            for (int i = 0; i < strTwo.Length; i++)
                charCounts[strTwo[i]]--;

            for (int i = 0; i < charCounts.Length; i++)
                if (charCounts[i] != 0)
                    return false;

            return true;
        }

    }
}
