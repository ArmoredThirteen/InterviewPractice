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
        protected override void BuildDatas()
        {
            ConciseAddDataPair ();
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL[] runData)
        {
            Console.WriteLine ("- Check for intersection between: [" + runData[0] + "] and [" + runData[1] + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL.Node RunStep(SingleLL[] runData)
        {
            return FindIntersection (runData[0], runData[1]);
        }


        public static SingleLL.Node FindIntersection(SingleLL listOne, SingleLL listTwo)
        {
            return null;
        }


        // Shorthand for the verbose AddDataPair()
        private void ConciseAddDataPair()
        {
            AddDataPair (null, null);
        }

    }
}
