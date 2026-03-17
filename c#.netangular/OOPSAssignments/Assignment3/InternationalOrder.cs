

class InternationalOrder : Order
{
    public InternationalOrder(int id, double amt) : base(id, amt) { }
    public override double CalculateShippingCost() => 500;
}
