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

            // Manually built default starting tree
            // Once insertion is working do that instead :I
            tree.headNode = tree.NewNode (5);
            //tree.headNode.nodes.Add (null);
            //tree.headNode.nodes.Add (null);

            tree.headNode.nodes[0] = (tree.NewNode (3));
            //tree.headNode.nodes[0].nodes.Add (null);
            //tree.headNode.nodes[0].nodes.Add (null);
            tree.headNode.nodes[1] = (tree.NewNode (10));
            //tree.headNode.nodes[1].nodes.Add (null);
            //tree.headNode.nodes[1].nodes.Add (null);

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

            Console.WriteLine ("Visual Tree");
            Console.WriteLine (tree.headNode.TreeGraphToString ());
            Console.WriteLine ();

            tree.Insert (7);
        }

    }
}
