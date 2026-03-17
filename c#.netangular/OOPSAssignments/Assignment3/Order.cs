class Order
{
    public int OrderId;
    public double Amount;

    public Order(int id, double amt)
    {
        OrderId = id;
        Amount = amt;
    }

    public virtual double CalculateShippingCost()
    {
        return 50;
    }
}
