using System.ComponentModel.DataAnnotations;

namespace Online_Course_Management_System.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Specialization { get; set; }

        // Navigation properties
        public List<Course> Courses { get; set; } = new();
    }
}