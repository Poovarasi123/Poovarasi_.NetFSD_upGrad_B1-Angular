using System;
using System.Data;
using System.Data.SqlClient;

class ProductProgram
{
    static string connectionString =
    "Data Source=.\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;";

    static DataSet ds = new DataSet();
    static SqlDataAdapter adapter;

    public static void Run()
    {
        LoadData();

        while (true)
        {
            Console.WriteLine("\n--- Product Inventory ---");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Update Product Price");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Save Changes to DB");
            Console.WriteLine("6. Back");

            Console.Write("Choose option: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input! Enter number: ");
            }

            switch (choice)
            {
                case 1: ViewProducts(); break;
                case 2: AddProduct(); break;
                case 3: UpdateProduct(); break;
                case 4: DeleteProduct(); break;
                case 5: SaveChanges(); break;
                case 6: return;
            }
        }
    }

    static void LoadData()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            adapter = new SqlDataAdapter("SELECT * FROM Products", con);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.Fill(ds, "Products");
        }
    }

    static void ViewProducts()
    {
        DataTable dt = ds.Tables["Products"];

        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"ID: {row["ProductId"]}, Name: {row["ProductName"]}, Price: {row["Price"]}, Stock: {row["Stock"]}");
        }
    }

    static void AddProduct()
    {
        DataTable dt = ds.Tables["Products"];

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Stock: ");
        int stock = Convert.ToInt32(Console.ReadLine());

        DataRow row = dt.NewRow();
        row["ProductName"] = name;
        row["Price"] = price;
        row["Stock"] = stock;

        dt.Rows.Add(row);

        Console.WriteLine("Product Added (Offline)!");
    }

    static void UpdateProduct()
    {
        DataTable dt = ds.Tables["Products"];

        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (DataRow row in dt.Rows)
        {
            if ((int)row["ProductId"] == id)
            {
                Console.Write("Enter New Price: ");
                row["Price"] = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Updated (Offline)!");
                return;
            }
        }

        Console.WriteLine("Product Not Found!");
    }

    static void DeleteProduct()
    {
        DataTable dt = ds.Tables["Products"];

        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (DataRow row in dt.Rows)
        {
            if ((int)row["ProductId"] == id)
            {
                row.Delete();
                Console.WriteLine("Deleted (Offline)!");
                return;
            }
        }

        Console.WriteLine("Product Not Found!");
    }

    static void SaveChanges()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            adapter.Update(ds, "Products");
            Console.WriteLine("Changes Saved to Database!");
        }
    }
}