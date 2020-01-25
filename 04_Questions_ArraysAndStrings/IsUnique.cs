using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    static class IsUnique
    {
        // Time complexity O(n)
        // Each char is converted to an int which is used as an index in a BitArray
        // Given string is iterated over and the char is toggled to true in the BitArray
        public static bool IsStrUnique(string theStr)
        {
            if (theStr.Length == 1)
                return true;
            if (theStr.Length > char.MaxValue)
                return false;

            char[] charAra = theStr.ToCharArray ();
            BitArray charFound = new BitArray (char.MaxValue);

            for (int i = 0; i < charAra.Length; i++)
            {
                char currChar = charAra[i];
                if (charFound[currChar])
                {
                    Console.WriteLine ("Duplicate char '" + currChar + "' at index " + i);
                    return false;
                }
                charFound[currChar] = true;
            }

            return true;
        }

        // Time complexity O(n log(n)) to O(n^2)
        // Sorts the incoming array then iterates once to check if any char is next to itself
        // Time complexity is bottlenecked by sorting, which is Array.Sort() and should be QuickSort
        public static bool IsCharAraUniqueUsingSort(char[] charAra)
        {
            if (charAra.Length == 1)
                return true;
            if (charAra.Length > char.MaxValue)
                return false;

            Array.Sort (charAra);
            for (int i = 0; i < charAra.Length - 1; i++)
            {
                if (charAra[i] == charAra[i + 1])
                {
                    Console.WriteLine ("Duplicate char '" + charAra[i] + "'");
                    return false;
                }
            }

            return true;
        }

        // Time complexity O(n^2)
        // Checks string in-place by iterating through chars and
        // for each char iterates through remaining chars looking for duplicates.
        // Use cases are limited, perhaps is strings will be small and
        // memory overhead is a more major concern than the n^2 complexity...
        public static bool IsStringUniqueUsingNaive(string theStr)
        {
            if (theStr.Length == 1)
                return true;
            if (theStr.Length > char.MaxValue)
                return false;

            for (int i = 0; i < theStr.Length - 1; i++)
                for (int k = i + 1; k < theStr.Length; k++)
                    if (theStr[i] == theStr[k])
                    {
                        Console.WriteLine ("Duplicate char '" + theStr[k] + "'at index " + k);
                        return false;
                    }

            return true;
        }

    }
}
