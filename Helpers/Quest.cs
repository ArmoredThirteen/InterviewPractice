using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    abstract class Quest
    {
        public abstract string Header { get; }
        public abstract string Description { get; }

        protected abstract object[] RunDatas { get; }
        protected abstract object[] ExpectedResults { get; }


        protected abstract void StateGoals(object runData);
        protected abstract object RunStep(object runData);
        protected abstract void StateResult(object result);
        protected abstract bool CompareResult(object result, object expectedResult);
        protected abstract void AdmitFailure(object expectedResult);


        public void RunQuest()
        {
            Console.WriteLine (StringTools.MakeHeader (Header));
            Console.WriteLine (Description);
            Console.WriteLine ();
            Console.WriteLine ();

            for (int i = 0; i < RunDatas.Length; i++)
            {
                StateGoals (RunDatas[i]);

                object result = RunStep (RunDatas[i]);
                StateResult (result);

                if (CompareResult (result, ExpectedResults[i]))
                    AdmitFailure (ExpectedResults[i]);
            }
            
            Console.WriteLine ();
        }
        
    }
}
