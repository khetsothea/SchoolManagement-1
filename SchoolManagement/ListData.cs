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

        public void ListDepartment() {
            var department = db.Department.ToList();
            foreach (var row in department) {
                Console.WriteLine(row.DepartmentID + "   " + row.Name);
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
