using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    class QuestBlank : Quest<object, object>
    {
        public override string Header => "Header";
        public override string Description => "Description";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            runDatas.Add (null);
            resultDatas.Add (null);
        }


        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(object runData)
        {
            Console.WriteLine ("Processing: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override object RunStep(object runData)
        {
            return true;
        }


        // True if result matches expectedResult.
        protected override bool CompareResult(object result, object expectedResult)
        {
            return true;
        }

        // Write the resulting data.
        protected override void StateResult(object result)
        {
            Console.WriteLine (result);
        }


        // Write warning of algorithm failure, result was not as expected.
        protected override void AdmitFailure(object expectedResult)
        {
            Console.WriteLine ("!!! -> Result should have been " + expectedResult);
        }

    }
}
