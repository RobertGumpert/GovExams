using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.BinarySearchTree
{
    public class Example
    {
        public Example()
        {
            var tree = new Tree();

            tree.Insert(33);
            tree.Insert(48);
            tree.Insert(46);
            tree.Insert(61);
            tree.Insert(59);
            tree.Insert(64);
            tree.Insert(45);
            tree.Insert(47);
            tree.Insert(32);
            tree.Print();

            tree.Remove(48);
            tree.Print();

            tree.Remove(59);
            tree.Print();

            //tree.Print(tree.Root, 0);
            Console.WriteLine();
        }
    }
}
