namespace OnlineCourseManagement.Shared.Models
{
    /// <summary>
    /// Represents an instructor in the online course management system
    /// Author: Babita Thami (Phase 2)
    /// </summary>
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
