using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime RegisteredOn { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public List<Enrollment> Enrollments { get; set; } = new();
        public List<Result> Results { get; set; } = new();
    }
}