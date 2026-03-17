class Furniture
{
    public int OrderId;
    public int Qty;
    public double TotalAmt;
    public string PaymentMode;

    public virtual void GetData()
    {
        Console.Write("OrderId: ");
        OrderId = int.Parse(Console.ReadLine());

        Console.Write("Qty: ");
        Qty = int.Parse(Console.ReadLine());

        Console.Write("Payment Mode: ");
        PaymentMode = Console.ReadLine();
    }

    public virtual void ShowData()
    {
        Console.WriteLine($"OrderId: {OrderId}, Qty: {Qty}, Payment: {PaymentMode}");
    }
}
