using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    using System;

    class Exercise3
    {
        public static void Run()
        {
            Console.WriteLine("Enter 5 numbers:");

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int d = Convert.ToInt32(Console.ReadLine());
            int e = Convert.ToInt32(Console.ReadLine());

            int sum = a + b + c + d + e;

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Average = " + sum / 5.0);
        }
    }
}
