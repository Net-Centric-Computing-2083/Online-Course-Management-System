namespace OnlineCourseManagement.Shared.DTOs
{
    /// <summary>
    /// DTO for Instructor - used for API communication
    /// </summary>
    public class InstructorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
}
