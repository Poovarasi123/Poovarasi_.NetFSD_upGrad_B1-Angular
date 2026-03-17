class Doctor : Staff
{
    double fee;
    public Doctor(int id, string name, double sal, double f) : base(id, name, sal)
    {
        fee = f;
    }
    public override double CalculateSalary() => BaseSalary + fee;
}