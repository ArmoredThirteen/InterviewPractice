using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace _04_Questions_ArraysAndStrings
{
    // Compress a string by counting repeated characters.
    // So like [abbccccddd] would become [a1b2c4d3].
    // If string would not become shorter, return original string.
    // String can only have characters a-z and A-Z.
    class StringCompression : Quest<string, string>
    {
        public override string Header => "String Compression";
        public override string Description => "Replaces chars with 'char'+'charCount', compressing strings with enough repeating characters";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildTestRuns()
        {
            AddTestRun ("",    "");
            AddTestRun ("a",   "a");
            AddTestRun ("sup", "sup");
            AddTestRun ("ssssuup", "s4u2p1");
            AddTestRun ("SsSsSsupppppppppppp", "S1s1S1s1S1s1u1p12");
        }

        // Use runData to perform desired operation and return the result.
        protected override string RunTest(string runData)
        {
            return GetCompressedString (runData);
        }
        

        private static string GetCompressedString(string theStr)
        {
            if (string.IsNullOrEmpty (theStr))
                return theStr;
            if (theStr.Length < 3)
                return theStr;

            StringBuilder result = new StringBuilder ();
            char currChar = theStr[0];
            int count = 1;

            // Start at 1 since curr values are already primed with first character
            for (int i = 1; i < theStr.Length; i++)
            {
                if (currChar == theStr[i])
                    count++;
                else
                {
                    result.Append (currChar);
                    result.Append (count);
                    currChar = theStr[i];
                    count = 1;
                }
            }

            result.Append (currChar);
            result.Append (count);

            return result.Length < theStr.Length ? result.ToString () : theStr;
        }

    }
}
