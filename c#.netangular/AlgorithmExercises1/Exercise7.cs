using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise7
    {
        static void Main()
        {
            double total = 0;

            Console.WriteLine("Enter product number (1-3), 0 to stop");

            int p = int.Parse(Console.ReadLine());

            while (p != 0)
            {
                Console.Write("Enter quantity: ");
                int q = int.Parse(Console.ReadLine());

                if (p == 1) total += 22.5 * q;
                else if (p == 2) total += 44.5 * q;
                else if (p == 3) total += 9.98 * q;

                Console.WriteLine("Enter product number (1-3), 0 to stop");
                p = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Total price: " + total);
        }
    }
}
