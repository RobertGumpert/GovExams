using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Sortings.CountingSort
{
    public class Sort
    {
        public Sort(ref int[] arr)
        {
            int[] sort = DoSort(arr);
            arr = sort;
        }

        private int[] DoSort(int[] arr)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            int[] output = new int[arr.Length]; 
            int max = arr[0], min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (!buffer.ContainsKey(arr[i]))
                {
                    buffer[arr[i]] = 1;
                }
                else
                {
                    buffer[arr[i]] += 1;
                }
            }
            for (int i = 0; i < arr.Length;)
            {
                if (buffer.Count == 0)
                {
                    break;
                }
                min = buffer.Min(x => x.Key);
                int count = buffer[min];
                if (count == 1)
                {
                    output[i] = min;
                    i++;
                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        output[i] = min;
                        i++;
                    }
                }
                buffer.Remove(min);
            }
            return output;
        }
    }
}
