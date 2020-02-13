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
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.WindowWidth = Console.LargestWindowWidth-130;
            Console.WindowHeight = Console.LargestWindowHeight-15;

            new RemoveDupes ().RunQuest ();

            Console.WriteLine ("Press key to exit");
            Console.ReadKey (true);
        }

    }
}
