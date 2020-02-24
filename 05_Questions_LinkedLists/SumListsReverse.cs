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
    class SumListsReverse : Quest<SingleLL[], SingleLL>
    {
        public override string Header => "SumListsReverse";
        public override string Description => "Sums given lists where each node is a digit. Digits are in reverse order";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun (0,   0);
            AddTestRun (10,  0);
            AddTestRun (9,   9);
            AddTestRun (503, 29);
        }

        // Shorthand for more complex uses of AddTestRun().
        protected override void AddTestRun(params object[] args)
        {
            int numOne = (int)args[0];
            int numTwo = (int)args[1];

            base.AddTestRun (new SingleLL[] { MakeNum (numOne), MakeNum (numTwo) }, MakeNum (numOne + numTwo));
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

            SingleLL.Node currOne = numOne.root;
            SingleLL.Node currTwo = numTwo.root;

            bool remainder = false;

            while (currOne != null || currTwo != null)
            {
                // Add digits together, plus remainder if necessary
                int sum = remainder ? 1 : 0;
                sum += currOne == null ? 0 : currOne.val;
                sum += currTwo == null ? 0 : currTwo.val;

                // Only add ones place, tens place turns into remainder
                result.AddLast (sum % 10);
                remainder = sum > 9;

                currOne = currOne?.next;
                currTwo = currTwo?.next;
            }

            // Has one more digit if a remainder still exists
            if (remainder)
                result.AddLast (1);

            return result;
        }
        

        private static SingleLL MakeNum(int number)
        {
            if (number == 0)
                return new SingleLL (0);

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
