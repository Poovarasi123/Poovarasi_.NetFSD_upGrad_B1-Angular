using System;
using System.Collections.Generic;
using System.Linq;

class Student2
{
    public string Class;
    public string Subject;
    public int Marks;
}

class Assignment8
{
    public static void Run()
    {
        List<Student2> students = new List<Student2>
        {
            new Student2{Class="10", Subject="Math", Marks=80},
            new Student2{Class="10", Subject="Science", Marks=70}
        };

        var result = students.GroupBy(s => s.Class);

        foreach (var group in result)
            Console.WriteLine(group.Key);
    }
}