using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    // Check if a list is a palindrome
    class Palindrome : Quest<SingleLL, bool>
    {
        public override string Header => "Palindrome";
        public override string Description => "Checks if given list's values form a palindrome";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (null, false);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL runData)
        {
            Console.WriteLine ("- Is palindrome: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunStep(SingleLL runData)
        {
            return IsPalindrome (runData);
        }


        public static bool IsPalindrome(SingleLL list)
        {
            if (list == null)
                return false;
            if (list.root == null)
                return true;

            return false;
        }

    }
}
