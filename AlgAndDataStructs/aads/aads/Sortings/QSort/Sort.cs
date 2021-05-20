using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aads.Sortings.QSort
{
    public class Sort
    {

        public Sort(int[] arr)
        {
            DoSort(arr, 0, arr.Length - 1);
        }

        private void DoSort(int[] arr, int first, int last)
        {
            if (first >= last)
            {
                return;
            }

            if (arr.Length == 0)
            {
                return;
            }

            // Создаём опорный элемент.
            int pivot = (arr[first] + arr[last]) / 2;

            // Индекс крайнего от начала элемента, такой что, все до него меньше опорного.
            int indexLessPivot = first;

            // Индекс крайнего от конца элемента, такой что, все до него больше опорного.
            int indexLargePivot = last;


            // Если крайние элементы еще не пересеклись, то считаем,
            // что еще не достигли точки пересечния
            // половинок массива, которые меньше и больше опорного.
            while (indexLessPivot <= indexLargePivot)
            {
                // Ищем крайний от начала элемент, такой что, все до него меньше опорного.
                while (arr[indexLessPivot] < pivot)
                {
                    indexLessPivot++;
                }

                // Ищем крайнего от конца элемент, такой что, все до него больше опорного.
                while (arr[indexLargePivot] > pivot)
                {
                    indexLargePivot--;
                }

                // Если крайние элементы еще не пересеклись, то считаем,
                // что еще не достигли точки пересечния
                // половинок массива, которые меньше и больше опорного.
                // Меняем местами элементы,
                // больший элемент в большую половину,
                // меньший элемент в меньшую половину.
                if (indexLessPivot <= indexLargePivot)
                {
                    int temp = arr[indexLessPivot];
                    arr[indexLessPivot] = arr[indexLargePivot];
                    arr[indexLargePivot] = temp;

                    indexLessPivot++;
                    indexLargePivot--;
                }
            }

            // Дробим меньшую половину.
            if (first < indexLargePivot)
            {
                DoSort(arr, first, indexLargePivot);
            }

            // Дробим большую половину.
            if (last > indexLessPivot)
            {
                DoSort(arr, indexLessPivot, last);
            }
        }
    }
}
