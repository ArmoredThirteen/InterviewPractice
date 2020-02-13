using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    class QuestBlankSmall : Quest<object, object>
    {
        public override string Header => "Header";
        public override string Description => "Description";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (null, null);
        }

        // Use runData to perform desired operation and return the result.
        protected override object RunStep(object runData)
        {
            return null;
        }

    }
}
