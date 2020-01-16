using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _01_Trees_Tries_Graphs.BinaryTree;
using Sorting;

namespace _01_Trees_Tries_Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = Console.LargestWindowWidth-155;
            Console.WindowHeight = Console.LargestWindowHeight-15;

            BinaryTreeExample ();

            Console.WriteLine ("Press key to exit");
            Console.ReadKey (true);
        }


        static void TrieExample()
        {
            Trie trie = new Trie ();
            trie.headNode.value = '-';

            trie.AddString ("Blah");
            trie.AddString ("Blue");
            trie.AddString ("Foo");

            Console.WriteLine (trie.headNode.TreeGraphToString ());
            Console.WriteLine ();

            Console.WriteLine ("Contains Blah: " + trie.HasString ("Blah"));
            Console.WriteLine ("Contains Blue: " + trie.HasString ("Blue"));
            Console.WriteLine ("Contains Foo:  " + trie.HasString ("Foo"));
            Console.WriteLine ("Contains '':   " + trie.HasString (""));
            Console.WriteLine ();

            Console.WriteLine ("Contains Blam: " + trie.HasString ("Blam"));
            Console.WriteLine ("Contains Toot: " + trie.HasString ("Toot"));
            Console.WriteLine ("Contains Fool: " + trie.HasString ("Fool"));
            Console.WriteLine ("Contains Flue: " + trie.HasString ("Flue"));
        }


        static void BinaryTreeExample()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();

            //int[] newVals = new int[] { 5, 3, 7, 2, 4, 6, 8 };
            //int[] newVals = new int[] { 5, 3, 7, 4, 6 };
            int[] newVals = ArrayTools.SequentialInts (10);
            //int[] newVals = new int[] { 7, 2, 8, 0, 4, 6 };
            ArrayTools.ReverseArray<int> (newVals);
            //ArrayTools.ShuffleArray<int> (newVals);

            for (int i = 0; i < newVals.Length; i++)
            {
                tree.Insert (newVals[i]);
                Console.WriteLine (tree);
                Console.WriteLine ("=========================");
            }

            for (int i = 0; i < 4; i++)
            {
                tree.DeleteMin (ref tree.head);
                Console.WriteLine ("=========================");
                Console.WriteLine (tree);
            }
        }

    }
}
