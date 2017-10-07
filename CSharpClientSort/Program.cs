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

            StudentComparer comparer = new StudentComparer(SortCriteria.NameThenAge);

            MergeSort<Student>.Sort(array, comparer, ListSortDirection.Ascending);
            //BubbleSort<Student>.Sort(array, comparer, ListSortDirection.Ascending);
            //InsertionSort<Student>.Sort(array, comparer, ListSortDirection.Ascending);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
