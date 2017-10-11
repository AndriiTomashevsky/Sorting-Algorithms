using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyLibrarySort
{
    public class BubbleSort<T>
    {
        // the comparer to use (our PropertyComparer in this case)
        IComparer<T> comparer;

        // private constructor, used only inside this class by the static Sort method
        private BubbleSort(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        // This is the method you actually call to do the sort
        public static void Sort(T[] list, IComparer<T> comparer)
        {
            BubbleSort<T> sort = new BubbleSort<T>(comparer);
            sort._BubbleSort(list);
        }

        private void Swap(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        private void _BubbleSort(T[] items)
        {
            bool swapped;
            int lenght = items.Length;

            do
            {
                swapped = false;

                for (int i = 1; i < lenght; i++)
                {
                    if (comparer.Compare(items[i - 1], items[i]) > 0)
                    {
                        Swap(items, i - 1, i);

                        swapped = true;
                    }
                }
                lenght--;
            }
            while (swapped != false);
        }
    }
}


