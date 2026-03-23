using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id;
    public string Name;
    public int Age;
    public int Marks;
}

class Assignment1
{
    public static void Run()
    {
        List<Student> students = new List<Student>
        {
            new Student{Id=1, Name="Ravi", Age=20, Marks=80},
            new Student{Id=2, Name="Kiran", Age=22, Marks=70},
            new Student{Id=3, Name="Amit", Age=19, Marks=90}
        };

        var result = students.Where(s => s.Marks > 75);

        foreach (var s in result)
            Console.WriteLine(s.Name + " " + s.Marks);
    }
}