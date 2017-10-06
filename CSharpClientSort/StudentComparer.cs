using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpClientSort
{
    class StudentComparer : IComparer<Student>
    {
        bool isNameThenAge;

        public StudentComparer(SortCriteria SortBy)
        {
            isNameThenAge = (SortCriteria.NameThenAge == SortBy);
        }

        public int Compare(Student x, Student y)
        {
            CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();
            int result = comparer.Compare(x.Name, y.Name);

            if (isNameThenAge)
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
