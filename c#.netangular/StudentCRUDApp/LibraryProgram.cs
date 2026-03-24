using System;
using System.Data.SqlClient;

class LibraryProgram
{
    static string connectionString =
    "Data Source=.\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;";

    public static void Run()
    {
        while (true)
        {
            Console.WriteLine("\n--- Library Management ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Search Book");
            Console.WriteLine("6. Back");

            Console.Write("Choose option: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input! Enter number: ");
            }

            switch (choice)
            {
                case 1: AddBook(); break;
                case 2: ViewBooks(); break;
                case 3: UpdateBook(); break;
                case 4: DeleteBook(); break;
                case 5: SearchBook(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void AddBook()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            string query = "INSERT INTO Books (Title, Author, Price) VALUES (@Title, @Author, @Price)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Author", author);
            cmd.Parameters.AddWithValue("@Price", price);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Book Added Successfully!");
        }
    }

    static void ViewBooks()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Price: {reader["Price"]}");
            }
        }
    }

    static void UpdateBook()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Book ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            string query = "UPDATE Books SET Price=@Price WHERE BookId=@Id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Book Updated!");
            else
                Console.WriteLine("Book Not Found!");
        }
    }

    static void DeleteBook()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Book ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string query = "DELETE FROM Books WHERE BookId=@Id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Book Deleted!");
            else
                Console.WriteLine("Book Not Found!");
        }
    }

    static void SearchBook()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Book Name: ");
            string title = Console.ReadLine();

            string query = "SELECT * FROM Books WHERE Title LIKE @Title";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Title", "%" + title + "%");

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Price: {reader["Price"]}");
            }
        }
    }
}