using System.Collections.Generic;

namespace StudentCourseManagementSystem.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}