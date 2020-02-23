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

        public override string ToString()
        {
            return list.ToString ();
        }
    }


    // Given value x, put all values greater or equal to on the right side of the list
    // Put all values less than to the left side of the list
    // If x exists within list it does not need to be in between the two sides
    class Partition : Quest<PartitionData, PartitionData>
    {
        public override string Header => "Partition";
        public override string Description => "Split list so left half is lower than given value and right half is greater than or equal to";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            NewTestRun (5, ArrayTools.RandomInt (10, 0, 10));
            NewTestRun (5, ArrayTools.RandomInt (10, 5, 10));
            NewTestRun (5, ArrayTools.RandomInt (10, 0, 4));
            NewTestRun (2, 1, 2);
            NewTestRun (5);
        }

        // Shorthand for more complex uses of AddTestRun()
        private void NewTestRun(int partVal, params int[] theVals)
        {
            AddTestRun (new PartitionData (partVal, new SingleLL (theVals)), null);
        }


        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(PartitionData runData)
        {
            Console.WriteLine ("- Patrition on value " + runData.partValue + " for set: [" + runData.list + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override PartitionData RunTest(PartitionData runData)
        {
            PartitionList (runData.partValue, runData.list);
            return new PartitionData (runData.partValue, runData.list);
        }

        // True if result matches expectedResult or passes some other verification.
        protected override bool VerifyResult(PartitionData result, PartitionData expectedResult)
        {
            bool foundPart = false;

            SingleLL.Node currNode = result.list.root;
            while (currNode != null)
            {
                // If first part has just been found then toggle foundPart
                if (!foundPart && currNode.val >= result.partValue)
                    foundPart = true;
                // If part was already found and any value that should be to the left is found, fail
                else if (foundPart && currNode.val < result.partValue)
                    return false;

                currNode = currNode.next;
            }

            return true;
        }

        // Write warning of algorithm failure, result was not as expected.
        protected override void AdmitFailure(PartitionData expectedResult)
        {
            Console.WriteLine (" !!! -> Result was not partitioned correctly, values not fully split left/right");
        }


        public static void PartitionList(int partVal, SingleLL list)
        {
            SingleLL.Node lowLead = null;
            SingleLL.Node highRoot = null;
            SingleLL.Node currNode = list.root;

            while (currNode != null)
            {
                // Store for later because the if statement damages currNode.next connection
                SingleLL.Node nextNode = currNode.next;
                
                // High value, add currNode after highRoot
                if (currNode.val >= partVal)
                {
                    currNode.next = highRoot;
                    highRoot = currNode;
                }
                // Low value, add currNode after lowLead
                else
                {
                    if (lowLead == null)
                        list.root = currNode;
                    else
                        lowLead.next = currNode;

                    lowLead = currNode;
                }

                currNode = nextNode;
            }

            // Link low and high sublists, or if no low values were found set root to be high sublist's root
            if (lowLead != null)
                lowLead.next = highRoot;
            else
                list.root = highRoot;
        }

    }
}
