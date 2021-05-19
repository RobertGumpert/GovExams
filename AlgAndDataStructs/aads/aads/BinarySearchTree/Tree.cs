using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.BinarySearchTree
{
    public class Tree
    {
        private Item root;
        public Item Root { get { return root; } }

        public Tree() { }

        public Tree(int rootValue) {
            root = new Item(rootValue,0);
        }

        public void Insert(int value)
        {
            if (root == null)
            {
                root = new Item(value, 0);
                return;
            }
            Insert(root, value);
        }

        private void Insert(Item node, int value)
        {
            if (node.Value < value)
            {
                if (node.Right != null)
                {
                    Insert(node.Right, value);
                }
                else
                {
                    node.Right = new Item(value, node.DeepLevel + 1);
                    return;
                }
            }
            else
            {
                if (node.Left != null)
                {
                    Insert(node.Left, value);
                }
                else
                {
                    node.Left = new Item(value, node.DeepLevel + 1);
                    return;
                }
            }
        }

        public void Remove(int value)
        {
            Remove(root, value);
            return;
        }

        private void Remove(Item parent, int value)
        {
            if (value > parent.Value)
            {
                var child = parent.Right;

                if (child.Value == value)
                {
                    if (child.Right == null && child.Left == null)
                    {
                        parent.Right = null;
                        return;
                    }
                    if (child.Right == null && child.Left != null)
                    {
                        parent.Right = child.Left;
                        return;
                    }
                    if (child.Right != null && child.Left == null)
                    {
                        parent.Right = child.Right;
                        return;
                    }
                    if (child.Right != null && child.Left != null)
                    {
                        //parent.Right = child.Right;
                        Item node = Receive(child);
                        parent.Right = node;
                        return;
                    }
                }
                else
                {
                    Remove(parent.Right, value);
                }
            }
            else
            {
                var child = parent.Left;

                if (child.Value == value)
                {
                    if (child.Right == null && child.Left == null)
                    {
                        parent.Left = null;
                        return;
                    }
                    if (child.Right == null && child.Left != null)
                    {
                        parent.Left = child.Left;
                        return;
                    }
                    if (child.Right != null && child.Left == null)
                    {
                        // parent.Left = child.Right;
                        Item node = Receive(child);
                        parent.Left = node;
                        return;
                    }
                }
                else
                {
                    Remove(parent.Left, value);
                }
            }
        }

        public Item Receive(Item parent)
        {
            Item parentNode = parent;
            Item heirNode = parent;
            Item currentNode = parent.Right;
            while (currentNode != null) 
            {
                parentNode = heirNode;
                heirNode = currentNode;
                currentNode = currentNode.Left;
            }
            if (heirNode != parent.Right)
            { 
                parentNode.Left = heirNode.Right;
                heirNode.Right = parent.Right;
            }
            return heirNode;
        }


        public Item R(Item parent)
        {
            Item node = new Item(parent.Right.Value, parent.Right.DeepLevel-1);
        }
        
    }
}
