

class CollegeStudent : Student
{
    public CollegeStudent(int id, string n, int m) : base(id, n, m) { }
    public override string CalculateGrade() => Marks > 50 ? "Pass" : "Fail";
}
