using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement
{
    public class ListData
    {
        School db;
        public ListData()
        {
            db = new School();
        }

        public void ListCourse()
        {
            var courseTable = db.Course.ToList();
            foreach (var row in courseTable)
            {
                Console.WriteLine(row.CourseID + "   " + row.Title + "   ");
            }
        }

        public void ListDepartment()
        {
            var department = db.Department.ToList();
            foreach (var row in department)
            {
                Console.WriteLine(row.DepartmentID + "   " + row.Name);
            }
        }

        public void ListStudentGradeByCourse(short id)
        {
            var course = db.Course.ToList();
            var studentGrade = db.StudentGrade.ToList();
            var query = from c in course
                        join sg in studentGrade
                        on c.CourseID equals sg.CourseID
                        where c.CourseID == id
                        select c.CourseID + "   " + c.Title + "   " + sg.StudentID + "   " + sg.Grade;
            Console.WriteLine("CourseID     Title     StudentID     Grade");
            if (query.Count() == 0)
            {
                Console.WriteLine("Sorry,there is no record in this course.");
            }
            else
            {
                foreach (var row in query)
                {
                    Console.WriteLine(row.ToString());
                }
            }
        }

        //public void ListPerson(string firstName, string lastName)
        //{
        //    var personTable = db.Person.Where(p => p.FirstName == firstName && p.LastName == lastName);
        //    foreach (var row in personTable)
        //    {
        //        Console.WriteLine(row.PersonID + "   " + row.FirstName + "   " + row.LastName);
        //    }
        //}
    }
}
