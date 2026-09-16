using OnlineCourseManagement.DTOs;

namespace OnlineCourseManagement.Interfaces
{
    /// <summary>
    /// Interface for Instructor Service
    /// Author: Babita Thami (Phase 2)
    /// </summary>
    public interface IInstructorService
    {
        Task<List<InstructorDTO>> GetAllInstructorsAsync();
        Task<InstructorDTO> GetInstructorByIdAsync(int id);
        Task<int> AddInstructorAsync(InstructorDTO instructor);
        Task UpdateInstructorAsync(InstructorDTO instructor);
        Task<bool> DeleteInstructorAsync(int id);
    }
}
