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

            new IsUnique ().BuildAndRunTests ();
            new CheckPermutation ().BuildAndRunTests ();
            new URLify ().BuildAndRunTests ();
            new PalindromePermutation ().BuildAndRunTests ();
            new OneAway ().BuildAndRunTests ();
            new StringCompression ().BuildAndRunTests ();
            new RotateMatrix ().BuildAndRunTests ();
            new ZeroMatrix ().BuildAndRunTests ();
            new StringRotation ().BuildAndRunTests ();

            ProgramTools.PauseForAnyKey ("Press any key to exit");
        }

    }
}
