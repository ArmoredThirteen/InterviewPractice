using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleHelpers
{
    public static class StringTools
    {
        public static String MakeHeader(string title, char borderChar = '=')
        {
            String titleLine = string.Concat (borderChar, borderChar, "  ", title, "  ", borderChar, borderChar);
            String seperator = MakeSeperator (titleLine.Length, borderChar);
            return string.Concat (seperator, Environment.NewLine, titleLine, Environment.NewLine, seperator);
        }

        public static String MakeSeperator(int length, char borderChar = '=')
        {
            return new string (borderChar, length);
        }


        // Appends characters up to and including endIndex into string
        // If endIndex is < 0, charAra.Length is used as end
        public static string CharAraToString(char[] charAra, int endIndex = -1)
        {
            StringBuilder builder = new StringBuilder ();

            if (endIndex < 0)
                endIndex = charAra.Length - 1;

            for (int i = 0; i <= endIndex; i++)
                builder.Append (charAra[i]);

            return builder.ToString ();
        }

        public static void CharCountsAdd(char[] charAra, int[] counts)
        {
            for (int i = 0; i < charAra.Length; i++)
                counts[charAra[i]]++;
        }

        public static void CharCountsRemove(char[] charAra, int[] counts)
        {
            for (int i = 0; i < charAra.Length; i++)
                counts[charAra[i]]--;
        }

    }
}
