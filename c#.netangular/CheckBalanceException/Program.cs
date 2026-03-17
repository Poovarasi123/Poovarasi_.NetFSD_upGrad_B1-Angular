using System;

class CheckBalanceException : Exception
{
    public CheckBalanceException(string msg) : base(msg) { }
}

class BankAccount
{
    public int AccountNumber { get; set; }
    public string Name { get; set; }
    public static double Balance;
    public char TransactionType;
    public double TransactionAmount;

    public BankAccount(int accNo, string name, double balance, char type, double amount)
    {
        AccountNumber = accNo;
        Name = name;
        Balance = balance;
        TransactionType = type;
        TransactionAmount = amount;
    }

    public void ProcessTransaction()
    {
        try
        {
            if (TransactionType == 'd') // deposit
            {
                Balance += TransactionAmount;
                Console.WriteLine("Deposited Successfully");
            }
            else if (TransactionType == 'c') // withdraw
            {
                if (Balance - TransactionAmount < 500)
                {
                    throw new CheckBalanceException("Minimum balance should be 500!");
                }
                Balance -= TransactionAmount;
                Console.WriteLine("Withdrawal Successful");
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type");
            }

            Console.WriteLine("Current Balance: " + Balance);
        }
        catch (CheckBalanceException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class TicketBooking
{
    int availableTickets = 15;

    public void BookTickets()
    {
        try
        {
            Console.Write("Do you want to book tickets (yes/no)? ");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "yes")
            {
                Console.Write("Enter number of tickets: ");
                int tickets = Convert.ToInt32(Console.ReadLine());

                if (tickets > availableTickets)
                {
                    throw new Exception("Tickets not available!");
                }

                availableTickets -= tickets;
                Console.WriteLine("Tickets booked successfully!");
                Console.WriteLine("Remaining tickets: " + availableTickets);
            }
            else
            {
                Console.WriteLine("Booking cancelled");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}


class Program
{
    static void Main()
    {
        // ===== Q1 =====
        Console.WriteLine("---- BANK ACCOUNT ----");
        BankAccount b = new BankAccount(101, "Arun", 1000, 'c', 600);
        b.ProcessTransaction();

        // ===== Q2 =====
        Console.WriteLine("\n---- MOVIE BOOKING ----");
        TicketBooking t = new TicketBooking();
        t.BookTickets();
    }
}
