using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleHelpers;

namespace _04_Questions_ArraysAndStrings
{
    class URLify
    {
        public static void RunExample()
        {
            Console.WriteLine (StringTools.MakeHeader ("URLify Spaces"));

            PrintURLify ("Hello World");
            PrintURLify (" HelloWorld ");
            PrintURLify ("Hello to the entire World");

            Console.WriteLine ();
        }

        private static void PrintURLify(string theStr)
        {
            Console.WriteLine (string.Concat ("Processing string [", theStr, "]"));

            // Set up character array with additional space at the end
            char[] charAra = new char[theStr.Length * 2];
            for (int i = 0; i < theStr.Length; i++)
                charAra[i] = theStr[i];

            int endIndex = URLifyCharAra (theStr.Length - 1, ref charAra);
            Console.WriteLine (string.Concat ("Encoded [", StringTools.CharAraToString (charAra, endIndex).TrimEnd (), "]"));

            Console.WriteLine ();
        }


        // Replaces all spaces in charAra with '%20'
        // Returns new endIndex value
        // As per the question rules, assumes charAra has room at the end to add extra characters
        // endIndex indicates the index after the last used character in charAra
        public static int URLifyCharAra(int endIndex, ref char[] charAra)
        {
            int currRead = endIndex;

            // Each space increases endIndex by 2 to make room for new characters
            for (int i = 0; i < endIndex; i++)
                if (charAra[i].Equals (' '))
                    endIndex += 2;

            int currWrite = endIndex;

            for (; currRead >= 0; currRead--, currWrite--)
            {
                // Just move the character
                if (!charAra[currRead].Equals (' '))
                {
                    charAra[currWrite] = charAra[currRead];
                }
                // Otherwise write out the encoded character
                else
                {
                    charAra[currWrite] = '0';
                    charAra[currWrite - 1] = '2';
                    charAra[currWrite - 2] = '%';

                    currWrite -= 2;
                    // Everything before first space is already in correct location
                    if (currRead == currWrite)
                        break;
                }
            }

            return endIndex;
        }

    }
}
