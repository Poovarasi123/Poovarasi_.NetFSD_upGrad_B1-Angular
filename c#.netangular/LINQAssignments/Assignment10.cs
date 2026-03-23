using System;
using System.Collections.Generic;
using System.Linq;

class Assignment10
{
    public static void Run()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1, Name="A", Department="IT", Salary=50000},
            new Employee{Id=2, Name="B", Department="HR", Salary=60000}
        };

        var result = employees.OrderBy(e => e.Department)
                              .ThenByDescending(e => e.Salary);

        foreach (var e in result)
            Console.WriteLine(e.Name);
    }
}