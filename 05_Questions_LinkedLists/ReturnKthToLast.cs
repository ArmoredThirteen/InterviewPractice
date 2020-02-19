using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static _05_Questions_LinkedLists.SingleLL;

namespace _05_Questions_LinkedLists
{
    // Find value that is the Kth from the last in a singly linked list
    class ReturnKthToLast : Quest<SingleLL, int>
    {
        public override string Header => "Kth To Last";
        public override string Description => "In a singly linked list, find the Kth from last value. This example will use 3 for K";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (new SingleLL (0, 1, 2, 3), 0);
            AddDataPair (new SingleLL (0, 1, 2, 3, 4, 5), 2);
            AddDataPair (new SingleLL (0, 1, 2), -1);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL runData)
        {
            Console.WriteLine ("- Find 3rd from last value in: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override int RunStep(SingleLL runData)
        {
            try
            {
                return FindKthToLast (runData, 3);
            }
            catch (Exception exc)
            {
                Console.WriteLine ("  " + exc.Message);
                return -1;
            }
        }


        private static int FindKthToLast(SingleLL theList, int k = 3)
        {
            Node curr = theList.root;
            Node leader = theList.root;

            for (int i = 0; i < k; i++)
            {
                if (leader.next == null)
                    throw new Exception ("Not enough values in list to find value that is " + k + " to last");
                leader = leader.next;
            }

            while (leader.next != null)
            {
                curr = curr.next;
                leader = leader.next;
            }

            return curr.val;
        }

    }
}
