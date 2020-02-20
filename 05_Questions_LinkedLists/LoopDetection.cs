﻿using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    // Given a singly linked list, detect if there is corruption in the form of a loop.
    // A loop is where a node points back to an earlier node.
    class LoopDetection : Quest<SingleLL, bool>
    {
        public override string Header => "LoopDetection";
        public override string Description => "Detect if any nodes point to a previous node";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair (new SingleLL (), false);
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(SingleLL runData)
        {
            Console.WriteLine ("- Finding if loop exists in: [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunStep(SingleLL runData)
        {
            return HasLoop (runData);
        }


        public static bool HasLoop(SingleLL list)
        {
            return false;
        }

    }
}