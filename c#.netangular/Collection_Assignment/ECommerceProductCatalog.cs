using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public string Category;
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>()
        {
            new Product{Id=1,Name="Laptop",Price=50000,Category="Electronics"},
            new Product{Id=2,Name="Phone",Price=15000,Category="Electronics"},
            new Product{Id=3,Name="Shoes",Price=2000,Category="Fashion"},
            new Product{Id=4,Name="Watch",Price=1200,Category="Fashion"},
            new Product{Id=5,Name="TV",Price=40000,Category="Electronics"},
            new Product{Id=6,Name="Bag",Price=800,Category="Fashion"},
            new Product{Id=7,Name="Tablet",Price=20000,Category="Electronics"},
            new Product{Id=8,Name="Headphones",Price=1500,Category="Electronics"},
            new Product{Id=9,Name="Keyboard",Price=700,Category="Electronics"},
            new Product{Id=10,Name="Mouse",Price=500,Category="Electronics"}
        };

        Console.WriteLine("All Products:");
        products.ForEach(p => Console.WriteLine($"{p.Name} - {p.Price}"));

        Console.WriteLine("\nPrice > 1000:");
        var costly = products.Where(p => p.Price > 1000);
        foreach (var p in costly)
            Console.WriteLine(p.Name);

        Console.WriteLine("\nAscending:");
        products.OrderBy(p => p.Price).ToList()
            .ForEach(p => Console.WriteLine(p.Name + " " + p.Price));

        Console.WriteLine("\nDescending:");
        products.OrderByDescending(p => p.Price).ToList()
            .ForEach(p => Console.WriteLine(p.Name + " " + p.Price));

        products.RemoveAll(p => p.Id == 10);

        Console.WriteLine("\nElectronics:");
        var electronics = products.Where(p => p.Category == "Electronics");
        foreach (var p in electronics)
            Console.WriteLine(p.Name);
    }
}