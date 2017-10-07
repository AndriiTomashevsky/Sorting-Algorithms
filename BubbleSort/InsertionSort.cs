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
        bool isAscending;

        private InsertionSort(T[] array, IComparer<T> comparer, ListSortDirection direction)
        {
            this.comparer = comparer;
            this.isAscending = (direction == ListSortDirection.Ascending);
        }

        public static void Sort(T[] array, IComparer<T> comparer, ListSortDirection direction)
        {
            InsertionSort<T> sort = new InsertionSort<T>(array, comparer, direction);
            sort._InsertionSort(array);
        }

        private int Compare(T x, T y)
        {
            if (isAscending)
                return comparer.Compare(x, y);
            else
                return -1 * comparer.Compare(x, y);
        }

        private void _InsertionSort(T[] items)
        {
            int sortedRangeEndIndex = 1;

            while (sortedRangeEndIndex < items.Length)
            {
                if (Compare(items[sortedRangeEndIndex], items[sortedRangeEndIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[sortedRangeEndIndex]);
                    Insert(items, insertIndex, sortedRangeEndIndex);
                }
                sortedRangeEndIndex++;
            }
        }
        private int FindInsertionIndex(T[] items, T valueToInsert)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (Compare(items[i], valueToInsert) > 0)
                    return i;
            }
            throw new InvalidOperationException("Index not found");
        }
        private void Insert(T[] items, int indexInsertingAt, int indexInsertingFrom)
        {
            T temp = items[indexInsertingAt];
            items[indexInsertingAt] = items[indexInsertingFrom];

            for (int current=indexInsertingFrom; current > indexInsertingAt; current--)
            {
                items[current] = items[current - 1];
            }

            items[indexInsertingAt + 1] = temp;
        }
    }
}
