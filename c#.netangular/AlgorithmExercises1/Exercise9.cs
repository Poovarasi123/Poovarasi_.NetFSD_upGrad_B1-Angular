using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise9
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            int fact = 1;

            for (int i = 1; i <= n; i++)
                fact *= i;

            Console.WriteLine("Factorial = " + fact);
        }
    }
}
