class Student
{
    public int Id;
    public string Name;
    public int Marks;

    public Student(int id, string name, int marks)
    {
        Id = id;
        Name = name;
        Marks = marks;
    }

    public virtual string CalculateGrade()
    {
        return Marks > 50 ? "Pass" : "Fail";
    }
}

