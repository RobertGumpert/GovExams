using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.DoubleLinkedList
{
    public class MyDoubleLinkedList<T>
    {

        private Item<T> head;
        private Item<T> tail;
        private int size = 1;
        public int Size { get { return size; } }


        public MyDoubleLinkedList() { }

        public MyDoubleLinkedList(T rootValue)
        {
            head = new Item<T>(rootValue);
            tail = head;
        }

        public void InsertAsFirst(T rootValue)
        {
            var newItem = new Item<T>(rootValue);
            if (head is null)
            {
                head = newItem;
                tail = head;
                return;
            }
            head.Parent = newItem;
            newItem.Child = head;
            newItem.Parent = null;
            head = newItem;
            size++;
        }

        public void InsertAsLast(T rootValue)
        {
            var newItem = new Item<T>(rootValue);
            if (tail is null)
            {
                head = newItem;
                tail = head;
                return;
            }
            tail.Child = newItem;
            newItem.Child = null;
            newItem.Parent = tail;
            tail = newItem;
            size++;
        }


        public void InsertByIndex(T rootValue, uint index)
        {
            if (index > size)
            {
                return;
            }
            var newItem = new Item<T>(rootValue);
            if (tail is null && head is null)
            {
                head = newItem;
                tail = head;
                size++;
                return;
            }
            if (index == 0)
            {
                head.Parent = newItem;
                newItem.Child = head;
                newItem.Parent = null;
                head = newItem;
                size++;
                return;
            }
            if (index == size)
            {
                tail.Child = newItem;
                newItem.Child = null;
                newItem.Parent = tail;
                tail = newItem;
                size++;
                return;
            }
            Item<T> next = head.Child;
            int i = 1;
            while (next != null)
            {
                if (i + 1 == index)
                {
                    newItem.Parent = next;
                    newItem.Child = next.Child;
                    next.Child.Parent = newItem;
                    next.Child = newItem;
                    size++;
                    return;
                }
                next = next.Child;
                i++;
            }
        }

        public void Delete(T value)
        {
            if (head is null)
            {
                return;
            }
            if (head == tail)
            {
                head = null; tail = null;
                return;
            }
            Item<T> deleteItem = new Item<T>(value);
            if (deleteItem.Value.Equals(head.Value))
            {
                head.Child.Parent = null;
                head = head.Child;
                size--;
                return;
            }
            Item<T> next = head;
            while (next.Child != null)
            {
                if (deleteItem.Value.Equals(next.Child.Value))
                {
                    if (next.Child == tail)
                    {
                        tail = next;
                    }
                    next.Child.Child.Parent = next;
                    next.Child = next.Child.Child;
                    size--;
                    return;
                }
                next = next.Child;
            }
        }


        public void DeleteByIndex(uint index)
        {
            if (index > size)
            {
                return;
            }
            if (tail is null && head is null)
            {
                return;
            }
            if (index == 0)
            {
                head.Child.Parent = null;
                head = head.Child;
                size--;
                return;
            }
            Item<T> next = head.Child;
            int i = 1;
            while (next.Child != null)
            {
                if (i + 1 == index)
                {
                    if (next.Child == tail)
                    {
                        tail = next;
                    }
                    next.Child.Child.Parent = next;
                    next.Child = next.Child.Child;
                    size--;
                    return;
                }
                next = next.Child;
            }
        }

        public void Print()
        {
            Item<T> next = head;
            while (next != null)
            {
                if (next.Child == null)
                {
                    Console.Write(next.Value + " -> x");
                    break;
                }
                Console.Write(next.Value + " -> ");
                next = next.Child;
            }
        }
    }
}
