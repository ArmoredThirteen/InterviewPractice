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
        protected override void BuildTestRuns()
        {
            AddTestRun (new SingleLL (1),             true);
            AddTestRun (new SingleLL (1, 2, 1),       true);
            AddTestRun (new SingleLL (1, 2, 2, 1),    true);
            AddTestRun (new SingleLL (1, 2, 1, 2, 1), true);

            AddTestRun (new SingleLL (),                 false);
            AddTestRun (new SingleLL (1, 2),             false);
            AddTestRun (new SingleLL (1, 2, 2),          false);
            AddTestRun (new SingleLL (2, 2, 2, 1),       false);
            AddTestRun (new SingleLL (1, 2, 1, 2, 1, 2), false);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(SingleLL runData)
        {
            Console.WriteLine ("- Is palindrome: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunTest(SingleLL runData)
        {
            return IsPalindrome (runData);
        }


        public static bool IsPalindrome(SingleLL list)
        {
            if (list == null)
                return false;
            if (list.IsEmpty ())
                return false;

            // Find halfway mark
            // If length is odd, middle value ends up being skipped
            //   Middle value can be anything so this is fine
            int halfCount = (list.GetLength () + 1) / 2;
            
            SingleLL.Node middleNode = list.root;
            for (int i = 0; i < halfCount; i++)
                middleNode = middleNode.next;

            return IsPalindromeRecurse (ref list.root, middleNode);
        }

        // Goes through currNode.next until it reaches end of list.
        // As it recurses back, it first checks if compareTo and currNode are equal.
        // Then it increments compareTo.
        // Since compareTo is by ref, this means compareTo starts at the beginning and moves forward
        //   while currNode is unwinding and effectively starts at the end and moves backward.
        public static bool IsPalindromeRecurse(ref SingleLL.Node compareTo, SingleLL.Node currNode)
        {
            if (currNode == null)
                return true;

            if (!IsPalindromeRecurse (ref compareTo, currNode.next)
                || compareTo.val != currNode.val)
                return false;

            compareTo = compareTo.next;
            return true;
        }

    }
}
