using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace _04_Questions_ArraysAndStrings
{
    // Check if string or char[] has only unique characters.
    class IsUnique : Quest<char[], bool>
    {
        public override string Header => "Is Unique";
        public override string Description => "Checks if a string's characters are all unique";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair ("Fu-Bar".ToCharArray (),   true);
            AddDataPair ("Foo-Bar".ToCharArray (),  false);
            AddDataPair ("Fu-Barr".ToCharArray (),  false);
            AddDataPair ("FFu-Barr".ToCharArray (), false);
        }


        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(char[] runData)
        {
            StringBuilder builder = new StringBuilder ();
            builder.Append ("                             [");
            for (int i = 0; i < runData.Length; i++)
                builder.Append (i);
            builder.Append ("]");

            Console.WriteLine (builder);
            Console.WriteLine ("- Are chars unique in string [" + ArrayTools.GetContentsAsString<char> (runData) + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override bool RunStep(char[] runData)
        {
            return IsStrUnique (runData);
            //return IsCharAraUniqueUsingSort (runData);
            //return IsStringUniqueUsingNaive (runData);
        }


        // Time complexity O(n)
        // Each char is converted to an int which is used as an index in a BitArray
        // Given string is iterated over and the char is toggled to true in the BitArray
        public static bool IsStrUnique(char[] chara)
        {
            if (chara.Length == 1)
                return true;
            if (chara.Length > char.MaxValue)
                return false;

            BitArray charFound = new BitArray (char.MaxValue);

            for (int i = 0; i < chara.Length; i++)
            {
                char currChar = chara[i];
                if (charFound[currChar])
                {
                    Console.WriteLine ("  Duplicate char '" + currChar + "' at index " + i);
                    return false;
                }
                charFound[currChar] = true;
            }

            return true;
        }

        // Time complexity O(n log(n)) to O(n^2)
        // Sorts the incoming array then iterates once to check if any char is next to itself
        // Time complexity is bottlenecked by sorting, which is Array.Sort() and should be QuickSort
        public static bool IsCharAraUniqueUsingSort(char[] chara)
        {
            if (chara.Length == 1)
                return true;
            if (chara.Length > char.MaxValue)
                return false;

            Array.Sort (chara);
            for (int i = 0; i < chara.Length - 1; i++)
            {
                if (chara[i] == chara[i + 1])
                {
                    Console.WriteLine ("  Duplicate char '" + chara[i] + "'");
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
        public static bool IsStringUniqueUsingNaive(char[] chara)
        {
            if (chara.Length == 1)
                return true;
            if (chara.Length > char.MaxValue)
                return false;

            for (int i = 0; i < chara.Length - 1; i++)
                for (int k = i + 1; k < chara.Length; k++)
                    if (chara[i] == chara[k])
                    {
                        Console.WriteLine ("  Duplicate char '" + chara[k] + "'at index " + k);
                        return false;
                    }

            return true;
        }
        
    }
}
