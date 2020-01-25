using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    class URLify
    {
        #region Run Example
        public static void RunExample()
        {
            Console.WriteLine ("===================================");
            Console.WriteLine ("==     URLify Spaces             ==");
            Console.WriteLine ("===================================");

            PrintURLify ("blah blah");

            Console.WriteLine ();
        }

        private static void PrintURLify(string theStr)
        {
            Console.WriteLine (string.Concat ("Encoding spaces in string [", theStr, "]"));

            // Set up character array with additional space at the end
            char[] charAra = new char[theStr.Length * 2];
            for (int i = 0; i < theStr.Length; i++)
                charAra[i] = theStr[i];

            int trimIndex = URLifyCharAra (theStr.Length, ref charAra);
            Console.WriteLine (string.Concat ("Encoded [", CharAraToString (trimIndex, charAra).TrimEnd (), "]"));

            Console.WriteLine ();
        }

        // Appends characters up to trimIndex into string
        // If trimIndex is < 0, charAra.Length is used as end
        private static string CharAraToString(int trimIndex, char[] charAra)
        {
            StringBuilder builder = new StringBuilder ();

            int endIndex = trimIndex >= 0 ? trimIndex : charAra.Length;

            for (int i = 0; i < endIndex; i++)
                builder.Append (charAra[i]);

            return builder.ToString ();
        }
        #endregion


        // As per the question rules, assumes charAra has room at the end to add extra characters
        // trimIndex indicates the index after the last used character in charAra
        // Returns new trimIndex value
        // Replaces all spaces in charAra with '%20'
        public static int URLifyCharAra(int trimIndex, ref char[] charAra)
        {
            return trimIndex;
        }

    }
}
