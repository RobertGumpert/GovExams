using System;
using System.Collections.Generic;

namespace aads.LinkedList
{
    public class MyLinkedList<T>
    {
        private Item<T> head;
        private Item<T> tail;
        private int size = 1;
        public int Size { get { return size;  } }
   

        public MyLinkedList(){}

        public MyLinkedList(T rootValue) {
            head = new Item<T>(rootValue);
            tail = head;
        }

        public void InsertAsFirst(T rootValue) {
            var newItem = new Item<T>(rootValue);
            if (head is null)
            {
                head = newItem;
                tail = head;
                return;
            }
            newItem.Child = head;
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
            tail = newItem;
            size++;
        }


        public void InsertByIndex(T rootValue, uint index)
        {
            if (index > size) {
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
                newItem.Child = head;
                head = newItem;
                size++;
                return;
            }
            if (index == size)
            {
                tail.Child = newItem;
                tail = newItem;
                size++;
                return;
            }
            Item<T> next = head.Child;
            int i = 1;
            while (next != null)
            {
                if (i+1 == index)
                {
                    newItem.Child = next.Child;
                    next.Child = newItem;
                    size++;
                    return;
                }
                next = next.Child;
                i++;
            }
        }


        public void Delete(T value) {
            if (head is null) {
                return;
            }
            if (head == tail)
            {
                head = null; tail = null;
                return;
            }
            Item<T> deleteItem = new Item<T>(value);
            if (deleteItem.Value.Equals(head.Value)) {
                head = head.Child;
                size--;
                return;
            }
            Item<T> next = head;
            while (next.Child != null)
            {
                if (deleteItem.Value.Equals(next.Child.Value)) {
                    if (next.Child == tail) {
                        tail = next;
                    }
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
                head = head.Child;
                size--;
                return;
            }
            Item<T> next = head.Child;
            int i = 1;
            while (next.Child != null)
            {
                if (i+1 == index)
                {
                    if (next.Child == tail)
                    {
                        tail = next;
                    }
                    next.Child = next.Child.Child;
                    size--;
                    return;
                }
                next = next.Child;
            }
        }


        public bool IsContains(T value)
        {
            Item<T> next = head;
            Item<T> item = new Item<T>(value);
            while (next != null)
            {
                if (item.Value.Equals(next.Value))
                {
                    return true;
                }
                next = next.Child;
            }
            throw new ArgumentException("Element by value isn't exist.");
        }

     
        public int GetItemIndex(T value) {
            Item<T> item = new Item<T>(value);
            Item<T> next = head;
            int index = 0;
            while (next != null)         
            {
                if (item.Value.Equals(next.Value)) {
                    return index;
                }
                index++;
                next = next.Child;                     
            }
            throw new ArgumentException("Element by value isn't exist.");
        }

        public Item<T> GetItemByIndex(int index)
        {
            Item<T> Next = head;
            int i = 0;
            while (Next != null)
            {
                if (i == index) {
                    return Next;
                }
                Next = Next.Child;
                i++;
            }
            throw new ArgumentException("Element by index isn't exist.");
        }

        public void Print() {
            Item<T> next = head;
            while (next != null)
            {
                if (next.Child == null) {
                    Console.Write(next.Value + " -> x");
                    break;
                }
                Console.Write(next.Value + " -> ");
                next = next.Child;
            }
        }
    }
}
