using System;
using System.IO;

class Assignment2
{
    static void Main()
    {
        Console.WriteLine("1. Create Report");
        Console.WriteLine("2. Read Report");

        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
            CreateReport();
        else
            ReadReport();
    }

    static void CreateReport()
    {
        try
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Roll Number: ");
            string roll = Console.ReadLine();

            int m1 = GetMarks("Subject 1");
            int m2 = GetMarks("Subject 2");
            int m3 = GetMarks("Subject 3");

            int total = m1 + m2 + m3;
            double avg = total / 3.0;

            string grade = avg >= 80 ? "A" :
                           avg >= 60 ? "B" :
                           avg >= 40 ? "C" : "Fail";

            string content = $"Student Name: {name}\n" +
                             $"Roll Number: {roll}\n" +
                             $"Marks: {m1}, {m2}, {m3}\n" +
                             $"Total: {total}\n" +
                             $"Average: {avg}\n" +
                             $"Grade: {grade}";

            File.WriteAllText(roll + ".txt", content);

            Console.WriteLine("Report saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ReadReport()
    {
        try
        {
            Console.Write("Enter Roll Number: ");
            string roll = Console.ReadLine();

            string file = roll + ".txt";

            if (File.Exists(file))
            {
                string content = File.ReadAllText(file);
                Console.WriteLine("\n--- Report ---");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Report not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static int GetMarks(string subject)
    {
        int marks;
        while (true)
        {
            Console.Write($"Enter {subject} marks: ");
            if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                return marks;
            else
                Console.WriteLine("Invalid input. Enter 0-100.");
        }
    }
}