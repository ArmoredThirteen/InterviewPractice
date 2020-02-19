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
            ConciseAddDataPair (0,   0);
            ConciseAddDataPair (10,  0);
            ConciseAddDataPair (9,   9);
            ConciseAddDataPair (503, 29);
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
            SingleLL result = new SingleLL ();

            SingleLL.Node currOne = numOne.root;
            SingleLL.Node currTwo = numTwo.root;

            bool remainder = false;

            while (currOne != null || currTwo != null)
            {
                // Add digits together, plus remainder if necessary
                int digitOne = currOne == null ? 0 : currOne.val;
                int digitTwo = currTwo == null ? 0 : currTwo.val;
                int sum = digitOne + digitTwo + (remainder ? 1 : 0);

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


        // Shorthand for the verbose AddDataPair()
        private void ConciseAddDataPair(int numOne, int numTwo)
        {
            AddDataPair (new SingleLL[] { MakeNum (numOne), MakeNum (numTwo) }, MakeNum (numOne + numTwo));
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
