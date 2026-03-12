using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise11
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 20; i++)
                Console.WriteLine(n + " x " + i + " = " + (n * i));
        }
    }
}
