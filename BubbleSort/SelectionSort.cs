using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyLibrarySort
{
    public class SelectionSort<T>
    {
        IComparer<T> comparer;
        bool isAscending;

        private SelectionSort(T[] list, IComparer<T> comparer, ListSortDirection direction)
        {
            this.comparer = comparer;
            this.isAscending = (direction == ListSortDirection.Ascending);
        }

         public static void Sort(T[] list, IComparer<T> comparer, ListSortDirection direction)
         {
             SelectionSort<T> sort = new SelectionSort<T>(list, comparer, direction);
             sort._SelectionSort(list);
         }

         private int Compare(T x, T y)
         {
             if (isAscending)
                 return comparer.Compare(x, y);
             else
                 return -1 * comparer.Compare(x, y);
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
         private void _SelectionSort(T[] items)
         {
             int sortedRangeEnd = 0;

             while (sortedRangeEnd < items.Length)
             {
                 int nextIndex = FindIndexOfSmallestFromIndex(items, sortedRangeEnd);
                 Swap(items, sortedRangeEnd, nextIndex);
                 sortedRangeEnd++;
             }
         }
         private int FindIndexOfSmallestFromIndex(T[] items, int sortedRangeEnd)
         {
             T currentSmallest = items[sortedRangeEnd];
             int currentSmallestIndex = sortedRangeEnd;

             for (int i = sortedRangeEnd + 1; i < items.Length; i++)
             {
                 if (Compare(currentSmallest,items[i]) > 0)
                 {
                     currentSmallest = items[i];
                     currentSmallestIndex = i;
                 }
             }

             return currentSmallestIndex;
         } 
    }
}
