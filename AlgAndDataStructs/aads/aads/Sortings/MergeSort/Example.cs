using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Sortings.MergeSort
{
    public class Example
    {
        public Example()
        {
            int[] arr = new int[] { 1, 4, 7, 3, 5, 0, 9, 12};
            
            var qsort = new Sort(arr);
         
        }

        private void DoPrint(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.Write("\n");
        }

    }
}
