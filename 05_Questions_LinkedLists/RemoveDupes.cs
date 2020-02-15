using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            AddDataPair (new SingleLL (1, 2, 3, 4, 5), new SingleLL (1, 2, 3, 4, 5));
            AddDataPair (new SingleLL (1, 2, 1, 4, 5), new SingleLL (1, 2, 4, 5));
            AddDataPair (new SingleLL (1, 1, 1), new SingleLL (1));
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL runData)
        {
            Console.WriteLine ("- Removing duplicate values from: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL RunStep(SingleLL runData)
        {
            RemoveDuplicates (runData);
            return runData;
        }


        private static void RemoveDuplicates(SingleLL theList)
        {

        }

    }
}
