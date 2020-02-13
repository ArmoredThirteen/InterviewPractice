using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    class RemoveDupes : Quest<int, bool>
    {
        public override string Header => "RemoveDupes";
        public override string Description => "Removes duplicate values from unsorted list";


        protected override void BuildDatas()
        {
            runDatas.Add (1);
            resultDatas.Add (true);

            runDatas.Add (2);
            resultDatas.Add (false);
        }


        protected override void StateGoals(int runData)
        {
            Console.WriteLine ("Check if " + runData + " equals 1");
        }

        protected override bool RunStep(int runData)
        {
            return runData == 1;
        }


        protected override bool CompareResult(bool result, bool expectedResult)
        {
            return result == expectedResult;
        }

        protected override void StateResult(bool result)
        {
            Console.WriteLine (result);
        }


        protected override void AdmitFailure(bool expectedResult)
        {
            Console.WriteLine ("!!! -> Result should have been " + expectedResult);
        }

    }
}
