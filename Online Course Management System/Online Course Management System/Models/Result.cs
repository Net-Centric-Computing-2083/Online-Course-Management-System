using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Course_Management_System.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }

        // Foreign keys
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

        public int AssignmentId { get; set; }
        [ForeignKey(nameof(AssignmentId))]
        public Assignment? Assignment { get; set; }

        public int Score { get; set; }

        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;

        public bool IsGraded { get; set; } = false;
    }
}