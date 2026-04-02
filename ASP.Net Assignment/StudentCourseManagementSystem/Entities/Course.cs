using System.Collections.Generic;

namespace StudentCourseManagementSystem.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}