using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Graph.MatrixGraph
{
    public class MyGraph
    {
        /// <summary>
        /// JAVA -> int[][] (долбоебизм...)
        /// </summary>
        private bool[,] adjacencyMatrix;
        private int size;

        public MyGraph(int sizeOfGraph)
        {
            /// <summary>
            /// JAVA -> new int[i][j] (долбоебизм...)
            /// </summary>
            adjacencyMatrix = new bool[sizeOfGraph, sizeOfGraph];
            size = sizeOfGraph;
        }

        public void InsertVertex(int i, int j)
        {
            if (i >= size || j >= size)
            {
                return;
            }
            adjacencyMatrix[i, j] = true;
            adjacencyMatrix[j, i] = true;
        }

        public void TraversalDeep(int from)
        {
            HashSet<int> buffer = new HashSet<int>();
            TraversalDeep(from, buffer);
        }

        private void TraversalDeep(int from, HashSet<int> buffer)
        {
            buffer.Add(from);
            for (int column = 0; column < size; column++)
            {
                if (adjacencyMatrix[from, column])
                {
                    if (buffer.Contains(column))
                    {
                        continue;
                    }
                    Console.Write("[ " + from + " -> " + column + " ] -> ");
                    TraversalDeep(column, buffer);
                    Console.Write("( return to vertex:" + from + " ) -> ");
                }
            }
            Console.Write("( exit from vertex:" + from + " ) -> ");
        }

        /*
        private void TraversalWidth(int from)
        {
            Stack<int> tempStack = GetVertexNeighbors(from);
            bool rowIsEmpty = false;
            while (rowIsEmpty == false)
            {
                Stack<int> elementsInLineStack = new Stack<int>();
                rowIsEmpty = true;
                Console.Write("[ from -> ");
                
            }
        }
        */

        public void TraversalWidth(int from)
        {
            HashSet<int> buffer = new HashSet<int>();
            buffer.Add(from);
            int level = 0;
            Console.Write("[ level " + level + ": " + from + "] -> ");
            Stack<int> elementOnCurrentLevel = new Stack<int>();
            GetVertexNeighbors(from, elementOnCurrentLevel, buffer);
            bool rowIsEmpty = false;
            while (rowIsEmpty == false)
            {
                level++;
                Stack<int> vertexesOnNextLevel = new Stack<int>();
                Console.Write("[ level " + level + ": ");
                while (elementOnCurrentLevel.Count() != 0)
                {
                    int vertexOnCurrentLevel = elementOnCurrentLevel.Pop();
                    GetVertexNeighbors(vertexOnCurrentLevel, vertexesOnNextLevel, buffer);
                    buffer.Add(vertexOnCurrentLevel);
                    Console.Write(vertexOnCurrentLevel + " -> ");
                }
                Console.Write("] -> ");
                if (vertexesOnNextLevel.Count() == 0)
                {
                    rowIsEmpty = true;
                }
                else
                {
                    
                    while (vertexesOnNextLevel.Count != 0)
                    {
                        int vertex = vertexesOnNextLevel.Pop();
                       
                        elementOnCurrentLevel.Push(vertex);
                    }
                }
            }
            return;
        }

        private void GetVertexNeighbors(int vertex, Stack<int> neighbors, HashSet<int> buffer)
        {
            for (int column = 0; column < size; column++)
            {
                if (adjacencyMatrix[vertex, column])
                {
                    if (buffer.Contains(column))
                    {
                        continue;
                    }
                    neighbors.Push(column);
                    buffer.Add(column);
                }
            }
        }
    }
}
