using SimpleHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _04_Questions_ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.WindowWidth = Console.LargestWindowWidth-130;
            Console.WindowHeight = Console.LargestWindowHeight-15;

            RunAllExamples ();
            //RunExampleByName ("IsUnique");

            Console.WriteLine ("Press key to exit");
            Console.ReadKey (true);
        }


        static void RunAllExamples()
        {
            RunExampleByName ("IsUnique");
            RunExampleByName ("CheckPermutation");
            RunExampleByName ("URLify");
            RunExampleByName ("PalindromePermutation");
            RunExampleByName ("OneAway");
            RunExampleByName ("StringCompression");
        }

        static void RunExampleByName(string className)
        {
            System.Type theClass = (typeof(Example).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Example)) && type.Name == className)).First ();
            if (theClass == null)
            {
                Console.WriteLine ("!!!!! -> Class '" + theClass.Name + "' not found as an Example subclass");
                return;
            }

            MethodInfo theMethod = theClass.GetMethod ("RunExample");
            if (theMethod == null)
            {
                Console.WriteLine ("!!!!! -> Method 'RunExample()' not found in class '" + theClass.Name + "'");
                return;
            }

            FieldInfo headerField = theClass.GetField ("header", BindingFlags.Public | BindingFlags.Static);
            if (headerField == null)
                Console.WriteLine ("!!!!! -> Field 'header' not found in class '" + theClass.Name + "', using default value");

            FieldInfo descriptionField = theClass.GetField ("description", BindingFlags.Public | BindingFlags.Static);
            if (descriptionField == null)
                Console.WriteLine ("!!!!! -> Field 'description' not found in class '" + theClass.Name + "', using default value");

            string header = headerField == null ? theClass.Name : (string)headerField.GetValue (null);
            string description = descriptionField == null ? "No description" : (string)descriptionField.GetValue (null);

            Console.WriteLine (StringTools.MakeHeader (header));
            Console.WriteLine (description);
            Console.WriteLine ();
            Console.WriteLine ();

            theMethod.Invoke (null, null);
            Console.WriteLine ();
        }

    }
}
