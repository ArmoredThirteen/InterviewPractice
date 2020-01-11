using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sorting;

namespace _01_Trees_Tries_Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = Console.LargestWindowWidth-155;
            Console.WindowHeight = Console.LargestWindowHeight-15;

            TrieExample ();
            Console.WriteLine ();

            Console.WriteLine ("=================================");
            Console.WriteLine ();

            BinaryTree<int> tree = BinaryTree_Control ();
            //BinaryTree<int> tree = BinaryTree_WorstCaseLeft ();
            //BinaryTree<int> tree = BinaryTree_WorstCaseRight ();
            //BinaryTree<int> tree = BinaryTree_RandomWithDuplicates ();
            //BinaryTree<int> tree = BinaryTree_RandomWithoutDuplicates ();

            Console.WriteLine ();
            Console.WriteLine ("value/weight/count");
            Console.WriteLine (tree.headNode.TreeGraphToString ());
            Console.WriteLine ();

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


        private static BinaryTree<int> BinaryTree_Control()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();

            //int[] treeVals = new int[] { 5, 1, 7, 0, 3, 4 };
            //int[] treeVals = new int[] { 5, 4, 8, 7, 9, 6 };
            int[] treeVals = ArrayTools.SequentialInts (24);
            ArrayTools.ReverseArray<int> (treeVals);

            
            for (int i = 0; i < treeVals.Length; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine ();
                    Console.WriteLine ("value/weight/count");
                    Console.WriteLine (tree.headNode.TreeGraphToString ());
                }
                tree.Insert (treeVals[i]);
            }

            return tree;
        }

        private static BinaryTree<int> BinaryTree_WorstCaseLeft()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();

            for (int i = 9; i >= 0; i--)
                tree.Insert (i);

            return tree;
        }

        private static BinaryTree<int> BinaryTree_WorstCaseRight()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();

            for (int i = 0; i < 10; i++)
                tree.Insert (i);

            return tree;
        }

        private static BinaryTree<int> BinaryTree_RandomWithDuplicates()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();
            Random rand = new Random ();

            for (int i = 0; i < 15; i++)
                tree.Insert (rand.Next (0, 10));

            return tree;
        }

        private static BinaryTree<int> BinaryTree_RandomWithoutDuplicates()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();

            int[] randomInts = ArrayTools.SequentialInts (10);
            ArrayTools.ShuffleArray<int> (randomInts);

            for (int i = 0; i < randomInts.Length; i++)
                tree.Insert (randomInts[i]);

            return tree;
        }

    }
}
