using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise5
    {
        static void Main()
        {
            int even = 0, odd = 0;

            Console.WriteLine("Enter numbers (0 to stop)");

            int n = int.Parse(Console.ReadLine());

            while (n != 0)
            {
                if (n % 2 == 0) even++;
                else odd++;

                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Even: " + even);
            Console.WriteLine("Odd: " + odd);
        }
    }
}
