class Song
{
    public int Id;
    public string Title;
    public string Artist;
}

class Demo6
{
    public static void Run()
    {
        LinkedList<Song> playlist = new LinkedList<Song>();

        var s1 = new Song { Id = 1, Title = "Song1", Artist = "A" };
        var s2 = new Song { Id = 2, Title = "Song2", Artist = "B" };
        var s3 = new Song { Id = 3, Title = "Song3", Artist = "C" };

        playlist.AddFirst(s1);
        playlist.AddLast(s2);
        var node = playlist.AddLast(s3);

        playlist.AddBefore(node, new Song { Id = 4, Title = "Song4", Artist = "D" });

        playlist.Remove(s2);

        Console.WriteLine("Forward:");
        foreach (var s in playlist)
            Console.WriteLine(s.Title);

        Console.WriteLine("Backward:");
        var current = playlist.Last;
        while (current != null)
        {
            Console.WriteLine(current.Value.Title);
            current = current.Previous;
        }

        var found = playlist.FirstOrDefault(s => s.Title == "Song1");
        Console.WriteLine("Found: " + found?.Title);
    }
}