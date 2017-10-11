using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrarySort
{
    public class MergingTwoCollections<T>
    {
        IComparer<T> comparer;

        private MergingTwoCollections(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public static T[] Merge(T[] array, T[] _array, IComparer<T> comparer)
        {
            MergingTwoCollections<T> sort = new MergingTwoCollections<T>(comparer);
            MergeSort<T>.Sort(array, comparer);
            MergeSort<T>.Sort(_array, comparer);
            return sort._MergingTwoCollections(array, _array);
        }

        private T[] _MergingTwoCollections(T[] items, T[] _items)
        {
            int i = 0, j = 0, k = 0;
            T[] mergingItems = new T[items.Length + _items.Length];

            while (i < items.Length && j < _items.Length)
            {
                if (comparer.Compare(items[i], _items[j]) < 0)
                    mergingItems[k++] = items[i++];
                else
                    mergingItems[k++] = _items[j++];
            }
            while (i < items.Length)
            {
                mergingItems[k++] = items[i++];
            }
            while (j < _items.Length)
            {
                mergingItems[k++] = _items[j++];
            }
            return mergingItems;
        }

    }
}
