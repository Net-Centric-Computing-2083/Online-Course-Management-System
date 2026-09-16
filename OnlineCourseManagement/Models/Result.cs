namespace OnlineCourseManagement.Models
{
    /// <summary>
    /// Represents a student's result for an assignment
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public decimal MarksObtained { get; set; }
        public string Feedback { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime? GradedDate { get; set; }
        public bool IsSubmitted { get; set; }
        public string SubmissionUrl { get; set; }
        
        // Navigation properties
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
    }
}
