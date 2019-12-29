using System;
using System.Collections.Generic;

namespace Students
{
    public class Student : IComparable<Student>
    {
        private string name;
        private string testName;
        private int mark;
        public string Name 
        {
            get 
            {
                return name;
            } 
            set
            {
                if(name.Length < 1)
                {
                    throw new Exception("You need to input some name");
                }

                name = value;
            }
        } 

        public string TestName 
        {
            get
            {
                return testName;
            }
            set
            {
                if (testName.Length < 1)
                {
                    throw new Exception("You need to input some name");
                }

                testName = value;
            }
        }

        public DateTime dateTest;
        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (mark < 1 || mark > 10)
                {
                    throw new Exception("You need to input mark between 1 and 10");
                }

                mark = value;
            }
        }

        public Student(string name, string testName, DateTime dateTest, int mark)
        {
            Name = name;
            TestName = testName;
            this.dateTest = dateTest;
            Mark = mark;

        }

        public int CompareTo(Student student)
        {
            if (student != null)
                return this.Mark.CompareTo(student.Mark);
            else
                throw new Exception("Impossible to compare this students");
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   name == student.name &&
                   testName == student.testName &&
                   mark == student.mark &&
                   Name == student.Name &&
                   TestName == student.TestName &&
                   dateTest == student.dateTest &&
                   Mark == student.Mark;
        }

        public override int GetHashCode()
        {
            var hashCode = -1560043343;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(testName);
            hashCode = hashCode * -1521134295 + mark.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TestName);
            hashCode = hashCode * -1521134295 + dateTest.GetHashCode();
            hashCode = hashCode * -1521134295 + Mark.GetHashCode();
            return hashCode;
        }
    }
}
