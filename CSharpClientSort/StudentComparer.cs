using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CSharpClientSort
{
    class StudentComparer : IComparer<Student>
    {
        SortCriteria SortBy;
        bool isAscending;

        public StudentComparer(SortCriteria SortBy, ListSortDirection direction)
        {
            this.SortBy = SortBy;
            this.isAscending = (direction == ListSortDirection.Ascending);
        }

        public int Compare(Student x, Student y)
        {
            if (isAscending)
                return _Compare(x, y);
            else
                return _Compare(y, x);
        }

        private int _Compare(Student x, Student y)
        {
            CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();
            int result = comparer.Compare(x.Name, y.Name);

            if (SortBy == SortCriteria.NameThenAge)
            {
                if (result != 0)
                    return result;
                else if (x.Age > y.Age)
                    return 1;
                else if (x.Age < y.Age)
                    return -1;
                else
                    return 0;
            }
            else
            {
                if (x.Age > y.Age)
                    return 1;
                else if (x.Age < y.Age)
                    return -1;
                else
                    return result;
            }
        }
    }
}
