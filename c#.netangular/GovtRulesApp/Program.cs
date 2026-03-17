using System;

interface GovtRules
{
    double EmployeePF(double basicSalary);
    string LeaveDetails();
    double gratuityAmount(float serviceCompleted, double basicSalary);
}

class TCS : GovtRules
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
    public string Desg { get; set; }
    public double BasicSalary { get; set; }

    public TCS(int id, string name, string dept, string desg, double salary)
    {
        EmpId = id;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = salary;
    }

    public double EmployeePF(double basicSalary)
    {
        double empPF = 0.12 * basicSalary;
        double employerPF = 0.0833 * basicSalary;
        double pension = 0.0367 * basicSalary;

        Console.WriteLine("Employer PF: " + employerPF);
        Console.WriteLine("Pension Fund: " + pension);

        return empPF;
    }

    public string LeaveDetails()
    {
        return "1 Casual/month, 12 Sick/year, 10 Privilege/year";
    }

    public double gratuityAmount(float service, double salary)
    {
        if (service > 20) return 3 * salary;
        else if (service > 10) return 2 * salary;
        else if (service > 5) return salary;
        else return 0;
    }
}


class Accenture : GovtRules
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public string Dept { get; set; }
    public string Desg { get; set; }
    public double BasicSalary { get; set; }

    public Accenture(int id, string name, string dept, string desg, double salary)
    {
        EmpId = id;
        Name = name;
        Dept = dept;
        Desg = desg;
        BasicSalary = salary;
    }

    public double EmployeePF(double basicSalary)
    {
        double empPF = 0.12 * basicSalary;
        double employerPF = 0.12 * basicSalary;

        Console.WriteLine("Employer PF: " + employerPF);

        return empPF;
    }

    public string LeaveDetails()
    {
        return "2 Casual/month, 5 Sick/year, 5 Privilege/year";
    }

    public double gratuityAmount(float service, double salary)
    {
        return 0;
    }
}


abstract class Sales
{
    public abstract int MonthlySales(int dailySales);

    public int DailySales()
    {
        return 400;
    }
}


interface IYearlySales
{
    int YearlySales();
}


class Program : Sales, IYearlySales
{
    public override int MonthlySales(int dailySales)
    {
        return dailySales * 30;
    }

    public int YearlySales()
    {
        return 400 * 30 * 12;
    }

    static void Main()
    {
       
        Console.WriteLine("---- TCS ----");
        TCS t = new TCS(1, "Arun", "IT", "Developer", 30000);

        Console.WriteLine($"ID:{t.EmpId}, Name:{t.Name}");
        Console.WriteLine("PF: " + t.EmployeePF(t.BasicSalary));
        Console.WriteLine("Leave: " + t.LeaveDetails());
        Console.WriteLine("Gratuity: " + t.gratuityAmount(12, t.BasicSalary));

        Console.WriteLine("\n---- Accenture ----");
        Accenture a = new Accenture(2, "Priya", "HR", "Manager", 40000);

        Console.WriteLine($"ID:{a.EmpId}, Name:{a.Name}");
        Console.WriteLine("PF: " + a.EmployeePF(a.BasicSalary));
        Console.WriteLine("Leave: " + a.LeaveDetails());
        Console.WriteLine("Gratuity: " + a.gratuityAmount(8, a.BasicSalary));

       
        Console.WriteLine("\n---- SALES REPORT ----");
        Program p = new Program();

        int daily = p.DailySales();
        int monthly = p.MonthlySales(daily);
        int yearly = p.YearlySales();

        Console.WriteLine("Daily sales: Rs." + daily);
        Console.WriteLine("Monthly sales: Rs." + monthly);
        Console.WriteLine("Annual sales: Rs." + yearly);
    }
}
