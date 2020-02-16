using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static _05_Questions_LinkedLists.SingleLL;

namespace _05_Questions_LinkedLists
{
    // Remove duplicate values from an unordered linked list.
    // If possible, perform with no additional temporary buffer.
    class RemoveDupes : Quest<SingleLL, SingleLL>
    {
        public override string Header => "RemoveDupes";
        public override string Description => "Removes duplicate values from unsorted list";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (new SingleLL (), new SingleLL ());
            AddDataPair (new SingleLL (1, 2, 3, 4, 5), new SingleLL (1, 2, 3, 4, 5));
            AddDataPair (new SingleLL (1, 2, 1, 4, 5), new SingleLL (1, 2, 4, 5));
            AddDataPair (new SingleLL (1, 1, 1, 1), new SingleLL (1));
            AddDataPair (new SingleLL (1, 2, 3, 1, 2, 3), new SingleLL (1, 2, 3));
            AddDataPair (new SingleLL (5, 4, 3, 3, 3, 1, 2, 5, 5), new SingleLL (5, 4, 3, 1, 2));
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL runData)
        {
            Console.WriteLine ("- Removing duplicate values from: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL RunStep(SingleLL runData)
        {
            RemoveDuplicatesWithBuffer (runData);
            return runData;
        }


        private static void RemoveDuplicatesWithBuffer(SingleLL theList)
        {
            Node prev = null;
            Node curr = theList.root;

            HashSet<int> foundInts = new HashSet<int> ();

            while (curr != null)
            {
                if (foundInts.Contains (curr.val))
                    prev.next = curr.next;
                else
                {
                    foundInts.Add (curr.val);
                    prev = curr;
                }
                
                curr = curr.next;
            }
        }

    }
}
