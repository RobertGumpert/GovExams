using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Sortings.GnomeSort
{
    public class Example : ISortExample
    {
        public Example()
        {
            int[] arr = new int[] { 1, 4, 7, 3, 5, 0, 9, 12 };
            DoPrint(arr);
            var sort = new Sort(arr);
            DoPrint(arr);
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
