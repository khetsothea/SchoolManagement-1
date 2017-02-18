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
        }

        public void ListCourse()
        {
            db = new School();
            var courseTable = db.Course.ToList();
            foreach (var row in courseTable)
            {
                Console.WriteLine(row.CourseID + "   " + row.Title + "   ");
            }
        }

        public void ListInstructor()
        {
            db = new School();
            var instructor = db.OfficeAssignment.ToList();
            var person = db.Person.ToList();
            var query = from i in instructor
                        join p in person
                        on i.InstructorID equals p.PersonID
                        select p.PersonID + "   " + p.FirstName + "   " + p.LastName;
            IterateQuery(query);
        }

        public void ListStudent()
        {
            db = new School();
            var student = db.StudentGrade.ToList();
            var person = db.Person.ToList();
            var query = from p in person
                        join s in student
                        on p.PersonID equals s.StudentID
                        select s.StudentID + "     " + p.FirstName + "     " + p.LastName;
            IterateQuery(query.Distinct());
        }

        public void ListStudentGradeById(int id)
        {
            db = new School();
            var student = db.StudentGrade.ToList();
            var person = db.Person.ToList();
            var query = from s in student
                        where s.StudentID == id
                        select s.EnrollmentID + "     " + s.CourseID + "     " + s.StudentID + "     " + s.Grade;
            Console.WriteLine("EnrollmentID     CourseID        StudentID       Grade");
            IterateQuery(query);
        }

        public void ListDepartment()
        {
            db = new School();
            var department = db.Department.ToList();
            foreach (var row in department)
            {
                Console.WriteLine(row.DepartmentID + "   " + row.Name);
            }
        }

        public void ListStudentGradeByCourse(short id)
        {
            db = new School();
            var course = db.Course.ToList();
            var studentGrade = db.StudentGrade.ToList();
            var query = from c in course
                        join sg in studentGrade
                        on c.CourseID equals sg.CourseID
                        where c.CourseID == id
                        select c.CourseID + "       " + c.Title + "        " + sg.StudentID + "         " + sg.Grade;
            Console.WriteLine("CourseID     Title     StudentID     Grade");
            if (query == null)
            {
                Console.WriteLine("Sorry,there is no record in this course.");
            }
            else
            {
                IterateQuery(query);
            }
        }

        public void ListCourseByInstructor(short id)
        {
            db = new School();
            var course = db.Course.ToList();
            var courseInstructor = db.CourseInstructor.ToList();
            var person = db.Person.ToList();
            var query = from c in course
                        join ci in courseInstructor
                        on c.CourseID equals ci.CourseID
                        join p in person
                        on ci.PersonID equals p.PersonID
                        where p.PersonID == id
                        select p.PersonID + "     " + p.FirstName + "     " + p.LastName + "     " + c.CourseID + "     " + c.Title + "     ";
            Console.WriteLine("PersonID     FirstName     LastName     CourseID     Title");
            if (query.Count() == 0)
            {
                Console.WriteLine("Sorry,there is no record in this course.");
            }
            else
            {
                IterateQuery(query);
            }
        }

        public void IterateQuery(IEnumerable<string> query)
        {
            foreach (string row in query)
            {
                Console.WriteLine(row.ToString());
            }
        }
    }
}
