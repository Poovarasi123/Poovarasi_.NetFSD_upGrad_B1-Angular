using System;
using System.Collections.Generic;
using System.Linq;

class Assignment6
{
    public static void Run()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 3, 6 };

        var result = numbers.Distinct();

        foreach (var n in result)
            Console.WriteLine(n);
    }
}