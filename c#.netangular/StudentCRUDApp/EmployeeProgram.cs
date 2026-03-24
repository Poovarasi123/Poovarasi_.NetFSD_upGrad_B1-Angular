using System;
using System.Data;
using System.Data.SqlClient;

class EmployeeProgram
{
    static string connectionString =
    "Data Source=.\\SQLEXPRESS;Initial Catalog=SchoolDB;Integrated Security=True;";

    public static void Run()
    {
        while (true)
        {
            Console.WriteLine("\n--- Employee Management ---");
            Console.WriteLine("1. Insert Employee");
            Console.WriteLine("2. Get Employees by Department");
            Console.WriteLine("3. Update Salary");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Back");

            Console.Write("Choose option: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input! Enter number: ");
            }

            switch (choice)
            {
                case 1: InsertEmployee(); break;
                case 2: GetEmployeesByDept(); break;
                case 3: UpdateSalary(); break;
                case 4: DeleteEmployee(); break;
                case 5: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void InsertEmployee()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("InsertEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Salary", salary);
            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Employee Inserted!");
        }
    }

    static void GetEmployeesByDept()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("GetEmployeesByDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Department", dept);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["EmpId"]}, Name: {reader["Name"]}, Salary: {reader["Salary"]}, Dept: {reader["Department"]}");
            }
        }
    }

    static void UpdateSalary()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("UpdateSalary", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpId", id);
            cmd.Parameters.AddWithValue("@Salary", salary);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Salary Updated!");
        }
    }

    static void DeleteEmployee()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string query = "DELETE FROM Employees WHERE EmpId=@Id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Employee Deleted!");
        }
    }
}