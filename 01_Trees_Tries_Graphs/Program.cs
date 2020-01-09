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
            //TrieExample ();
            BinaryTreeExample ();
        }


        static void TrieExample()
        {
            Trie trie = new Trie ();
            trie.headNode.value = 'X';

            trie.AddString ("Blah");
            trie.AddString ("Blue");
            trie.AddString ("Foo");

            Console.WriteLine (trie);

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

            tree.headNode = tree.NewNode (5);
            tree.headNode.nodes[0] = (tree.NewNode (3));
            tree.headNode.nodes[1] = (tree.NewNode (10));
            tree.headNode.nodes[0].nodes[0] = (tree.NewNode (1));
            tree.headNode.nodes[0].nodes[1] = (tree.NewNode (4));
            tree.headNode.nodes[1].nodes[0] = (tree.NewNode (7));
            tree.headNode.nodes[1].nodes[1] = (tree.NewNode (12));

            Console.WriteLine ("Depth-First");
            Console.WriteLine (tree.headNode.DepthFirstToString ());
            Console.WriteLine ();
            Console.WriteLine ("Breadth-First");
            Console.WriteLine (tree.headNode.BreadthFirstToString ());
            Console.WriteLine ();

            tree.Insert (7);
        }

    }
}
