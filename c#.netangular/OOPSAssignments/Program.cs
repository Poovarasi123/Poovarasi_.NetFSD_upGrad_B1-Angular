using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Select Assignment (1-6): ");
        Console.WriteLine("1. Healthcare");
        Console.WriteLine("2. Banking");
        Console.WriteLine("3. E-Commerce");
        Console.WriteLine("4. Vehicle (Sealed)");
        Console.WriteLine("5. Education");
        Console.WriteLine("6. Furniture");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                TestHealthcare.Run();
                break;

            case 2:
                TestBank.Run();
                break;

            case 3:
                TestOrder.Run();
                break;

            case 4:
                Console.WriteLine("Sealed class demo:");
                Vehicle v = new ElectricCar();
                v.StartVehicle();
                Console.WriteLine("ElectricCar is sealed, so it cannot be inherited.");
                break;

            case 5:
                TestStudent.Run();
                break;

            case 6:
                Console.WriteLine("1. Chair\n2. Cot");
                int opt = int.Parse(Console.ReadLine());

                if (opt == 1)
                {
                    Chair c = new Chair();
                    c.GetData();
                    c.ShowData();
                }
                else
                {
                    Cot cot = new Cot();
                    cot.GetData();
                    cot.ShowData();
                }
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}