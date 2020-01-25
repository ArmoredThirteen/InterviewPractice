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
            PrintUniqueCheck ("Fu-Bar");
            PrintUniqueCheck ("Foo-Bar");
            PrintUniqueCheck ("Fu-Barr");
            PrintUniqueCheck ("FFu-Barr");

            Console.WriteLine ("Press key to exit");
            Console.ReadKey (true);
        }

        private static void PrintUniqueCheck(string theStr)
        {
            Console.WriteLine ("-Are chars unique in Str: " + theStr);

            // BitArray toggle then iterate and use (int)char as bit index
            Console.WriteLine ("-                Indexes: " + BuildIndexesLine (theStr));
            Console.WriteLine (IsUnique.IsStrUnique(theStr));

            // Sorting char array the iterating and compare to neighbor
            //Console.WriteLine (IsUnique.IsCharAraUniqueUsingSort(theStr.ToCharArray()));

            // Brute-force double for loop
            //Console.WriteLine ("-                Indexes: " + BuildIndexesLine (theStr));
            //Console.WriteLine (IsUnique.IsStringUniqueUsingNaive(theStr));

            Console.WriteLine ();
        }

        private static string BuildIndexesLine(string theStr)
        {
            StringBuilder builder = new StringBuilder ();
            for (int i = 0; i < theStr.Length; i++)
                builder.Append (i);
            return builder.ToString();
        }

    }
}
