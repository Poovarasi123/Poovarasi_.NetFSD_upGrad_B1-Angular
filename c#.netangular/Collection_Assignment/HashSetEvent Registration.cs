class Demo3
{
    public static void Run()
    {
        HashSet<string> emails = new HashSet<string>()
        {
            "a@mail.com","b@mail.com","c@mail.com",
            "a@mail.com","d@mail.com","e@mail.com",
            "f@mail.com","g@mail.com","b@mail.com","h@mail.com"
        };

        Console.WriteLine("Unique Emails:");
        foreach (var e in emails)
            Console.WriteLine(e);

        Console.WriteLine(emails.Contains("a@mail.com"));

        emails.Remove("c@mail.com");

        HashSet<string> event2 = new HashSet<string>()
        {
            "a@mail.com","x@mail.com","y@mail.com"
        };

        Console.WriteLine("\nCommon:");
        emails.IntersectWith(event2);
        foreach (var e in emails)
            Console.WriteLine(e);
    }
}