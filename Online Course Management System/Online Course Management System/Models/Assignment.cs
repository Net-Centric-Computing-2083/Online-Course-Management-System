using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_Management_System.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public int MaxScore { get; set; } = 100;

        // Foreign key
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }

        // Navigation
        public List<Result> Results { get; set; } = new();
    }
}