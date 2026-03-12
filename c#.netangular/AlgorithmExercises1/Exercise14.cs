using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise14
    {
        static void Main()
        {
            int min = int.MaxValue;

            for (int i = 1; i <= 5; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (n < min) min = n;
            }

            Console.WriteLine("Smallest = " + min);
        }
    }
}
