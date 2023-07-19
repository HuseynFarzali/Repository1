using Application_StudentDatabase.Services;
using System.ComponentModel.Design;

namespace Application_StudentDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int option;

            do
            {
                MenuService.ShowMenu();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("-------------------------------------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("-------------------------------------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("-------------------------------------------------------");
                }

                switch (option)
                {
                    case 1:
                        MenuService.MenuShowStudents();
                        break;
                    case 2:
                        MenuService.MenuAddStudent();
                        break;
                    case 3:
                        MenuService.MenuUpdateStudent();
                        break;
                    case 4:
                        MenuService.MenuRemoveStudent();
                        break;
                    case 5:
                        MenuService.MenuFindStudentByName();
                        break;
                    case 0:
                        Console.WriteLine("Bye");
                        break;

                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } 
            while (option != 0);
        }
    }
}