using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application_StudentDatabase.Models;

namespace Application_StudentDatabase.Services
{
    public class StudentService
    {
        private List<Student> students;

        public StudentService()
        {
            students = new List<Student>();
        }
        
        public List<Student> GetStudents()
        {
            return students;
        }
        public void AddStudent(string name, string surname, decimal grade)
        {
            if (name == null) throw new ArgumentNullException("Student Name");
            if (surname == null) throw new ArgumentNullException("Student Surname");
            if (grade < 0) throw new ArgumentException("Given grade value cannot be negative.");

            Student student = new Student(name, surname, grade);
            students.Add(student);
        }
        public void RemoveStudent(int id)
        {
            if (id < 0) throw new ArgumentException("Argument ID value cannot be negative.");

            Student existingStudent = students.FirstOrDefault(std => std.Id == id);

            if (existingStudent == default(Student)) throw new KeyNotFoundException("There is no any matching student for the given ID value.");

            students.Remove(existingStudent);
        }

        public Student? FindStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id) return student;
            }

            return default(Student);
        }
    }
}
