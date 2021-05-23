using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Sortings.RadixSort
{
    public class Sort {
        public Sort(int[] arr)
        {
            DoSort(arr);
        }

        private void DoSort(int[] arr)
        {
            int maxCountRadix = 0;
            int maxValueOfRadix = 0;
            int passedRadix = 0;
            int swap = 1;
            Dictionary<int, Queue<int>> radixBuffer = new Dictionary<int, Queue<int>>();
            GetStat(arr, ref maxCountRadix, ref maxValueOfRadix);
            //Console.Write("Max value radix: " + maxValueOfRadix + ", max count of radix: " + maxCountRadix);
            while (passedRadix != maxCountRadix)
            {
                //Console.Write("\nRADIX: " + passedRadix + ":\n");
                int i = 0;
                for (; i < arr.Length; i++)
                {
                    int temp = arr[i];
                    if (passedRadix > 0)
                    {
                        temp /= swap;
                    }
                    int radix = temp % 10;
                    if (!radixBuffer.ContainsKey((radix)))
                    {
                        var q = new Queue<int>();
                        q.Enqueue(arr[i]);
                        radixBuffer[radix] = q;
                    }
                    else
                    {
                        radixBuffer[radix].Enqueue(arr[i]);
                    }
                    //Console.Write("\n\t\t" + arr[i] + ": " +radix);           
                }
                i = 0;
                while (radixBuffer.Count() != 0)
                {
                    int min = radixBuffer.Min(x => x.Key);                 
                    Queue<int> q = radixBuffer[min];
                    int sizeOfq = q.Count();
                    for (int j = 0 ; j < sizeOfq; j++)
                    {
                        arr[i] = q.Dequeue();
                        i++;
                    }
                    radixBuffer.Remove(min);
                }
                radixBuffer = new Dictionary<int, Queue<int>>();
                swap *= 10;
                passedRadix++; 
            }
            return;
        }

        private void GetStat(int[] arr, ref int maxCountRadix, ref int maxValueOfRadix)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int number = arr[i];
                int countRadix = 0;
                while (number != 0)
                {
                    int radix = number % 10;
                    if (radix > maxValueOfRadix)
                    {
                        maxValueOfRadix = radix;
                    }                   
                    number /= 10;
                    countRadix++;
                }
                if (countRadix > maxCountRadix)
                {
                    maxCountRadix = countRadix;
                }
            }
        }
    }
}
