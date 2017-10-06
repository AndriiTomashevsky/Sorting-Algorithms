using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarySort
{
    public class BubbleSort<T>
    {
        // the comparer to use (our PropertyComparer in this case)
        IComparer<T> comparer;

        // the list to sort
        //private T[] list;

        //// a buffer of the same size of the list to work
        //private T[] buffer;

        // used to tell if the sort should be ascending or descending
        bool isAscending;

        // private constructor, used only inside this class by the static Sort method
        private BubbleSort(T[] list, IComparer<T> comparer, ListSortDirection direction)
        {
            //this.list = list;
            //this.buffer = new T[list.Length];
            this.comparer = comparer;
            this.isAscending = (direction == ListSortDirection.Ascending);
        }

        // This is the method you actually call to do the sort
        public static void Sort(T[] list, IComparer<T> comparer, ListSortDirection direction)
        {
            BubbleSort<T> sort = new BubbleSort<T>(list, comparer, direction);
            //T[] array = new T[list.Count];
            //list.CopyTo(array, 0);
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

        // the recursive part to "divide and conquer"
        //private void _MergeSort(int firstIndex, int lastIndex)//(T[] array)
        //{
        //    int lastRelativeIndex = lastIndex - firstIndex;

        //    if (lastRelativeIndex < 1)
        //        return;

        //    int middle = (lastRelativeIndex / 2) + firstIndex;
        //    int postMiddle = middle + 1;

        //    _MergeSort(firstIndex, middle);
        //    _MergeSort(postMiddle, lastIndex);

        //    Merge(firstIndex, middle, postMiddle, lastIndex);
        //}

        //private void _MergeSort(T[] array)
        //{
        //    if (array.Length <= 1)
        //    {
        //        return;
        //    }

        //    int leftSize = array.Length / 2;
        //    int rightSize = array.Length - leftSize;
        //    T[] left = new T[leftSize];
        //    T[] right = new T[rightSize];

        //    Array.Copy(array, 0, left, 0, leftSize);
        //    Array.Copy(array, leftSize, right, 0, rightSize);

        //    Merge(array, left, right);
        //}

        // the actual sort
        //private void Merge(int leftStart, int leftEnd, int rightStart, int rightEnd)
        //{
        //    int bufferIndex = leftStart;
        //    int leftIndex = leftStart;
        //    int rightIndex = rightStart;

        //    // copy to the items we can to the buffer in the right order

        //    while (leftIndex <= leftEnd && rightIndex <= rightEnd)
        //    {
        //        if (Compare(list[leftIndex], list[rightIndex]) > 0)
        //            buffer[bufferIndex++] = list[rightIndex++];
        //        else
        //            buffer[bufferIndex++] = list[leftIndex++];
        //    }

        //    // copy the rest of the items to the buffer

        //    for (int i = leftIndex; i <= leftEnd; i++)
        //        buffer[bufferIndex++] = list[i];

        //    for (int i = rightIndex; i <= rightEnd; i++)
        //        buffer[bufferIndex++] = list[i];

        //    // copy the buffer back to the list

        //    for (int i = leftStart; i <= rightEnd; i++)
        //        list[i] = buffer[i];
        //}

        //private void Merge(T[] items, T[] left, T[] right)
        //{
        //    int leftIndex = 0;
        //    int rightIndex = 0;
        //    int targetIndex = 0;
        //    int remaining = left.Length + right.Length; // общая длинна правой и левой части сортируемого массива

        //    while (remaining > 0)
        //    {
        //        if (leftIndex >= left.Length)
        //        {
        //            items[targetIndex] = right[rightIndex++];
        //        }

        //        else if (rightIndex >= right.Length)
        //        {
        //            items[targetIndex] = left[leftIndex++];
        //        }

        //        else if (comparer.Compare(left[leftIndex],right[rightIndex]) < 0)
        //        {
        //            items[targetIndex] = left[leftIndex++];
        //        }

        //        else
        //        {
        //            items[targetIndex] = right[rightIndex++];
        //        }

        //        targetIndex++;
        //        remaining--;
        //    }
        private void Swap(T[] items, int left, int right)
        {
            if (left != right)
            {
                T temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        // Метод реализует сортировку пузырьком 

        private void _BubbleSort( T[] items)
        {
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < items.Length; i++)
                {
                    if (this.Compare(items[i - 1], items[i]) > 0)
                    {
                        Swap(items, i - 1, i);

                        swapped = true;
                    }
                }
            }
            while (swapped != false);
        }
    }
}


