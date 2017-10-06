using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpClientSort
{
    class StudentComparer : IComparer<Student>
    {
        public SortCriteria SortBy = SortCriteria.NameThenAge;

        public int Compare(Student x, Student y)
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
