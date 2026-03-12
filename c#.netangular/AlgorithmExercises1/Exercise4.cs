using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise4
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 0)
                Console.WriteLine("Even");
            else
                Console.WriteLine("Odd");
        }
    }
}
