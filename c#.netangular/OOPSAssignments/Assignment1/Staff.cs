class Staff
{
    public int StaffId;
    public string Name;
    public double BaseSalary;

    public Staff(int id, string name, double salary)
    {
        StaffId = id;
        Name = name;
        BaseSalary = salary;
    }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}