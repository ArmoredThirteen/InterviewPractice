using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    public class PartitionData
    {
        public int partValue;
        public SingleLL list;

        public PartitionData(int thePartValue, SingleLL theList)
        {
            partValue = thePartValue;
            list = theList;
        }
    }

    // Given value x, put all values greater or equal to on the right side of the list
    // Put all values less than to the left side of the list
    // If x exists within list it does not need to be in between the two sides
    class Partition : Quest<PartitionData, SingleLL>
    {
        public override string Header => "DeleteMiddleNode";
        public override string Description => "Remove middle node from singly linked list given only reference to node";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (new PartitionData (5, new SingleLL (ArrayTools.RandomInt (15, 0, 10))), null);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(PartitionData runData)
        {
            Console.WriteLine ("- Patrition on value " + runData.partValue + " for set: [" + runData.list + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL RunStep(PartitionData runData)
        {
            return PartitionList (runData.partValue, runData.list);
        }

        // True if result matches expectedResult.
        protected override bool VerifyResult(SingleLL result, SingleLL expectedResult)
        {
            return true;
        }


        public static SingleLL PartitionList(int partVal, SingleLL list)
        {
            SingleLL result = null;

            return result;
        }

    }
}
