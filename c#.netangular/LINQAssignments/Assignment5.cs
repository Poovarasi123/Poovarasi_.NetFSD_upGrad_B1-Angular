using System;
using System.Collections.Generic;
using System.Linq;

class Customer
{
    public int Id;
    public string Name;
}

class Order
{
    public int Id;
    public int CustomerId;
    public double Amount;
}

class Assignment5
{
    public static void Run()
    {
        var customers = new List<Customer>
        {
            new Customer{Id=1, Name="Ravi"},
            new Customer{Id=2, Name="Amit"}
        };

        var orders = new List<Order>
        {
            new Order{Id=1, CustomerId=1, Amount=3000},
            new Order{Id=2, CustomerId=1, Amount=2500}
        };

        var result = customers.Join(orders,
            c => c.Id,
            o => o.CustomerId,
            (c, o) => new { c.Name, o.Amount });

        foreach (var r in result)
            Console.WriteLine(r.Name + " " + r.Amount);
    }
}