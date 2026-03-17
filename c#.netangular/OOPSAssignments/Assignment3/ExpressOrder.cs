

class ExpressOrder : Order
{
    public ExpressOrder(int id, double amt) : base(id, amt) { }
    public override double CalculateShippingCost() => 100;
}