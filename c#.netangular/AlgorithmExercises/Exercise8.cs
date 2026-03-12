using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises
{
    using System;

    class Exercise8
    {
        public static void Run()
        {
            Console.Write("Enter string: ");
            string text = Console.ReadLine();

            char ch = text[2];

            if ("aeiouAEIOU".Contains(ch))
                Console.WriteLine("Vowel");
            else
                Console.WriteLine("Consonant");
        }
    }
}
