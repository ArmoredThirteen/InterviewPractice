using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    // See if two lists have an intersecting node.
    // Intersection is defined by node reference, not by the node value.
    // Return the found node.
    class Intersection : Quest<SingleLL[], SingleLL.Node>
    {
        public override string Header => "Intersection";
        public override string Description => "Checks if there is an intersection between two lists";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun (new int[] { },         new int[] { },            new int[] { });
            AddTestRun (new int[] { 1 },       new int[] { 10 },         new int[] { });
            AddTestRun (new int[] { 1 },       new int[] { 10 },         new int[] { 50, 60 });
            AddTestRun (new int[] { },         new int[] { 10 },         new int[] { 50, 60 });
            AddTestRun (new int[] { 1, 2, 3 }, new int[] { 10 },         new int[] { 50, 60 });
            AddTestRun (new int[] { 1, 2 },    new int[] { 10, 11, 12 }, new int[] { 50 });
        }

        // Shorthand for more complex uses of AddTestRun().
        protected override void AddTestRun(params object[] args)
        {
            int[] valsOne = (int[])args[0];
            int[] valsTwo = (int[])args[1];
            int[] endVals = (int[])args[2];
            
            // Add the endVals list to the end of both valsOne and valsTwo
            SingleLL endList = new SingleLL (endVals);
            SingleLL listOne = new SingleLL (valsOne).AddLast (endList);
            SingleLL listTwo = new SingleLL (valsTwo).AddLast (endList);

            // The intersection point is the expected return value
            // If endVals was empty then endList.root will be null, for the case of having no intersection
            base.AddTestRun (new SingleLL[] { listOne, listTwo }, endList.root);
        }


        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(SingleLL[] runData)
        {
            Console.WriteLine ("- Check for intersection between: [" + runData[0] + "] and [" + runData[1] + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL.Node RunTest(SingleLL[] runData)
        {
            return FindIntersection (runData[0], runData[1]);
        }

        // True if result matches expectedResult or passes some other verification.
        protected override bool VerifyResult(SingleLL.Node result, SingleLL.Node expectedResult)
        {
            return Object.ReferenceEquals (result, expectedResult);
        }


        public static SingleLL.Node FindIntersection(SingleLL listOne, SingleLL listTwo)
        {
            if (SingleLL.IsNullOrEmpty (listOne) || SingleLL.IsNullOrEmpty (listTwo))
                return null;

            int lenOne = listOne.GetLength ();
            int lenTwo = listTwo.GetLength ();
            int lenDif = Math.Abs (lenOne - lenTwo);

            SingleLL.Node currNodeOne = listOne.root;
            SingleLL.Node currNodeTwo = listTwo.root;

            for (int i = 0; i < lenDif; i++)
            {
                if (lenOne > lenTwo)
                    currNodeOne = currNodeOne.next;
                else
                    currNodeTwo = currNodeTwo.next;
            }

            while (currNodeOne != null)
            {
                if (Object.ReferenceEquals (currNodeOne, currNodeTwo))
                    return currNodeOne;

                currNodeOne = currNodeOne.next;
                currNodeTwo = currNodeTwo.next;
            }

            // No intersection found
            return null;
        }

    }
}
