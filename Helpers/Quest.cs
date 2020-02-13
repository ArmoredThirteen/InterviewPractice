﻿using System;
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


        protected abstract void BuildDatas();
        protected void AddDataPair(RunData runData, ResultData expectedResult)
        {
            runDatas.Add (runData);
            resultDatas.Add (expectedResult);
        }

        protected abstract void       StateGoals(RunData runData);
        protected abstract ResultData RunStep   (RunData runData);

        protected abstract bool CompareResult(ResultData result, ResultData expectedResult);
        protected abstract void StateResult  (ResultData result);

        protected abstract void AdmitFailure(ResultData expectedResult);


        public void RunQuest()
        {
            Console.WriteLine (StringTools.MakeHeader (Header));
            Console.WriteLine (Description);
            Console.WriteLine ();
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
