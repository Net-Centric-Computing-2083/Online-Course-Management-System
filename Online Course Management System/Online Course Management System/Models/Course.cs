using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_Management_System.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        // Foreign key
        public int InstructorId { get; set; }

        [ForeignKey(nameof(InstructorId))]
        public Instructor? Instructor { get; set; }

        // Navigation properties
        public List<Enrollment> Enrollments { get; set; } = new();
        public List<Lesson> Lessons { get; set; } = new();
        public List<Assignment> Assignments { get; set; } = new();
    }
}