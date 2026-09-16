namespace OnlineCourseManagement.Models
{
    /// <summary>
    /// Represents a course in the online course management system
    /// Author: Babita Thami (Phase 2)
    /// </summary>
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int InstructorId { get; set; }
        public int Duration { get; set; } // in weeks
        public int MaxStudents { get; set; }
        public decimal Credits { get; set; }
        public string Level { get; set; } // Beginner, Intermediate, Advanced
        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public Instructor Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
