using System;
using System.IO;

class Assignment3
{
    static void Main()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\n1. Create File");
            Console.WriteLine("2. Write to File");
            Console.WriteLine("3. Read File");
            Console.WriteLine("4. Append Text");
            Console.WriteLine("5. Delete File");
            Console.WriteLine("6. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        File.Create(fileName).Close();
                        Console.WriteLine("File created.");
                        break;

                    case 2:
                        using (StreamWriter sw = new StreamWriter(fileName))
                        {
                            Console.WriteLine("Enter text (type 'end' to stop):");
                            string line;
                            while ((line = Console.ReadLine()) != "end")
                            {
                                sw.WriteLine(line);
                            }
                        }
                        break;

                    case 3:
                        if (File.Exists(fileName))
                        {
                            using (StreamReader sr = new StreamReader(fileName))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }
                        }
                        else
                        {
                            Console.WriteLine("File not found.");
                        }
                        break;

                    case 4:
                        using (StreamWriter sw = new StreamWriter(fileName, true))
                        {
                            Console.WriteLine("Enter text to append (type 'end' to stop):");
                            string line;
                            while ((line = Console.ReadLine()) != "end")
                            {
                                sw.WriteLine(line);
                            }
                        }
                        break;

                    case 5:
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                            Console.WriteLine("File deleted.");
                        }
                        else
                        {
                            Console.WriteLine("File not found.");
                        }
                        break;

                    case 6:
                        return;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}