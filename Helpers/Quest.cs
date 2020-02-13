using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public abstract class Quest<RunData, ResultData>
    {
        public abstract string Header { get; }
        public abstract string Description { get; }

        protected List<RunData>    runDatas    = new List<RunData> ();
        protected List<ResultData> resultDatas = new List<ResultData> ();


        // Add values to runDatas and resultDatas for use in RunQuest().
        protected abstract void BuildDatas();
        
        // Use runData to perform desired operation and return the result.
        protected abstract ResultData RunStep (RunData runData);


        // Add values to runDatas and resultDatas at same time, since that's how it has to be anyway.
        protected void AddDataPair(RunData runData, ResultData expectedResult)
        {
            runDatas.Add (runData);
            resultDatas.Add (expectedResult);
        }


        // Write description of this particular RunStep(), namely to identify the current runData.
        protected virtual void StateGoals(RunData runData)
        {
            Console.WriteLine ("- Processing: [" + runData + "]");
        }

        // True if result matches expectedResult.
        protected virtual bool CompareResult(ResultData result, ResultData expectedResult)
        {
            return result.Equals(expectedResult);
        }

        // Write the resulting data.
        protected virtual void StateResult(ResultData result)
        {
            Console.WriteLine ("  " + result);
        }

        // Write warning of algorithm failure, result was not as expected.
        protected virtual void AdmitFailure(ResultData expectedResult)
        {
            Console.WriteLine (" !!! -> Result should have been " + expectedResult);
        }


        // Main method that controls the when and why of each question's process.
        // Iterate through all the runDatas to put them through RunStep.
        // Verifies results are as expected and runs AdmitFailure() when they don't.
        public void RunQuest()
        {
            Console.WriteLine (StringTools.MakeHeader (Header));
            Console.WriteLine (Description);
            Console.WriteLine ();

            if (runDatas.Count != resultDatas.Count)
            {
                Console.WriteLine ("!!!!! -> Failure: runDatas and resultDatas are not the same Length.");
                Console.WriteLine ();
                return;
            }

            BuildDatas ();

            for (int i = 0; i < runDatas.Count; i++)
            {
                StateGoals (runDatas[i]);

                ResultData result = RunStep (runDatas[i]);
                StateResult (result);

                if (!CompareResult (result, resultDatas[i]))
                    AdmitFailure (resultDatas[i]);

                Console.WriteLine ();
            }
            
            Console.WriteLine ();
        }
        
    }
}
