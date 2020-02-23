using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    // Sum two numbers represented with linked lists where each node is a digit.
    // Digits are stored in forward order (so [5, 1, 3] is the number 315).
    // Sum is returned as another linked list, not as an int.
    class SumLists : Quest<SingleLL[], SingleLL>
    {
        public override string Header => "SumLists";
        public override string Description => "Sums given lists where each node is a digit. Digits are in forward order";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            NewTestRun (0,   0);
            NewTestRun (10,  0);
            NewTestRun (9,   9);
            NewTestRun (503, 29);
        }

        // Shorthand for more complex uses of AddTestRun()
        private void NewTestRun(int numOne, int numTwo)
        {
            AddTestRun (new SingleLL[] { MakeNum (numOne), MakeNum (numTwo) }, MakeNum (numOne + numTwo));
        }


        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(SingleLL[] runData)
        {
            Console.WriteLine ("- Adding: [" + runData[0] + "] + [" + runData[1] + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override SingleLL RunTest(SingleLL[] runData)
        {
            return Sum (runData[0], runData[1]);
        }


        public static SingleLL Sum(SingleLL numOne, SingleLL numTwo)
        {
            SingleLL result = new SingleLL ();

            PadSmallerNum (numOne, numTwo);

            if (SumRecurse (result, numOne?.root, numTwo?.root))
                result.AddFirst (1);

            return result;
        }

        private static void PadSmallerNum(SingleLL numOne, SingleLL numTwo)
        {
            int sizeDif = numOne.GetLength () - numTwo.GetLength ();

            // Pad numOne for each digit bigger numTwo is
            for (int i = 0; i < -sizeDif; i++)
                numOne.AddFirst (0);

            // Pad numTwo for each digit bigger numOne is
            for (int i = 0; i < sizeDif; i++)
                numTwo.AddFirst (0);
        }

        // Recursively go through and add digits together.
        // Return true if adding current digits has a remainder.
        private static bool SumRecurse(SingleLL result, SingleLL.Node currOne, SingleLL.Node currTwo)
        {
            if (currOne == null && currTwo == null)
                return false;

            // Add digits together, plus remainder if necessary
            int sum = SumRecurse (result, currOne?.next, currTwo?.next) ? 1 : 0;
            sum += currOne == null ? 0 : currOne.val;
            sum += currTwo == null ? 0 : currTwo.val;

            // Only add ones place, tens place turns into remainder
            result.AddFirst (sum % 10);
            return sum > 9;
        }
        

        private static SingleLL MakeNum(int number)
        {
            if (number == 0)
                return new SingleLL (0);

            SingleLL digitList = new SingleLL ();

            while (number > 0)
            {
                digitList.AddFirst (number % 10);
                number /= 10;
            }

            return digitList;
        }

    }
}
