using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyLibrarySort
{
    public class BubbleSort<T>
    {
        // the comparer to use (our PropertyComparer in this case)
        IComparer<T> comparer;

        // used to tell if the sort should be ascending or descending
        bool isAscending;

        // private constructor, used only inside this class by the static Sort method
        private BubbleSort(T[] list, IComparer<T> comparer, ListSortDirection direction)
        {
            this.comparer = comparer;
            this.isAscending = (direction == ListSortDirection.Ascending);
        }

        // This is the method you actually call to do the sort
        public static void Sort(T[] list, IComparer<T> comparer, ListSortDirection direction)
        {
            BubbleSort<T> sort = new BubbleSort<T>(list, comparer, direction);
            sort._BubbleSort( list);//(array);
        }

        // This method is used internally to compare values.
        // it will check the order and return the inverse values
        // if you are sorting in descending order
        private int Compare(T x, T y)
        {
            if (isAscending)
                return comparer.Compare(x, y);
            else
                return comparer.Compare(y, x);
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

        private void _BubbleSort( T[] items)
        {
            bool swapped;
            int lenght = items.Length;

            do
            {
                swapped = false;

                for (int i = 1; i < lenght; i++)
                {
                    if (this.Compare(items[i - 1], items[i]) > 0)
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


