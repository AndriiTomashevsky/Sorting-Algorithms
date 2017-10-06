using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CSharpClientSort
{
    public class Student
    {
        int age;
        string name;

        public Student(string name, int age)
        {
            this.age = age;
            this.name = name;
        }
        public int Age
        {
            get { return age; }
        }
        public string Name
        {
            get { return name; }
        }
        public override string ToString()
        {
            return string.Format("Student: {0}, Age: {1}", Name, Age);
        }
    }
}
