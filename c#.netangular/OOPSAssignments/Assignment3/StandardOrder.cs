class StandardOrder : Order
{
    public StandardOrder(int id, double amt) : base(id, amt) { }
    public override double CalculateShippingCost() => 50;
}