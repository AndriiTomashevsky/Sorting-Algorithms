using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyLibrarySort
{
    public class SelectionSort<T>
    {
        IComparer<T> comparer;

        private SelectionSort(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

         public static void Sort(T[] list, IComparer<T> comparer)
         {
             SelectionSort<T> sort = new SelectionSort<T>(comparer);
             sort._SelectionSort(list);
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
             for (int sortedRangeEnd = 0; sortedRangeEnd < items.Length; sortedRangeEnd++)
             {
                 int nextIndex = FindIndexOfSmallestFromIndex(items, sortedRangeEnd);
                 Swap(items, sortedRangeEnd, nextIndex);
             }
         }
         private int FindIndexOfSmallestFromIndex(T[] items, int sortedRangeEnd)
         {
             T currentSmallest = items[sortedRangeEnd];
             int currentSmallestIndex = sortedRangeEnd;

             for (int i = sortedRangeEnd + 1; i < items.Length; i++)
             {
                 if (comparer.Compare(currentSmallest,items[i]) > 0)
                 {
                     currentSmallest = items[i];
                     currentSmallestIndex = i;
                 }
             }
             return currentSmallestIndex;
         } 
    }
}
