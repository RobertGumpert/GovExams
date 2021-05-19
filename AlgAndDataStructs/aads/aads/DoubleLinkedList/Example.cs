using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.DoubleLinkedList
{
    public class Example<T>
    {
        public Example()
        {
            var list = new MyDoubleLinkedList<String>();

            list.InsertAsFirst("Hello");
            list.InsertAsLast("World");
            list.InsertAsLast("it's me!");
            Console.WriteLine("\n");
            list.Print();

            list.InsertByIndex("Live is Good!", 2);
            Console.WriteLine("\n");
            list.Print();

            list.DeleteByIndex(2);
            Console.WriteLine("\n");
            list.Print();

            list.InsertByIndex("Live is bad!", 2);
            Console.WriteLine("\n");
            list.Print();

            list.InsertAsFirst("My List!");
            Console.WriteLine("\n");
            list.Print();

            list.Delete("My List!");
            Console.WriteLine("\n");
            list.Print();
        }
    }
}
