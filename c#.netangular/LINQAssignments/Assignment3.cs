using System;
using System.Collections.Generic;
using System.Linq;

class Assignment3
{
    public static void Run()
    {
        List<string> names = new List<string> { "Ravi", "Kiran", "Amit", "Raj", "Anil" };

        var result = names.Where(n => n.StartsWith("A"));

        foreach (var n in result)
            Console.WriteLine(n);
    }
}