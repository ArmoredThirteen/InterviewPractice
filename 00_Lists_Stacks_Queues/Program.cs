using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace LinkedLists
{
    class Program
    {
        static int Main(string[] args)
        {
            BorderLine ();
            Line ("Welcome to the Stack/Queue Example Bot!");
            Line ("The booth is sealed in for your safety!");
            ContinueText ();

            BorderLine ();
            Line ("0 => Stacks! Prepare to be way educated");
            Line (" -Objects are added to the list's front");
            Line (" -And objects are taken from the front!");
            Line ();
            Line ("I know an example will clear this up :)");
            Line ();

            StackExample ();
            ContinueText ();

            BorderLine ();
            Line ("1 => Queues! Prepare to learn mega lots");
            Line (" -Objects need added to the list's rear");
            Line (" -But then are taken from at the front!");
            Line ();
            Line ("I know an example will clear this up :)");
            Line ();

            QueueExample ();
            ContinueText ();

            BorderLine ();
            Line ("We are very glad you're safely educated");
            Line ();
            Line ("Please tell your loved ones how amazing");
            Line ("Syndicate Educational Booths can teach!");
            Line ();

            BorderLine ();
            Line ("Press to unlock and exit learning booth");
            BorderLine ();
            Console.ReadKey (true);

            WriteWoman ();
            Thread.Sleep (1500);

            return 0;
        }

        static void ContinueText()
        {
            Line ();
            BorderLine ();
            Line ("To continue lesson, insert ME-ID and 4c");
            BorderLine ();
            Console.ReadKey (true);
            Line ();
            Line ();
        }


        static void StackExample()
        {
            int listSize = 4;
            Stack<char> theList = new Stack<char> ();

            Line ("           Start: []");

            for (int i = 0; i < listSize; i++)
            {
                char theChar = (char)(i + 97);
                theList.Push (theChar);
                Line ("Push: " + theChar + " | Result: " + theList);
            }

            for (int i = listSize - 1; i >= 0; i--)
            {
                Line (" Pop: " + theList.Pop () + " | Result: " + theList);
            }
        }

        static void QueueExample()
        {
            int listSize = 4;
            Queue<char> theList = new Queue<char> ();

            Line ("              Start: []");

            for (int i = 0; i < listSize; i++)
            {
                char theChar = (char)(i + 97);
                theList.Enqueue (theChar);
                Line ("Enqueue: " + theChar + " | Result: " + theList);
            }

            for (int i = listSize - 1; i >= 0; i--)
            {
                Line ("Dequeue: " + theList.Dequeue () + " | Result: " + theList);
            }
        }


        static void BorderLine(int delay = 100)
        {
            Thread.Sleep (delay);
            Console.WriteLine ("|`~. `~. `~. `~. `~. `~. `~. `~. `~. `~. `~.|");
        }

        static void Line(String theLine = "", int delay = 100)
        {
            Thread.Sleep (delay);
            String endAppend = new string (' ', 39-theLine.Length);
            Console.WriteLine ("|  " + theLine + endAppend + "  |");
        }


        static void WriteWoman()
        {
            int lineDelay = 50;

            Line ("", lineDelay);
            Line (" ,_____________________,",   lineDelay);
            Line (" |   .-.--.-.          |",   lineDelay);
            Line (" |  { /_)(_\\ }         |",  lineDelay);
            Line (" | { `}'. ./ `}        |",   lineDelay);
            Line (" |  {`}\\_c/{`}         |",  lineDelay);
            Line (" |   `_J  L_`          |",   lineDelay);
            Line (" | ,'   `' -.\\         |",  lineDelay);
            Line (" |/ /Y  o)  o)\\        |",  lineDelay);
            Line (" / / \\`-' `-'} )       |",  lineDelay);
            Line ("( {   \\    // /        |",  lineDelay);
            Line (" \\ \\  ;  . Y /         |", lineDelay);
            Line (" |\\ \\/      Y          |", lineDelay);
            Line (" | );    \\,/ \\         |", lineDelay);
            Line (" |  :     \\  |         |",  lineDelay);
            Line (" |   `.    \\ |         |",  lineDelay);
            Line (" |     `.   \\|         |",  lineDelay);
            Line (" |       `.  \\         |",  lineDelay);
            Line (" |         )  )        |",   lineDelay);
            Line (" |______  /  /_________|",   lineDelay);
            Line ("         (  /          ",    lineDelay);
            Line ("         ) /{          ",    lineDelay);
            Line ("        / /_`\\_        ",   lineDelay);
            Line ("       (_ \\_`\"'        ",  lineDelay);
            Line ("         `\"'           ",   lineDelay);
            BorderLine (lineDelay);
        }

    }
}
