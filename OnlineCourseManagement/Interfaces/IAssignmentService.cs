using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Interfaces
{
    /// <summary>
    /// Interface for Assignment Service
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAssignmentsByCourseAsync(int courseId);
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task<int> AddAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(int id);
    }
}
