using OnlineCourseManagement.Shared.DTOs;
using OnlineCourseManagement.Shared.Models;

namespace OnlineCourseManagement.Shared.Interfaces
{
    /// <summary>
    /// Interface for Course Service
    /// Author: Babita Thami (Phase 2)
    /// </summary>
    public interface ICourseService
    {
        Task<List<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO> GetCourseByIdAsync(int id);
        Task<int> AddCourseAsync(CourseDTO course);
        Task UpdateCourseAsync(CourseDTO course);
        Task DeleteCourseAsync(int id);
        Task<List<CourseDTO>> SearchCoursesAsync(string searchTerm);
        Task<List<CourseDTO>> GetCoursesByInstructorAsync(int instructorId);
    }
}
