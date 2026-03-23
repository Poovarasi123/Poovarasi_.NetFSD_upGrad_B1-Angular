using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id;
    public string Name;
    public string Category;
    public double Price;
    public int Stock;
}

class Assignment7
{
    public static void Run()
    {
        List<Product> products = new List<Product>
        {
            new Product{Id=1, Name="Pen", Category="Stationery", Price=10, Stock=5},
            new Product{Id=2, Name="Book", Category="Stationery", Price=50, Stock=20}
        };

        var result = products.Where(p => p.Stock < 10);

        foreach (var p in result)
            Console.WriteLine(p.Name);
    }
}