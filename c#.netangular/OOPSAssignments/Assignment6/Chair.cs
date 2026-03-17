class Chair : Furniture
{
    public string ChairType;
    public double Rate;

    public override void GetData()
    {
        base.GetData();
        Console.Write("Chair Type: ");
        ChairType = Console.ReadLine();

        Console.Write("Rate: ");
        Rate = double.Parse(Console.ReadLine());

        TotalAmt = Qty * Rate;
    }

    public override void ShowData()
    {
        base.ShowData();
        Console.WriteLine($"ChairType: {ChairType}, Total: {TotalAmt}");
    }
}
