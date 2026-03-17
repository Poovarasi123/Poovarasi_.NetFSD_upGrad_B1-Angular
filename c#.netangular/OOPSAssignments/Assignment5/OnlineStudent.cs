class OnlineStudent : Student
{
    public OnlineStudent(int id, string n, int m) : base(id, n, m) { }
    public override string CalculateGrade() => Marks > 60 ? "Pass" : "Fail";
}