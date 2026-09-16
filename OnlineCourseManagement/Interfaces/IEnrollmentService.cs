using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Interfaces
{
    /// <summary>
    /// Interface for Enrollment Service
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public interface IEnrollmentService
    {
        Task<List<Enrollment>> GetStudentEnrollmentsAsync(int studentId);
        Task<List<Enrollment>> GetCourseEnrollmentsAsync(int courseId);
        Task<int> EnrollStudentAsync(int studentId, int courseId);
        Task UpdateEnrollmentAsync(Enrollment enrollment);
        Task<bool> ValidateEnrollmentAsync(int studentId, int courseId);
        Task DropCourseAsync(int enrollmentId);
    }
}
