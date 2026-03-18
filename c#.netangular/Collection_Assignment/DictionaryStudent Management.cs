class Student
{
    public int Id;
    public string Name;
    public int Marks;
}

class Demo2
{
    public static void Run()
    {
        Dictionary<int, Student> students = new Dictionary<int, Student>()
        {
            {1,new Student{Id=1,Name="A",Marks=80}},
            {2,new Student{Id=2,Name="B",Marks=60}},
            {3,new Student{Id=3,Name="C",Marks=90}},
            {4,new Student{Id=4,Name="D",Marks=70}},
            {5,new Student{Id=5,Name="E",Marks=85}},
        };

        Console.WriteLine(students[1].Name);

        if (students.ContainsKey(3))
            Console.WriteLine("Student exists");

        students[2].Marks = 75;

        students.Remove(4);

        Console.WriteLine("\nAbove 75:");
        foreach (var s in students.Values.Where(s => s.Marks > 75))
            Console.WriteLine(s.Name);
    }
}