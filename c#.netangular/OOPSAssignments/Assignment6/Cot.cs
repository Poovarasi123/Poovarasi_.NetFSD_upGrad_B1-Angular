class Cot : Furniture
{
    public string CotType;
    public double Rate;

    public override void GetData()
    {
        base.GetData();
        Console.Write("Cot Type: ");
        CotType = Console.ReadLine();

        Console.Write("Rate: ");
        Rate = double.Parse(Console.ReadLine());

        TotalAmt = Qty * Rate;
    }

    public override void ShowData()
    {
        base.ShowData();
        Console.WriteLine($"CotType: {CotType}, Total: {TotalAmt}");
    }
}
