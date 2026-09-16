namespace OnlineCourseManagement.Shared.DTOs
{
    /// <summary>
    /// DTO for Course - used for API communication
    /// </summary>
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public int Duration { get; set; }
        public int MaxStudents { get; set; }
        public decimal Credits { get; set; }
        public string Level { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EnrolledStudents { get; set; }
    }
}
