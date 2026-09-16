namespace OnlineCourseManagement.Shared.Models
{
    /// <summary>
    /// Represents a student in the online course management system
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
