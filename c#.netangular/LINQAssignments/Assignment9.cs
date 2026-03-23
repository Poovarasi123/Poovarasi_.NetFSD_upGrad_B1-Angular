using System;
using System.Collections.Generic;
using System.Linq;

class Order2
{
    public string CustomerName;
    public DateTime OrderDate;
    public double TotalAmount;
}

class Assignment9
{
    public static void Run()
    {
        List<Order2> orders = new List<Order2>
        {
            new Order2{CustomerName="Ravi", OrderDate=DateTime.Now, TotalAmount=2000}
        };

        var result = orders.Where(o => o.OrderDate >= DateTime.Now.AddDays(-30));

        foreach (var o in result)
            Console.WriteLine(o.CustomerName);
    }
}