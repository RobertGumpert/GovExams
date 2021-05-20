using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Sortings.MergeSort
{
    public class Sort
    {
        // N * log(N)
        public Sort(int[] arr)
        {          
            DoSort(arr, 0, arr.Length-1);
        }

        private void DoSort(int[] arr, int first, int last)
        {
            if (last <= first)
            {
                return;
            }

            // Дробим массив по середине на меленькие части,
            // до тех пор пока длины половинок не станут равны одному элменту.
            // Пример:
            // {1,2,3,4,5,6,9,10}
            //      -> A: {1}; B: {2}
            //      -> A: {3}; B: {4}
            //      -> A: {1,2}; B: {3,4}
            //      -> A: {5}; B: {6}
            //      -> A: {9}; B: {10}
            //      -> A: {5,6}; B: {9,10}
            //      -> A: {1,2,5,6}; B: {5,6,9,10}
            //
            //
            int middle = first + (last - first) / 2;
            DoSort(arr, first, middle);
            DoSort(arr, middle + 1, last);

            int[] arrC = new int[arr.Length];
            // first и last - диапозон индексов двух половинок.
            // {1,2,3,4,5,6} - исходный массив.
            // Две половинки - {1,2} {3,4}, first = 0, last = 3
            // Заполняем временный буффер.
            //
            for (int i = first; i <= last; i++)
            {
                arrC[i] = arr[i];
            }
           
            // Первый элемент, первой половины  
            int indexArrA = first;
            // первый элемент, второй половины
            int indexArrB = middle + 1;

            for (int i = first; i <= last; i++)
            {
                if (indexArrA > middle)
                {
                    arr[i] = arrC[indexArrB];
                    indexArrB++;
                }
                else
                {
                    if (indexArrB > last)
                    {
                        arr[i] = arrC[indexArrA];
                        indexArrA++;
                    }
                    else
                    {
                        if (arrC[indexArrA] > arrC[indexArrB])
                        {
                            arr[i] = arrC[indexArrB];
                            indexArrB++;
                        }
                        else
                        {
                            arr[i] = arrC[indexArrA];
                            indexArrA++;
                        }
                        
                    }
                }
            }
           
            return;
        }

      
    }
}
