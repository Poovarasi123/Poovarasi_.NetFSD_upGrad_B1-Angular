class TestHealthcare
{
    public static void Run()
    {
        List<Staff> list = new List<Staff>()
        {
            new Doctor(1,"Doctor",50000,20000),
            new Nurse(2,"Nurse",30000,5000),
            new LabTechnician(3,"Lab",25000,4000)
        };

        foreach (var s in list)
        {
            Console.WriteLine(s.CalculateSalary());
        }
    }
}