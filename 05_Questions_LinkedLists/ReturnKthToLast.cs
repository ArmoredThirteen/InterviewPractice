using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    class ReturnKthToLast : Quest<SingleLL, int>
    {
        public override string Header => "Kth To Last";
        public override string Description => "In a singly linked list, find the Kth from last value. This example will use 3 for K";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL runData)
        {
            Console.WriteLine ("- Find 3rd from last value in: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override int RunStep(SingleLL runData)
        {
            return FindKthToLast (runData, 3);
        }


        private static int FindKthToLast(SingleLL theList, int k = 3)
        {
            return 0;
        }

    }
}
