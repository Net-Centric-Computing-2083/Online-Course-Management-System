namespace OnlineCourseManagement.Shared.Models
{
    /// <summary>
    /// Represents a student's enrollment in a course
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; } // Active, Completed, Dropped, Paused
        public decimal Progress { get; set; } // Percentage
        public decimal GPA { get; set; }
        public bool IsApproved { get; set; }
        
        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
