using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    using System;

    class Exercise6
    {
        public static void Run()
        {
            Console.Write("Rectangle length: ");
            int l = Convert.ToInt32(Console.ReadLine());

            Console.Write("Rectangle width: ");
            int w = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Rectangle Area = " + (l * w));

            Console.Write("Square side: ");
            int s = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Square Area = " + (s * s));
        }
    }
}
