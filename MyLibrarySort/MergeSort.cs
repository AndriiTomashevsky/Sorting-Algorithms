using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyLibrarySort
{
    public class MergeSort<T>
    {
        IComparer<T> comparer;

        private MergeSort(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public static void Sort(T[] array, IComparer<T> comparer)
        {
            MergeSort<T> sort = new MergeSort<T>(comparer);
            sort._MegreSort(array);
        }

        private void _MegreSort(T[] items)
        {

            if (items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            T[] left = new T[leftSize];
            T[] right = new T[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);

            _MegreSort(left);
            _MegreSort(right);

            Merge(items, left, right);

        }
        private void Merge(T[] items, T[] left, T[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length; 

            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }

                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }

                else if (comparer.Compare(left[leftIndex],right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }

                else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }
    }
}
