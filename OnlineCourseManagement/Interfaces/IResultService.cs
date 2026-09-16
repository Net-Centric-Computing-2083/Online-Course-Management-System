using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Interfaces
{
    /// <summary>
    /// Interface for Result (grading) Service
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public interface IResultService
    {
        Task<List<Result>> GetResultsByAssignmentAsync(int assignmentId);
        Task<List<Result>> GetResultsByStudentAsync(int studentId);
        Task<int> RecordResultAsync(Result result);
        Task DeleteResultAsync(int id);
    }
}
