using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_StudentDatabase.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Grade { get; set; }

        private static int counter = 1;

        public Student(string name, string surname, decimal grade)
        {
            this.Name = name;
            this.Surname = surname;
            this.Grade = grade;

            this.Id = counter;
            counter++;
        }
    }
}
