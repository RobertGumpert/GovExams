using System;

namespace aads.LinkedList
{
    public class Example<T>
    {
        public Example() {
            var list = new MyLinkedList<String>();

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

            if (list.IsContains("My List!")) {
                Console.WriteLine("\nMy List - is contains.");
            }
            var indexOfItem = list.GetItemIndex("My List!");
            Console.WriteLine("My List have index - " + indexOfItem);
            list.Delete("My List!");
            list.Print();


            if (list.IsContains("World"))
            {
                Console.WriteLine("\nWorld - is contains.");
            }
            indexOfItem = list.GetItemIndex("World");
            Console.WriteLine("World - " + indexOfItem);
            list.Delete("World");
            list.Print();
        }
    }
}
