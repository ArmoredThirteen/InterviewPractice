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
            Console.WriteLine ();
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

            Console.WriteLine (trie.HasString ("Blah"));
            Console.WriteLine (trie.HasString ("Blue"));
            Console.WriteLine (trie.HasString ("Foo"));
            Console.WriteLine (trie.HasString (""));
            Console.WriteLine ();

            Console.WriteLine (trie.HasString ("Blam"));
            Console.WriteLine (trie.HasString ("Toot"));
            Console.WriteLine (trie.HasString ("Fool"));
            Console.WriteLine (trie.HasString ("Flue"));
        }


        private static BinaryTree<int> BinaryTree_Control()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();

            // Depth 0
            tree.Insert (5);

            // Depth 1
            tree.Insert (3);
            tree.Insert (7);

            // Depth 2
            tree.Insert (1);
            tree.Insert (4);
            tree.Insert (6);
            tree.Insert (8);

            // Depth 3
            tree.Insert (0);
            tree.Insert (2);
            tree.Insert (9);

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
