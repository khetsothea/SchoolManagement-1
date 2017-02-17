using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement
{
    class Program
    {

        public static School db = new School();
        static void Main(string[] args)
        {
            //using (var db = new School())
            //{
            string[] menu = {
                "*****************************************************************",
                "1.Create a new Instructor and assign instructor to the Course",
                "2.Create a new Student and enroll to the Course",
                "3.Create a new Course and assign to a Department",
                "4.View all Student grades in a Course",
                "5.View all  Instructors and display the course they teach",
                "6.Delete a Student",
                "7.Delete a Course",
                "8,Ability to Update a Students  record",
                "9.Change Course a Instructor is teaching",
                "*****************************************************************",
                "Please Choose an Option",
            };
            for (var i = 0; i < menu.Length; i++) { Console.WriteLine(menu[i]); };
            int input = Int16.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Q1();
                    break;
                case 2:

                    break;
            }


            //Create a new Student and enroll to the Course

            //Create a new Course and assign to a Department
            //View all Student grades in a Course
            //View all  Instructors and display the course they teach
            //Delete a Student
            //Delete a Course
            //Ability to Update a Students  record
            //Change Course a Instructor is teaching
            //}
        }

        public static string AskInput(string message)
        {
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            } while (input.Length <= 0);
            return input;
        }

        public static void Success()
        {
            Console.WriteLine("Database Updated successfully");
        }

        //Create a new Instructor and assign instructor to the Course
        public static void Q1()
        {
            string menu1 = "Please enter new instructor First Name";
            string instruFirstName = AskInput(menu1);
            string menu2 = "Please enter new instructor Last Name";
            string instruLastName = AskInput(menu2);
            var newInstructor = new Person();
            newInstructor.FirstName = instruFirstName;
            newInstructor.LastName = instruLastName;
            db.Person.Add(newInstructor);
            string menu6 = "Please Enter 4 Digits Course ID";
            string courseID = AskInput(menu6);
            string menu3 = "Please Enter Course Title";
            string courseTitle = AskInput(menu3);
            string menu4 = "Please Enter Course Credits";
            string courseCredit = AskInput(menu4);
            string menu5 = "Please Enter Department ID";
            string courseDepartment = AskInput(menu5);
            var newCourse = new Course();
            newCourse.CourseID = short.Parse(courseID);
            newCourse.Title = courseTitle;
            newCourse.Credits = byte.Parse(courseCredit);
            newCourse.DepartmentID = byte.Parse(courseDepartment);
            db.Course.Add(newCourse);
            db.SaveChanges();
            Success();
        }
    }
}
