using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.BinarySearchTree
{
    public class Item
    {
        public int DeepLevel { get; set; }
        public int Value { get; set; }
        public Item Left { get; set; }
        public Item Right { get; set; }

        public Item(int value, int lvl)
        {
            Value = value;
            DeepLevel = lvl;
        }
    }
}
