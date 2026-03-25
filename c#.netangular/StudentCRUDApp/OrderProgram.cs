using System;
using System.Data.SqlClient;

class OrderProgram
{
    static string connectionString =
    "Data Source=.\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;";

    public static void Run()
    {
        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Total Amount: ");
        decimal total = Convert.ToDecimal(Console.ReadLine());

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Insert Order
                string orderQuery = "INSERT INTO Orders (CustomerName, TotalAmount) OUTPUT INSERTED.OrderId VALUES (@Name, @Total)";

                SqlCommand orderCmd = new SqlCommand(orderQuery, con, transaction);
                orderCmd.Parameters.AddWithValue("@Name", name);
                orderCmd.Parameters.AddWithValue("@Total", total);

                int orderId = (int)orderCmd.ExecuteScalar();

                // Insert Order Items
                Console.Write("How many items? ");
                int count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.Write("Enter Product Name: ");
                    string pname = Console.ReadLine();

                    Console.Write("Enter Quantity: ");
                    int qty = Convert.ToInt32(Console.ReadLine());

                    string itemQuery = "INSERT INTO OrderItems (OrderId, ProductName, Quantity) VALUES (@OrderId, @Pname, @Qty)";

                    SqlCommand itemCmd = new SqlCommand(itemQuery, con, transaction);
                    itemCmd.Parameters.AddWithValue("@OrderId", orderId);
                    itemCmd.Parameters.AddWithValue("@Pname", pname);
                    itemCmd.Parameters.AddWithValue("@Qty", qty);

                    itemCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                Console.WriteLine("Order Placed Successfully!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Error! Transaction Rolled Back");
            }
        }
    }
}