using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    using System;

    class Exercise5
    {
        public static void Run()
        {
            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Highest = " + (a > b ? a : b));
        }
    }
}
