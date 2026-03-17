class SchoolStudent : Student
{
    public SchoolStudent(int id, string n, int m) : base(id, n, m) { }
    public override string CalculateGrade() => Marks > 40 ? "Pass" : "Fail";
}
