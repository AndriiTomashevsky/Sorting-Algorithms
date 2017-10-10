using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyLibrarySort
{
    public class QuickSort<T>
    {
        IComparer<T> comparer;

        private QuickSort(T[] list, IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

         public static void Sort(T[] list, IComparer<T> comparer)
         {
             QuickSort<T> sort = new QuickSort<T>(list, comparer);
             sort._QuickSort(list);
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
         private void _QuickSort(T[] items)
         {
             quicksort(items, 0, items.Length - 1);
         }
         private void quicksort(T[] items, int left, int right)
         {
             Random _pivotRng = new Random();

             if (left < right)
             {
                 int pivotIndex = _pivotRng.Next(left, right);

                 int newPivot = partition(items, left, right, pivotIndex);
                 quicksort(items, left, newPivot - 1);
                 quicksort(items, newPivot + 1, right);
             }
         }
         private int partition(T[] items, int left, int right, int pivotIndex)
         {
             T pivotValue = items[pivotIndex];

             Swap(items, pivotIndex, right);

             int storeIndex = left;

             for (int i = left; i < right; i++)
             {
                 if (comparer.Compare(items[i],pivotValue) < 0)
                 {
                     Swap(items, i, storeIndex);
                     storeIndex += 1;
                 }
             }

             Swap(items, storeIndex, right);
             return storeIndex;
         }
    }
}
