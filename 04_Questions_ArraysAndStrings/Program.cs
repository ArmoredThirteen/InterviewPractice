using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void PrintUniqueCheck(string theStr)
        {
            Console.WriteLine ("Are chars unique in Str: " + theStr);
            Console.WriteLine (IsUnique.AreCharsUnique(theStr));
            Console.WriteLine ();
        }

    }
}
