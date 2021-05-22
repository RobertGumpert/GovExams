using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aads.LinkedList;
using aads.DoubleLinkedList;
using aads.BinarySearchTree;
using aads.Sortings.QSort;

namespace aads
{
    class Program
    {
        static void Main(string[] args)
        {
            Sortings.ISortExample s;
            //
            Console.Write("Gnome\n");
            s = new Sortings.GnomeSort.Example();
            //
            Console.Write("Fast\n");
            s = new Sortings.QSort.Example();
            //
            Console.Write("Merge\n");
            s = new Sortings.MergeSort.Example();
            //
            Console.Write("Merge\n");
            s = new Sortings.CountingSort.Example();

            Console.ReadKey();
        }
    }
}
