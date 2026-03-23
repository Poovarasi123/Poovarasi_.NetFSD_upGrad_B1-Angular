using System;
using System.Collections.Generic;
using System.Linq;

class Assignment2
{
    public static void Run()
    {
        List<int> numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

        var even = numbers.Where(n => n % 2 == 0);

        foreach (var n in even)
            Console.WriteLine(n);
    }
}