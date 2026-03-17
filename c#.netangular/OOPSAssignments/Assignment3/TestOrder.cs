class TestOrder
{
    public static void Run()
    {
        List<Order> orders = new List<Order>()
        {
            new StandardOrder(1,1000),
            new ExpressOrder(2,2000),
            new InternationalOrder(3,3000)
        };

        foreach (var o in orders)
        {
            Console.WriteLine(o.CalculateShippingCost());
        }
    }
}
