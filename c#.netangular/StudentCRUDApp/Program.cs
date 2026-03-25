using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Student Management");
            Console.WriteLine("2. Employee Management");
            Console.WriteLine("3. Library Management");
            Console.WriteLine("4. Product Inventory");
            Console.WriteLine("5. Order Management");
            Console.WriteLine("6. Exit");

            Console.Write("Choose option: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input! Enter number: ");
            }

            switch (choice)
            {
                case 1:
                    StudentProgram.Run(); // your previous code
                    break;

                case 2:
                    EmployeeProgram.Run(); // new file
                    break;

                case 3:
                    LibraryProgram.Run();
                    break;

                case 4:
                    ProductProgram.Run();
                    break;

                case 5:
                    OrderProgram.Run();
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}