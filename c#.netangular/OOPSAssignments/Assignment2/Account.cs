class Account
{
    public int AccountNumber;
    public double Balance;

    public Account(int acc, double bal)
    {
        AccountNumber = acc;
        Balance = bal;
    }

    public void CalculateInterest()
    {
        Console.WriteLine("Base account interest calculation");
    }
}
