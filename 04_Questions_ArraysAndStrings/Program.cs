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

            //RunExampleByName ("IsUnique");
            RunAllExamples ();

            Console.WriteLine ("Press key to exit");
            Console.ReadKey (true);
        }


        static void RunExampleByName(string theName, string methodName = "RunExample")
        {
            IEnumerable<System.Type> classes = typeof(Example).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Example)) && type.Name == theName);
            RunMethodsInClasses (classes, methodName);
        }

        static void RunAllExamples(string methodName = "RunExample")
        {
            IEnumerable<System.Type> classes = typeof(Example).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Example)));
            RunMethodsInClasses (classes, methodName);
        }

        static void RunMethodsInClasses(IEnumerable<System.Type> classes, string methodName)
        {
            foreach (System.Type item in classes)
            {
                MethodInfo theMethod = item.GetMethod (methodName);
                if (theMethod == null)
                {
                    Console.WriteLine ("!!!!! -> Method '" + methodName + "()' not found in class '" + item.Name + "'");
                    continue;
                }
                theMethod.Invoke (null, null);
            }
        }

    }
}
