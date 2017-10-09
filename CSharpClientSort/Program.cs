using System;
using System.ComponentModel;
using MyLibrarySort;

namespace CSharpClientSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] array = new Student[] 
            { 
                new Student("Constantin", 18),
                new Student("Andre", 32),   
                new Student("Alex", 19),
                new Student("Boris", 19),
                new Student("boris", 18),
                new Student("Ivan", 18),
            };



            StudentComparer comparer = new StudentComparer(SortCriteria.AgeThenName);

            MergeSort<Student>.Sort(array, comparer, ListSortDirection.Descending);

            //BubbleSort<Student>.Sort(array, comparer, ListSortDirection.Descending);

            //QuickSort<Student>.Sort(array, comparer, ListSortDirection.Ascending);

            //SelectionSort<Student>.Sort(array, comparer, ListSortDirection.Ascending);

            //InsertionSort<Student>.Sort(array, comparer, ListSortDirection.Ascending);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 30));

            //----------------------------------------------------------------------------

            Student[] _array = new Student[] 
            { 
                new Student("constantin", 18),
                new Student("andre", 32),   
                new Student("alex", 19),
            };

            Student[] mergingArrays = MergingTwoCollections<Student>.Merge(array, _array, comparer, ListSortDirection.Descending);

            foreach (var item in mergingArrays)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
