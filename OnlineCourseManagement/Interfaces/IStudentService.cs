using OnlineCourseManagement.DTOs;

namespace OnlineCourseManagement.Interfaces
{
    /// <summary>
    /// Interface for Student Service
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<int> RegisterStudentAsync(StudentDTO student);
        Task UpdateStudentAsync(StudentDTO student);
        Task DeleteStudentAsync(int id);
        Task<StudentDTO> LoginAsync(string email, string password);
    }
}
