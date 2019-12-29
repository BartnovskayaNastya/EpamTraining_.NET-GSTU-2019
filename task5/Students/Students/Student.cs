using System;
using System.Collections.Generic;

namespace Students
{
    public class Student : IComparable
    {
        private string name;
        private string testName;
        private int mark;

        /// <summary>
        /// Property for getting and setting name for student 
        /// </summary>
        public string Name 
        {
            get 
            {
                return name;
            } 
            set
            {

                if(value.Length < 1)
                {
                    throw new Exception("You need to input some name");
                }
                else
                {
                    name = value;
                }
             
            }
        }


        /// <summary>
        ///  Property for getting and setting name for test
        /// </summary>
        public string TestName 
        {
            get
            {
                return testName;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("You need to input some name");
                }

                testName = value;
            }
        }

        /// <summary>
        /// Date of test for student
        /// </summary>
        public DateTime dateTest;


        /// <summary>
        /// Mark of student's test
        /// </summary>
        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new Exception("You need to input mark between 1 and 10");
                }
                else
                {
                    mark = value;
                }

               
            }
        }

        /// <summary>
        /// Constructor for class Student
        /// </summary>
        /// <param name="name">Name of student</param>
        /// <param name="testName">Name of test for student</param>
        /// <param name="dateTest">Date of test for student</param>
        /// <param name="mark">Mark of student's test<param>
        public Student(string name, string testName, DateTime dateTest, int mark)
        {
            Name = name;
            TestName = testName;
            this.dateTest = Convert.ToDateTime(dateTest);
            Mark = mark;

        }

      

        /// <summary>
        /// Override method for object comparisons
        /// </summary>
        /// <param name="obj">object for comparisons</param>
        /// <returns>true if they are equals, false if they are not</returns>
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

        /// <summary>
        /// Override method for getting hashCode
        /// </summary>
        /// <returns>Hash code</returns>
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

        /// <summary>
        /// Method for comparing students by marks
        /// </summary>
        /// <param name="obj">Student for comparing</param>
        /// <returns>Result of comparing</returns>
        public virtual int CompareTo(object obj)
        {
            Student student = obj as Student;
            if (student != null)
            {
                return mark.CompareTo(student.mark);
            }
            else
            {
                throw new Exception("Error.");
            }
        }
    }
}
