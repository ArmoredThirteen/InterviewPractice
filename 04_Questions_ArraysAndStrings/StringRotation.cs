using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // Check if two strings are a rotation of one another.
    // For example these sets are rotations of each other: ToadFish/oadFishT, SplatterScatter/atterScatterSpl
    // Assume a Contains() method exits but only one call to it is allowed.
    class StringRotation : Quest<string[], bool>
    {
        public override string Header => "String Rotation";
        public override string Description => "Check if two strings are a rotation of one another";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun (new string[] { "", "" }, true);
            AddTestRun (new string[] { "HelloWorld", "lloWorldHe" }, true);
            AddTestRun (new string[] { "hahahaha",   "hahahaha" },   true);
            AddTestRun (new string[] { "Blah",       "ahBl" },       true);

            AddTestRun (new string[] { "",  "a" }, false);
            AddTestRun (new string[] { "a", "" },  false);
            AddTestRun (new string[] { "hahaha",      "hahaah" },      false);
            AddTestRun (new string[] { "HelloWorlds", "SHelloWorld" }, false);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(string[] runData)
        {
            Console.WriteLine ("- Are [" + runData[0] + "] and [" + runData[1] + "] single rotations of each other");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunTest(string[] runData)
        {
            return IsRotation (runData[0], runData[1]);
        }


        // Returns true if one string is a rotation of the other.
        // Does not fit implied prerequisite of needing to call Contains().
        //   However this is essentially a custom made Contains() with a dedicated purpose.
        // Time complexity of O(c1 * c2)
        //   Could likely be improved by more advanced search method.
        // Memory overhead is negligible.
        private static bool IsRotation(string strOne, string strTwo)
        {
            if (strOne.Length != strTwo.Length)
                return false;
            if (strOne.Length == 0)
                return true;

            // Iterate through both charaOne and charaTwo checking for equality
            // Rolling the (i+k) index makes comparison happen as if string were circular
            for (int i = 0; i < strOne.Length; i++)
                for (int k = 0; k < strTwo.Length && strOne[(i + k) % strOne.Length] == strTwo[k]; k++)
                    if (k == strTwo.Length - 1)
                        return true;

            return false;
        }

        // Returns true if one string is a rotation of the other.
        // Calls Contains() once to better match implied prerequisite of question.
        // Time complexity of C#'s string.Contains() method. (Probably O(n) using Boyer-Moore).
        // Memory overhead is at least an additional strTwo*2.
        // This method has significantly fewer lines of code that need maintained.
        private static bool IsRotationWithContains(string strOne, string strTwo)
        {
            if (strOne.Length != strTwo.Length)
                return false;

            string strTwoConcat = strTwo + strTwo;
            return strTwoConcat.Contains (strOne);
        }
        
    }
}
