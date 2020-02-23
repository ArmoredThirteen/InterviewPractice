using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramTools.SizeConsoleWindow ();

            new RemoveDupes ().BuildAndRunTests ();
            new ReturnKthToLast ().BuildAndRunTests ();
            new DeleteMiddleNode ().BuildAndRunTests ();
            new Partition ().BuildAndRunTests ();
            new SumListsReverse ().BuildAndRunTests ();
            new SumLists ().BuildAndRunTests ();
            new Palindrome ().BuildAndRunTests ();
            new Intersection ().BuildAndRunTests ();
            //new LoopDetection ().RunQuest ();

            ProgramTools.PauseForAnyKey ("Press any key to exit");
        }

    }
}
