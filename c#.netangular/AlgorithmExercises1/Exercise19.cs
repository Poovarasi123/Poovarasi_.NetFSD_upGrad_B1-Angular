using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmExercises1
{
    using System;

    class Exercise19
    {
        static void Main()
        {
            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            char[] arr = word.ToCharArray();
            Array.Reverse(arr);

            string rev = new string(arr);

            if (word == rev)
                Console.WriteLine("Palindrome");
            else
                Console.WriteLine("Not Palindrome");
        }
    }
}
