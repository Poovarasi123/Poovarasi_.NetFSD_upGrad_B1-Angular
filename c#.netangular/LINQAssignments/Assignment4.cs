using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public double Salary;
}

class Assignment4
{
    public static void Run()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1, Name="A", Department="IT", Salary=50000},
            new Employee{Id=2, Name="B", Department="HR", Salary=40000},
            new Employee{Id=3, Name="C", Department="IT", Salary=70000}
        };

        var result = employees.Where(e => e.Department == "IT");

        foreach (var e in result)
            Console.WriteLine(e.Name);
    }
}