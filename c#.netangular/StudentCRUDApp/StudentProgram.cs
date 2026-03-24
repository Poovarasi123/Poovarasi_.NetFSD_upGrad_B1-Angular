using System;
using System.Data.SqlClient;


class StudentProgram
{
    static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;";

    public static void Run()
    {
        while (true)
        {
            Console.WriteLine("\n1. Insert Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");

            Console.Write("Choose option: ");
            Console.Write("Choose option: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input! Enter number: ");
            }

            switch (choice)
            {
                case 1: InsertStudent(); break;
                case 2: GetStudents(); break;
                case 3: UpdateStudent(); break;
                case 4: DeleteStudent(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void InsertStudent()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Grade: ");
            string grade = Console.ReadLine();

            string query = "INSERT INTO Students (Name, Age, Grade) VALUES (@Name, @Age, @Grade)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Grade", grade);

            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Student Added Successfully!");
        }
    }

    static void GetStudents()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Students";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Grade: {reader["Grade"]}");
            }
        }
    }

    static void UpdateStudent()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Grade: ");
            string grade = Console.ReadLine();

            string query = "UPDATE Students SET Grade=@Grade WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Grade", grade);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Updated Successfully!");
            else
                Console.WriteLine("Student Not Found!");
        }
    }

    static void DeleteStudent()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string query = "DELETE FROM Students WHERE Id=@Id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Deleted Successfully!");
            else
                Console.WriteLine("Student Not Found!");
        }
    }
}