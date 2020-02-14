using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace _04_Questions_ArraysAndStrings
{
    // Replace all spaces in a string with %20.
    // String is char[] that has enough space at end to hold the final string.
    class URLify : Quest<string, string>
    {
        public override string Header => "URLify";
        public override string Description => "Replaces space characters with [%20]";


        // Build lists that determine RunStep() data and each of their expected results.
        protected override void BuildDatas()
        {
            AddDataPair ("Hello World",   "Hello%20World");
            AddDataPair (" HelloWorld  ", "%20HelloWorld%20%20");
            AddDataPair ("Hello to the entire World", "Hello%20to%20the%20entire%20World");
        }

        // Write description of this particular RunStep(), namely to identify the current runData.
        protected override void StateGoals(string runData)
        {
            Console.WriteLine ("- Encoding spaces to '%20' in string [" + runData + "]");
        }

        // Use runData to perform desired operation and return the result.
        protected override string RunStep(string runData)
        {
            // Set up character array with additional space at the end
            char[] chara = new char[runData.Length * 2];
            for (int i = 0; i < runData.Length; i++)
                chara[i] = runData[i];

            URLifyCharAra (runData.Length, chara);
            return new string (chara).Trim (default (char));
        }


        // Replaces all spaces in charAra with '%20'
        // Returns new endIndex value
        // As per the question rules, assumes chara has room at the end to add extra characters
        // endIndex indicates the index after the last used character in charAra
        public static void URLifyCharAra(int endIndex, char[] chara)
        {
            int currRead = endIndex;

            // Each space increases endIndex by 2 to make room for new characters
            for (int i = 0; i < endIndex; i++)
                if (chara[i].Equals (' '))
                    endIndex += 2;

            int currWrite = endIndex;

            for (; currRead >= 0; currRead--, currWrite--)
            {
                // Just move the character
                if (!chara[currRead].Equals (' '))
                {
                    chara[currWrite] = chara[currRead];
                }
                // Otherwise write out the encoded character
                else
                {
                    chara[currWrite] = '0';
                    chara[currWrite - 1] = '2';
                    chara[currWrite - 2] = '%';

                    currWrite -= 2;
                    // Everything before first space is already in correct location
                    if (currRead == currWrite)
                        break;
                }
            }
        }

    }
}
