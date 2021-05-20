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
                        parent.Right = child.Right;
                        Item minimumOfRightFork = GetMinimum(child.Right);
                        minimumOfRightFork.Left = child.Left;
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
                        parent.Left = child.Left;
                        Item minimumOfRightFork = GetMinimum(child.Right);
                        minimumOfRightFork.Left = child.Left;
                        return;
                    }
                }
                else
                {
                    Remove(parent.Left, value);
                }
            }
        }

       
        public Item GetMinimum(Item node)
        {
            Item left = node.Left;
            while (true)
            {
                if (left != null)
                {
                    return left;
                }
                left = left.Left;
            }
        }

        public Item GetMinimum()
        {
            Item left = root.Left;
            while (true)
            {
                if (left != null)
                {
                    return left;
                }
                left = left.Left;
            }
        }


        public void Print()
        { 
            Stack<Item> tempStack = new Stack<Item>();
            tempStack.Push(root);
            int distanceBetweenLineElements = 32; 
            bool isRowEmpty = false;
            String separator = "-----------------------------------------------------------------";
            Console.Write(separator + "\n");
            while (isRowEmpty == false)
            {
                // складываем все элементы в строке в стэк.
                Stack<Item> elementsInLineStack = new Stack<Item>();
                isRowEmpty = true;
                for (int j = 0; j < distanceBetweenLineElements; j++)
                {
                    Console.Write(".");
                }
                while (tempStack.Count() != 0)
                { 
                    Item nextElementFromLine = tempStack.Pop(); 
                    if (nextElementFromLine != null)
                    {
                        Console.Write(nextElementFromLine.Value); 
                        elementsInLineStack.Push(nextElementFromLine.Left); 
                        elementsInLineStack.Push(nextElementFromLine.Right);
                        if (nextElementFromLine.Left != null || nextElementFromLine.Right != null)
                        { 
                            isRowEmpty = false;
                        }
                    }
                    else
                    {
                        Console.Write("__");
                        // left
                        elementsInLineStack.Push(null);
                        // right
                        elementsInLineStack.Push(null);
                    }
                    for (int j = 0; j < distanceBetweenLineElements * 2 - 2; j++)
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
                distanceBetweenLineElements /= 2;
                while (elementsInLineStack.Count() != 0)
                { 
                    tempStack.Push(elementsInLineStack.Pop());
                }
            }
            Console.Write(separator + "\n");
        }
    }
}
