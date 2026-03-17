class TestStudent
{
    public static void Run()
    {
        Student[] s = {
            new SchoolStudent(1,"A",45),
            new CollegeStudent(2,"B",55),
            new OnlineStudent(3,"C",65)
        };

        foreach (var x in s)
        {
            Console.WriteLine(x.CalculateGrade());
        }
    }
}

