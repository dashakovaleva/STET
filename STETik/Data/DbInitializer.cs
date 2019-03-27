using STETik.Models;
using System;
using System.Linq;

namespace STETik.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Ковалева",LastName="Дарья",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Иванов",LastName="Петя",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Сидоров",LastName="Коля",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Васькин",LastName="Вася",EnrollmentDate=DateTime.Parse("2002-09-01")},
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Химия",Credits=3},
            new Course{CourseID=4022,Title="Микроэкономика",Credits=3},
            new Course{CourseID=4041,Title="Макроэкономика",Credits=3},
            new Course{CourseID=1045,Title="Математика",Credits=4},
            new Course{CourseID=3141,Title="Тригонометрия",Credits=4},
            new Course{CourseID=2042,Title="Литература",Credits=4}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}