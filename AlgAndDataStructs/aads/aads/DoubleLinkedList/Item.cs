using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.DoubleLinkedList
{
    public class Item<T>
    {
        public T Value { get; set; }
        public Item<T> Child { get; set; }
        public Item<T> Parent { get; set; }

        public Item() { }

        public Item(T Value)
        {
            this.Value = Value;
        }
    }
}
