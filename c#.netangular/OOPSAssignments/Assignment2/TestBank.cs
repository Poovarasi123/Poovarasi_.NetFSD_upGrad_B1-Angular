class TestBank
{
    public static void Run()
    {
        Account acc = new SavingsAccount(1, 5000);
        acc.CalculateInterest(); // Base method
    }
}