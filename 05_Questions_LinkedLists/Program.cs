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

            //new RemoveDupes ().RunQuest ();
            //new ReturnKthToLast ().RunQuest ();
            //new DeleteMiddleNode ().RunQuest ();
            new Partition ().RunQuest ();

            ProgramTools.PauseForAnyKey ("Press any key to exit");
        }

    }
}
