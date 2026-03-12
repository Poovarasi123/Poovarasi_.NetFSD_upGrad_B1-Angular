using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    using System;

    class Exercise4
    {
        public static void Run()
        {
            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
                Console.WriteLine("Even Number");
            else
                Console.WriteLine("Odd Number");
        }
    }
}
