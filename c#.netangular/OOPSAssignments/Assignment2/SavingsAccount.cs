class CurrentAccount : Account
{
    public CurrentAccount(int a, double b) : base(a, b) { }

    public new void CalculateInterest()
    {
        Console.WriteLine("Current account interest");
    }
}
