using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramTools.SizeConsoleWindow ();

            new IsUnique ().RunQuest ();
            new CheckPermutation ().RunQuest ();
            new URLify ().RunQuest ();
            new PalindromePermutation ().RunQuest ();
            new OneAway ().RunQuest ();
            new StringCompression ().RunQuest ();
            new RotateMatrix ().RunQuest ();
            new ZeroMatrix ().RunQuest ();
            new StringRotation ().RunQuest ();

            ProgramTools.PauseForAnyKey ("Press any key to exit");
        }

    }
}
