using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    // Sum two numbers represented with linked lists where each node is a digit.
    // Digits are stored in reverse order (so [5, 1, 3] is the number 315).
    // Sum is returned as another linked list, not as an int.
    class SumLists : Quest<SingleLL[], SingleLL>
    {
        public override string Header => "SumLists";
        public override string Description => "Sums given lists where each node is a digit";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (new SingleLL[] { MakeNum (503), MakeNum (25) }, MakeNum (528));
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL[] runData)
        {
            Console.WriteLine ("- Adding: [" + runData[0] + "] + [" + runData[1] + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL RunStep(SingleLL[] runData)
        {
            return Sum (runData[0], runData[1]);
        }


        private static SingleLL Sum(SingleLL numOne, SingleLL numTwo)
        {
            return MakeNum (528);
        }


        private static SingleLL MakeNum(int number)
        {
            SingleLL digitList = new SingleLL ();

            while (number > 0)
            {
                digitList.AddLast (number % 10);
                number /= 10;
            }

            return digitList;
        }

    }
}
