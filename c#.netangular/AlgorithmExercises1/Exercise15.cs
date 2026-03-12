using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;
    using System.Linq;

    class Exercise15
    {
        static void Main()
        {
            int[] marks = new int[10];
            int total = 0;

            Console.WriteLine("Enter 10 marks");

            for (int i = 0; i < 10; i++)
            {
                marks[i] = int.Parse(Console.ReadLine());
                total += marks[i];
            }

            Console.WriteLine("Total = " + total);
            Console.WriteLine("Average = " + total / 10.0);
            Console.WriteLine("Min = " + marks.Min());
            Console.WriteLine("Max = " + marks.Max());

            Array.Sort(marks);

            Console.WriteLine("Ascending:");
            foreach (int m in marks)
                Console.Write(m + " ");

            Console.WriteLine("\nDescending:");
            Array.Reverse(marks);

            foreach (int m in marks)
                Console.Write(m + " ");
        }
    }
}
