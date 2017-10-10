using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarySort
{
    public class InsertionSort<T>
    {
        IComparer<T> comparer;

        private InsertionSort(T[] array, IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public static void Sort(T[] array, IComparer<T> comparer)
        {
            InsertionSort<T> sort = new InsertionSort<T>(array, comparer);
            sort._InsertionSort(array);
        }

        private void _InsertionSort(T[] items)
        {
            T key;
            int j;

            for (int i = 1; i < items.Length; i++)
            {
                key = items[i];
                j = i - 1;
                while (j >= 0 && comparer.Compare(key, items[j]) < 0)
                {
                    items[j + 1] = items[j];
                    j--;
                }
                items[j + 1] = key;
            }
        }
    }
}
