using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    // Check if between two strings there is only one or zero edits.
    // An edit is taking a character and inserting, removing, or replacing it.
    class OneAway : Quest<string[], bool>
    {
        public override string Header => "One Away";
        public override string Description => "Checks if two strings are one or no character modifications apart from each other";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun (new string[] { "",  "" },  true);
            AddTestRun (new string[] { "a", "" },  true);
            AddTestRun (new string[] { "a", "r" }, true);

            AddTestRun (new string[] { "toot",    "tooooot" }, false);
            AddTestRun (new string[] { "tooooot", "toot" },    false);
            AddTestRun (new string[] { "ReversE", "EsreveR" }, false);

            AddTestRun (new string[] { "Insert", "1Insert" }, true);
            AddTestRun (new string[] { "Insert", "Ins2ert" }, true);
            AddTestRun (new string[] { "Insert", "Insert3" }, true);

            AddTestRun (new string[] { "Remove", "emove" }, true);
            AddTestRun (new string[] { "Remove", "Remve" }, true);
            AddTestRun (new string[] { "Remove", "Remov" }, true);

            AddTestRun (new string[] { "Replace", "Zeplace" }, true);
            AddTestRun (new string[] { "Replace", "Rep ace" }, true);
            AddTestRun (new string[] { "Replace", "Replacc" }, true);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(string[] runData)
        {
            Console.WriteLine ("- Are [" + runData[0] + "] and [" + runData[1] + "] one or fewer edits different");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunTest(string[] runData)
        {
            return IsOneChangeAway (runData[0].ToCharArray (), runData[1].ToCharArray ());
        }


        private static bool IsOneChangeAway(char[] strOne, char[] strTwo)
        {
            if (Math.Abs (strOne.Length - strTwo.Length) > 1)
            {
                Console.WriteLine ("  String size difference is greater than 1");
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
