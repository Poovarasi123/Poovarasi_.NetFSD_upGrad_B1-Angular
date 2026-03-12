using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise10
    {
        static void Main()
        {
            int a = 0, b = 1;

            while (a <= 40)
            {
                Console.WriteLine(a);
                int c = a + b;
                a = b;
                b = c;
            }
        }
    }
}
