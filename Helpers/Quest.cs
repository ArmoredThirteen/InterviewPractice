using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    // Logic and data to run various kinds of questions in a standard format.
    // Each TestRun consists of the data to run the quest once and verify the results.
    public abstract class Quest<RunData, ResultData>
    {
        private class TestRun
        {
            public RunData runData;
            public ResultData expectedResult;

            public TestRun(RunData theRunData, ResultData theExpectedResult)
            {
                runData = theRunData;
                expectedResult = theExpectedResult;
            }
        }


        // All test run datas and their results.
        private List<TestRun> testRuns = new List<TestRun> ();

        // Add a value to testRuns, default base case takes a RunData and a ResultData.
        // Overloads are useful if building one of the datas is more involved.
        // Children should call base.AddTestRun() to add to the actual testRuns list.
        protected virtual void AddTestRun(params object[] args)
        {
            testRuns.Add (new TestRun((RunData)args[0], (ResultData)args[1]));
        }

        // Main method that controls the when and why of each question's process.
        // Iterate through all the runDatas to put them through RunStep.
        // Verifies results are as expected and runs AdmitFailure() when they don't.
        public void BuildAndRunTests()
        {
            Console.WriteLine (StringTools.MakeHeader (Header));
            Console.WriteLine (Description);
            Console.WriteLine ();

            BuildTestRuns ();

            for (int i = 0; i < testRuns.Count; i++)
            {
                StateTest (testRuns[i].runData);

                ResultData result = RunTest (testRuns[i].runData);
                StateResult (result);

                if (!VerifyResult (result, testRuns[i].expectedResult))
                    AdmitFailure (testRuns[i].expectedResult);

                Console.WriteLine ();
            }
            
            Console.WriteLine ();
        }


        // Both are used in opening header when triggering all testRuns.
        public abstract string Header { get; }
        public abstract string Description { get; }


        // Add values to runDatas and resultDatas for use in RunQuest().
        protected abstract void BuildTestRuns();
        
        // Use runData to perform desired operation and return the result.
        protected abstract ResultData RunTest (RunData runData);

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected virtual void StateTest(RunData runData)
        {
            Console.WriteLine ("- Processing: [" + runData + "]");
        }

        // True if result matches expectedResult or passes some other verification.
        protected virtual bool VerifyResult(ResultData result, ResultData expectedResult)
        {
            if (result != null && expectedResult != null)
                return result.Equals (expectedResult);

            if (result == null && expectedResult == null)
                return true;

            return false;
        }

        // Write the resulting data.
        protected virtual void StateResult(ResultData result)
        {
            Console.WriteLine ("  [" + result + "]");
        }

        // Write warning of algorithm failure, result was not as expected.
        protected virtual void AdmitFailure(ResultData expectedResult)
        {
            Console.WriteLine (" !!! -> Result should have been [" + expectedResult + "]");
        }
        
    }
}
