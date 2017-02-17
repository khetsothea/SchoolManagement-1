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
        public static ListData listData = new ListData();
        static void Main(string[] args)
        {
            string[] menu = {
                "*****************************************************************",
                "1. Create A New Instructor and Assign Instructor to The Course",
                "2. Create A New Student and Enroll to The Course",
                "3. Create A New Course and Assign to A Department",
                "4. View All Student Grades in A Course",
                "5. View All Instructors and Display the Course They Teach",
                "6. Delete A Student",
                "7. Delete A Course",
                "8, Ability to Update a Students Record",
                "9. Change Course an Instructor Is Teaching",
                "0. Exit The System",
                "*****************************************************************",
                "Please Choose an Option",
                "*****************************************************************"
            };
            for (var i = 0; i < menu.Length; i++) { Console.WriteLine(menu[i]); };
            Response();
        }

        public static void Response()
        {
            int input = Int16.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Q1();
                    break;
                case 2:
                    Q2();
                    break;
                case 3:
                    Q3();
                    break;
                case 4:
                    Q4();
                    break;

            }
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
            Response();
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

        //Create a new Student and enroll to the Course
        public static void Q2()
        {
            string menu1 = "Please Enter New Student First Name";
            string stuFirst = AskInput(menu1);
            string menu2 = "Please Enter New Student Last Name";
            string stuLast = AskInput(menu2);
            var newStuent = new Person();
            newStuent.FirstName = stuFirst;
            newStuent.LastName = stuLast;
            db.Person.Add(newStuent);
            db.SaveChanges();
            listData.ListCourse();
            string menu3 = "Please Choose the Course ID You want to Enroll";
            string courseID = AskInput(menu3);
            var person = db.Person.Where(p => p.FirstName == stuFirst & p.LastName == stuLast)
                             .OrderByDescending(p => p.PersonID)
                             .First();
            var studentEnroll = new StudentGrade();
            studentEnroll.CourseID = short.Parse(courseID);
            studentEnroll.StudentID = person.PersonID;
            db.StudentGrade.Add(studentEnroll);
            db.SaveChanges();
            Success();
        }

        //Create a new Course and assign to a Department
        public static void Q3()
        {
            string menu1 = "Please Enter New CourseID (4 Digits)";
            string courseID = AskInput(menu1);
            string menu2 = "Please Enter New Course Title";
            string courseTitle = AskInput(menu2);
            string menu3 = "Please Enter Course Credit";
            string courseCredit = AskInput(menu3);
            listData.ListDepartment();
            string menu4 = "Please Choose DepartmentID";
            string departmentID = AskInput(menu4);
            var newCourse = new Course();
            newCourse.CourseID = short.Parse(courseID);
            newCourse.Title = courseTitle;
            newCourse.Credits = byte.Parse(courseCredit);
            newCourse.DepartmentID = byte.Parse(departmentID);
            db.Course.Add(newCourse);
            db.SaveChanges();
            listData.ListCourse();
            Success();
        }
        //View all Student grades in a Course
        public static void Q4()
        {
            listData.ListCourse();
            string menu1 = "Please Enter CourseID (4 Digits)";
            short courseID = short.Parse(AskInput(menu1));
            listData.ListStudentGradeByCourse(courseID);
            Success();
        }
        //View all  Instructors and display the course they teach
        //Delete a Student
        //Delete a Course
        //Ability to Update a Students  record
        //Change Course a Instructor is teaching
    }
}
