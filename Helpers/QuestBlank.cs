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
        protected override void BuildTestRuns()
        {
            AddTestRun (null, null);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateTest(object runData)
        {
            Console.WriteLine ("- Processing: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override object RunTest(object runData)
        {
            return null;
        }


        // True if result matches expectedResult or passes some other verification.
        protected override bool VerifyResult(object result, object expectedResult)
        {
            return result.Equals(expectedResult);
        }

        // Write the resulting data.
        protected override void StateResult(object result)
        {
            Console.WriteLine ("  [" + result + "]");
        }

        // Write warning of algorithm failure, result was not as expected.
        protected override void AdmitFailure(object expectedResult)
        {
            Console.WriteLine (" !!! -> Result should have been [" + expectedResult + "]");
        }

    }
}
