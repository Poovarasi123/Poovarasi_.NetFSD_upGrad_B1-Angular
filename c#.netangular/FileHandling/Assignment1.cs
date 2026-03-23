using System;
using System.IO;
using System.Collections.Generic;

class Assignment1
{
    static string filePath = "employee_log.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Login Entry");
            Console.WriteLine("2. Update Logout Time");
            Console.WriteLine("3. Display Logs");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddLogin();
                    break;
                case 2:
                    UpdateLogout();
                    break;
                case 3:
                    DisplayLogs();
                    break;
                case 4:
                    return;
            }
        }
    }

    static void AddLogin()
    {
        try
        {
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            string loginTime = DateTime.Now.ToString();

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{id}|{name}|{loginTime}|");
            }

            Console.WriteLine("Login recorded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void UpdateLogout()
    {
        try
        {
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine();

            var lines = new List<string>(File.ReadAllLines(filePath));

            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split('|');

                if (parts[0] == id && string.IsNullOrEmpty(parts[3]))
                {
                    parts[3] = DateTime.Now.ToString();
                    lines[i] = string.Join("|", parts);
                    break;
                }
            }

            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Logout updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void DisplayLogs()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.WriteLine("\n--- Employee Logs ---");
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            else
            {
                Console.WriteLine("No log file found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}