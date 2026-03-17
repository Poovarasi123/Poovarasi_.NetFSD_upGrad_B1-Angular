class LabTechnician : Staff
{
    double allowance;
    public LabTechnician(int id, string name, double sal, double a) : base(id, name, sal)
    {
        allowance = a;
    }
    public override double CalculateSalary() => BaseSalary + allowance;
}
