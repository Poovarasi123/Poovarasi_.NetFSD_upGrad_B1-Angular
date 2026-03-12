using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    using System;

    class Exercise2
    {
        public static void Run()
        {
            Console.Write("Enter KM: ");
            double km = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Meters = " + (km * 1000));
        }
    }
}
