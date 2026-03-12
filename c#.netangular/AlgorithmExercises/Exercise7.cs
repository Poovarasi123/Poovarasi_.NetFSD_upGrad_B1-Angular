using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    using System;

    class Exercise7
    {
        public static void Run()
        {
            Console.Write("Enter distance: ");
            double d = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter speed: ");
            double s = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Time = " + (d / s));
        }
    }
}
