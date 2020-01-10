using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            TrieExample ();

            Console.WriteLine ();
            Console.WriteLine ("=================================");
            Console.WriteLine ();

            BinaryTreeExample ();

            Console.WriteLine ("Press key to continue");
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

        static void BinaryTreeExample()
        {
            BinaryTree<int> tree = new BinaryTree<int> ();

            // Default starting tree
            tree.Insert (5);
            tree.Insert (3);
            tree.Insert (10);
            tree.Insert (1);
            tree.Insert (4);
            tree.Insert (7);
            tree.Insert (12);
            Console.WriteLine ();

            Console.WriteLine (tree.headNode.TreeGraphToString ());
            Console.WriteLine ();

            tree.Insert (0);
            Console.WriteLine ();
            tree.Insert (11);
            Console.WriteLine ();
            tree.Insert (7);
            Console.WriteLine ();

            Console.WriteLine (tree.headNode.TreeGraphToString ());
            Console.WriteLine ();
        }

    }
}
