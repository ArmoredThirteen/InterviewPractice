using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public static class ProgramTools
    {
        public static void SizeConsoleWindow(int widthFromLargest = 130, int heightFromLargest = 15)
        {
            Console.WindowWidth = Console.LargestWindowWidth - widthFromLargest;
            Console.WindowHeight = Console.LargestWindowHeight - heightFromLargest;
        }

        public static void PauseForAnyKey(string continueText = "Press any key to continue")
        {
            Console.WriteLine (continueText);
            Console.ReadKey (true);
        }

    }
}
