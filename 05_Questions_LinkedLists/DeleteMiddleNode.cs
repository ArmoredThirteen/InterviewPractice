using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    // Remove a node from the middle of a singly linked list
    // Middle means not first or last, but exact location in middle is arbitrary
    // Method can only receive reference to a node not the entire list
    class DeleteMiddleNode : Quest<SingleLL, SingleLL>
    {
        public override string Header => "DeleteMiddleNode";
        public override string Description => "Remove middle node from singly linked list given only reference to node";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun (new SingleLL (1, 2, 3), new SingleLL (1, 3));
            AddTestRun (new SingleLL (1, 2, 3, 4), new SingleLL (1, 2, 4));
            AddTestRun (new SingleLL (1, 2, 3, 4, 5), new SingleLL (1, 2, 4, 5));
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(SingleLL runData)
        {
            Console.WriteLine ("- Delete middle node from: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL RunTest(SingleLL runData)
        {
            if (runData.GetLength () < 3)
            {
                Console.WriteLine (" !!!!! -> List too small to have a middle node");
                return runData;
            }

            int stopIndex = runData.GetLength () / 2;

            SingleLL.Node middleNode = runData.root;
            for (int i = 0; i < stopIndex; i++)
                middleNode = middleNode.next;

            RemoveMiddle (middleNode);
            return runData;
        }


        public static void RemoveMiddle(SingleLL.Node theNode)
        {
            theNode.val = theNode.next.val;
            theNode.next = theNode.next.next;
        }

    }
}
