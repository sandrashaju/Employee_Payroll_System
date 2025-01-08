using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeePayrollSystem
{
    // defining base/parent class
    public class BaseEmployee
    {
        // setting properties 
        public string Name { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }
        public int BasicPay { get; set; }
        public int Allowances { get; set; }
        public int Deductions { get; set; }


        // method to calculate salary
        public float CalculateNetSalary()
        {
            float Salary = BasicPay + Allowances - Deductions;
            return Salary;
        }


        // method to display employee details
        public void DisplayEmployeeList()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Role: {Role}, Basic Pay: {BasicPay}, Allowances: {Allowances}, Deductions: {Deductions}, Total Salary: {CalculateNetSalary()}");
        }

    }


    // defining derived class Manager which extends BaseEmployee class 
    public class Manager : BaseEmployee
    {
        // Assigning properties for Manager
        public Manager(string Name, int Id, string Role)
        {
            this.Name = Name;
            this.Id = Id;
            this.Role = Role;
            BasicPay = 50000;
            Allowances = 5000;
            Deductions = 1000; 
        }
    }


    // Defining derived class Developer
    public class Developer : BaseEmployee
    {
        // Assigning properties to Developer 
        public Developer(string Name, int Id, string Role)
        {
            this.Name = Name;
            this.Id = Id;
            this.Role = Role;
            BasicPay = 30000;
            Allowances = 2000;
            Deductions = 1000;
        }
    }


    // Defining derived class Intern
    public class Intern : BaseEmployee
    {
        // Assigning properties to Intern
        public Intern(string Name, int Id, string Role)
        {
            this.Name = Name;
            this.Id = Id;
            this.Role = Role;
            BasicPay = 10000;
            Allowances = 1000;
            Deductions = 0;
        }
    }



    // Main Class
    public class Program
    {
        static List<BaseEmployee> Employeeslist = new List<BaseEmployee>();  //creating a list of type BaseEmployee class to hold user enterd employee details.

        // Main method - Where execution begins
        static void Main(string[] args)
        {
            string choice;
            string option;
            
            do {
                Console.WriteLine("\nChoose Your Number To Perform Any Action \n\n    1 -- Add New Employee \n    2 -- Disaplay All Employee \n    3 -- Calculate Salary \n    4 -- Total Payroll\n");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEmployee(); // AddEmployee function invoked
                        break;
                    case "2":
                        DisplayEmployees(); // DisplayEmployee function invoked
                        break;
                    case "3":
                        CalculateSalary(); // CalculateSalary function invoked
                        break;
                    case "4":
                        CalculatePayroll(); // Calculatepayroll function invoked
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("\nDo you want to continue.? Press Y to continue or N to exit");
                option= Console.ReadLine().ToUpper();
            }
            while (option != "N");
        }


        // Definition of AddEmployee() function
        static void AddEmployee()
        {
            Console.Write("Employee Name: ");
            string Name = Console.ReadLine();
            Console.Write("Enter ID: ");
            int Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Role (MANAGER/DEVELOPER/INTERN): ");
            string Role = Console.ReadLine().ToUpper(); ;

            BaseEmployee employee = null;

            switch (Role)
            {
                case "MANAGER":
                    employee = new Manager(Name, Id, Role); // passing values to the class Manager
                    break;
                case "DEVELOPER":
                    employee = new Developer(Name, Id, Role); // passing values to the class Developer
                    break;
                case "INTERN":
                    employee = new Intern(Name, Id, Role); // passing values to the class Intern
                    break;
                default:
                    Console.WriteLine("Invalid role. Employee not added.");
                    return;
            }

            Employeeslist.Add(employee); //adding the entered employee details to Employeelist
            Console.WriteLine("\n** Employee added successfully. **\n");
        }


        // Definition of DisplayEmployees() Function
        static void DisplayEmployees()
        {
            if (Employeeslist.Count == 0)
            {
                Console.WriteLine("** No employees on the list **");
                return;
            }

            Console.WriteLine("***** Employee Details *****\n");
            foreach (var employee in Employeeslist)
            {
                employee.DisplayEmployeeList();  // invoke DisplayEmployeeList for each employee in Employeelist
            }
        }


        // Definition of CalculateSalary() function
        static void CalculateSalary()
        {
            Console.Write("Enter Employee ID to calculate salary: ");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (var employee in Employeeslist)   
            {
                if(employee.Id == id)
                {
                    Console.WriteLine("\n** Salary Details **\n");
                    Console.WriteLine($"Basic Pay:  {employee.BasicPay}\nAllowance: {employee.Allowances}\nDeduction: {employee.Deductions}\nTotal Salary: {employee.CalculateNetSalary()}");
                    break;
                }
                else
                {
                    Console.WriteLine("** Employee not found. **");
                }
            }
            
        }


        // Definition for calculating total payroll --- Bonus task
        static void CalculatePayroll()
        {
            int TotalPayroll=0;
            Console.WriteLine("Total payroll for employees\n");
            foreach (var employee in Employeeslist)
            {
                int salary = Convert.ToInt32(employee.CalculateNetSalary());
                Console.WriteLine($"Name: {employee.Name} -- Salary: {salary}");
                TotalPayroll += salary;
            }
            Console.WriteLine($"\nTotal Payroll for all employees: { TotalPayroll}");
        }


    }
}
