﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = Console.LargestWindowWidth-155;
            Console.WindowHeight = Console.LargestWindowHeight-15;

            //IsUnique.RunExample ();
            //CheckPermutation.RunExample ();
            //URLify.RunExample ();
            //PalindromePermutation.RunExample ();
            OneAway.RunExample ();

            Console.WriteLine ("Press key to exit");
            Console.ReadKey (true);
        }

    }
}
