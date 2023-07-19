using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application_StudentDatabase.Models;
using Application_StudentDatabase.Services;

namespace Application_StudentDatabase.Services
{
    public class MenuService
    {
        private static StudentService studentService = new();

        public static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Show students");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Remove student");
            Console.WriteLine("5. Find student by name");
            Console.WriteLine("0. Exit");
        }

        public static void MenuShowStudents()
        {
            var students = studentService.GetStudents();

            if (students.DefaultIfEmpty() == default(StudentService))
            {
                Console.WriteLine("There is no any student in the database.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} {student.Name} {student.Surname} -- {student.Grade}");
            }
        }

        public static void MenuAddStudent()
        {
            try
            {
                Console.Write("Enter the student name: ");
                string name = Console.ReadLine();

                Console.Write("Enter the student surname: ");
                string surname = Console.ReadLine();

                Console.Write("Enter the student grade: ");
                decimal grade = decimal.Parse(Console.ReadLine());
            }
            catch (FormatException fExc)
            {
                Console.WriteLine($"{typeof(FormatException).Name}: {fExc.Message} -> (Be sure to enter valid numerical decimal for grade option.)");
            }
        }

        public static void MenuUpdateStudent()
        {
            try
            {
                Console.Write("Enter the student ID to be updated: ");
                int id = int.Parse(Console.ReadLine());

                Student? student = studentService.FindStudent(id);

                if (student == null) throw new ArgumentException("There is no any matching student for the given ID value.");

                Console.Write("Enter the new student name: ");
                string name = Console.ReadLine();

                Console.Write("Enter the new student surname: ");
                string surname = Console.ReadLine();

                Console.Write("Enter the new student grade: ");
                decimal grade = decimal.Parse(Console.ReadLine());

                student.Name = name;
                student.Surname = surname;
                student.Grade = grade;
            }

            catch (FormatException fExc)
            {
                Console.WriteLine($"{typeof(FormatException).Name}: {fExc.Message} -> (Be sure to enter valid numerical decimal for grade option.)");
            }
        }

        public static void MenuRemoveStudent()
        {
            try
            {
                Console.Write("Enter the student's ID: ");
                int id = int.Parse(Console.ReadLine());

                studentService.RemoveStudent(id);

                Console.WriteLine("Deleted student successfully!");
            }
            catch (FormatException fExc)
            {
                Console.WriteLine($"{typeof(FormatException).Name}: {fExc.Message} -> (Be sure to enter valid integer value for ID option.)");
            }
        }

        public static void MenuFindStudentByName()
        {
            Console.Write("Enter the student name to be searched: ");
            string searchingName = Console.ReadLine();

            var matchingStudents =
                from student in studentService.GetStudents()
                where student.Name == searchingName
                select student;

            if (matchingStudents.Count() > 0 )
            {
                Console.WriteLine("Found student(s):");
                foreach (var student in matchingStudents)
                {
                    Console.WriteLine($"{student.Id} {student.Name} {student.Surname} -- {student.Grade}");
                }
            }
            else Console.WriteLine("No any student found by the given name.");
        }
    }
}
