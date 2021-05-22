using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Sortings.GnomeSort
{
    public class Sort
    {
        public Sort(int[] arr)
        {
            DoSort(arr);
        }

        private void DoSort(int[] arr)
        {
            int i = 1;
            for (;i < arr.Length;)
            {
                if (i == 0)
                {
                    i = 1;
                }
                if (arr[i - 1] > arr[i])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                    i = i - 1;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
