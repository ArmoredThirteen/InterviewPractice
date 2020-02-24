using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    // Given a singly linked list, detect if there is corruption in the form of a loop.
    // A loop is where a node points back to an earlier node.
    class LoopDetection : Quest<SingleLL, bool>
    {
        public override string Header => "LoopDetection";
        public override string Description => "Detect if any nodes point to a previous node";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun (ArrayTools.SequentialInts (5), ArrayTools.SequentialInts (5, 10), true);
        }
        
        // Shorthand for more complex uses of AddTestRun().
        protected override void AddTestRun(params object[] args)
        {
            int[] valsStart = (int[])args[0];
            int[] valsLoop = (int[])args[1];
            bool expectedResult = (bool)args[2];

            SingleLL listStart = new SingleLL (valsStart);
            SingleLL listLoop = new SingleLL (valsLoop);
            SingleLL.Node loopRoot = listLoop.root;

            listStart.AddLast (listLoop);
            listLoop.GetLast ().next = loopRoot;

            base.AddTestRun (listStart, expectedResult);
        }


        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(SingleLL runData)
        {
            // TODO: Hacky hacky hard-coded 10 :(
            StringBuilder builder = new StringBuilder ();
            SingleLL.Node currNode = runData.root;
            for (int i = 0; i < 10; i++)
            {
                builder.Append (currNode);
                if (i < 9)
                    builder.Append (", ");
                currNode = currNode.next;
            }

            Console.WriteLine ("- Finding if loop exists in: [" + builder + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunTest(SingleLL runData)
        {
            return HasLoop (runData);
        }


        public static bool HasLoop(SingleLL list)
        {
            return false;
        }

    }
}
