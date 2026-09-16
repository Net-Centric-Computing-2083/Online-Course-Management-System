namespace OnlineCourseManagement.Models
{
    /// <summary>
    /// Represents an assignment for a course
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public class Assignment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int MaxMarks { get; set; }
        public string AssignmentType { get; set; } // Quiz, Project, Essay, Practical
        public DateTime CreatedDate { get; set; }
        public bool IsPublished { get; set; } = false;
        
        // Navigation properties
        public Course Course { get; set; }
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
