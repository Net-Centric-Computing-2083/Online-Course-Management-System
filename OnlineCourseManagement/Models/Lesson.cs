namespace OnlineCourseManagement.Models
{
    /// <summary>
    /// Represents a lesson within a course
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public class Lesson
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; } // HTML content
        public int OrderNumber { get; set; }
        public string VideoUrl { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsPublished { get; set; } = false;
        
        // Navigation properties
        public Course Course { get; set; }
    }
}
