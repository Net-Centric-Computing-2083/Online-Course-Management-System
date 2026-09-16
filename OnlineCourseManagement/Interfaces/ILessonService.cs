using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Interfaces
{
    /// <summary>
    /// Interface for Lesson Service
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public interface ILessonService
    {
        Task<List<Lesson>> GetLessonsByCourseAsync(int courseId);
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<int> AddLessonAsync(Lesson lesson);
        Task UpdateLessonAsync(Lesson lesson);
        Task DeleteLessonAsync(int id);
        Task MarkLessonCompleteAsync(int studentId, int lessonId, bool isComplete);
        Task<HashSet<int>> GetCompletedLessonIdsAsync(int studentId, int courseId);
    }
}
