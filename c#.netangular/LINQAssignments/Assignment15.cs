using System;
using System.Collections.Generic;
using System.Linq;

class Employee2
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;
    public DateTime JoiningDate;
}

class Assignment15
{
    public static void Run()
    {
        List<Employee2> employees = new List<Employee2>
        {
            new Employee2{Id=1, Name="A", Department="IT", Salary=50000, JoiningDate=DateTime.Now},
            new Employee2{Id=2, Name="B", Department="HR", Salary=60000, JoiningDate=DateTime.Now}
        };

        int total = employees.Count();

        Console.WriteLine("Total Employees: " + total);
    }
}