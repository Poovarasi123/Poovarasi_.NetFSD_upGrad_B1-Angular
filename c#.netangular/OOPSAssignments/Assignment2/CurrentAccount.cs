class SavingsAccount : Account
{
    public SavingsAccount(int a, double b) : base(a, b) { }

    public new void CalculateInterest()
    {
        Console.WriteLine("Savings account interest");
    }
}
