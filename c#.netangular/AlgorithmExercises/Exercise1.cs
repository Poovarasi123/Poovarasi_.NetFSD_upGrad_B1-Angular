using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{ 
    class Exercise1
    {
        public static void Run()
        {
            Console.Write("Enter first number: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Quotient = " + (a / b));
        }
    }
}
