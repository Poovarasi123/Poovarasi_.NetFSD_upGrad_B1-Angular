class Patient
{
    public int Id;
    public string Name;
    public string Disease;
}

class Demo5
{
    public static void Run()
    {
        Queue<Patient> patients = new Queue<Patient>();

        patients.Enqueue(new Patient { Id = 1, Name = "A", Disease = "Fever" });
        patients.Enqueue(new Patient { Id = 2, Name = "B", Disease = "Cold" });
        patients.Enqueue(new Patient { Id = 3, Name = "C", Disease = "Flu" });
        patients.Enqueue(new Patient { Id = 4, Name = "D", Disease = "Headache" });
        patients.Enqueue(new Patient { Id = 5, Name = "E", Disease = "Cough" });

        patients.Dequeue();
        patients.Dequeue();

        Console.WriteLine("Next: " + patients.Peek().Name);

        Console.WriteLine("Remaining:");
        foreach (var p in patients)
            Console.WriteLine(p.Name);
    }
}