using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Management System");
            var crud = new CRUD();
            crud.Introduce();
        }

        public static void Option()
        {
            Console.WriteLine("\n-----OPTION-----");

            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Read Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");
        }

        public static void ViewAllOrReadOne()
        {
            Console.WriteLine("1. List All the Employees");
            Console.WriteLine("2. Find Employee by ID");
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
    }

    public class CRUD
    {
        private List<Employee> employees = new List<Employee>();

        public void Introduce()
        {
            while (true)
            {
                Program.Option();

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int Choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (Choice)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Delete();
                        break;
                    case 5:
                        Console.WriteLine("----------EXIT----------");
                        return;
                    default:
                        Console.WriteLine("Choose from 1 to 5....");
                        break;
                }
            }
        }

        public void Add()
        {
            Console.WriteLine("\n----------Add Employee----------");

            Console.Write("Enter your ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Position: ");
            string position = Console.ReadLine();

            Console.Write("Enter your Salary: ");
            if (double.TryParse(Console.ReadLine(), out double salary))
            {
                if (!employees.Any(e => e.Id == id))
                {
                    employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
                    Console.WriteLine("The Employee Added Successfully");
                }
                else
                {
                    Console.WriteLine("The ID is already exists...");
                }
            }
            else
            {
                Console.WriteLine("Invalid salary. Please enter a valid number.");
            }
        }

        public void Read()
        {
            Console.WriteLine("\n----------Read Employee---------- ");

            Program.ViewAllOrReadOne();

            Console.Write("Enter your Choice: ");
            if (!int.TryParse(Console.ReadLine(), out int Choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            if (Choice == 1)
            {
                Console.WriteLine("\n----------List Of Employees----------");
                Console.WriteLine("\tID \t\tNAME \t\tPOSITION \tSALARY");

                foreach (var em in employees)
                {
                    Console.WriteLine($"\t{em.Id}. \t{em.Name} \t{em.Position} \t\t{em.Salary}");
                }
            }
            else if (Choice == 2)
            {
                Console.Write("Search your ID: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Please enter a valid integer.");
                    return;
                }

                var employee = employees.FirstOrDefault(e => e.Id == id);

                if (employee != null)
                {
                    Console.WriteLine("----------Employee----------");
                    Console.WriteLine("\tID \t\tNAME \t\tPOSITION \tSALARY");
                    Console.WriteLine($"\t{employee.Id} \t{employee.Name} \t{employee.Position} \t\t{employee.Salary}");
                }
                else
                {
                    Console.WriteLine("Invalid ID...");
                }
            }
        }

        public void Update()
        {
            Console.WriteLine("\n-----------Update---------- ");

            Console.Write("Enter your ID to Update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                Console.Write("Enter the new Name: ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName)) employee.Name = newName;

                Console.Write("Enter the new Position: ");
                string newPosition = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPosition)) employee.Position = newPosition;

                Console.Write("Enter the new Salary: ");
                if (double.TryParse(Console.ReadLine(), out double newSalary))
                {
                    employee.Salary = newSalary;
                    Console.WriteLine("The Employee is Updated Successfully.....");
                }
                else
                {
                    Console.WriteLine("Invalid salary. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("ID is invalid....");
            }
        }

        public void Delete()
        {
            Console.WriteLine("\n----------DELETE---------- ");

            Console.Write("Enter your ID to Delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("The Employee is Deleted Successfully......");
            }
            else
            {
                Console.WriteLine("ID is invalid...");
            }
        }
    }
}
