using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise6
    {
        static void Main()
        {
            Console.Write("Enter Fahrenheit: ");
            double f = double.Parse(Console.ReadLine());

            double c = (f - 32) * 5 / 9;

            Console.WriteLine("Celsius: " + c);
        }
    }
}
