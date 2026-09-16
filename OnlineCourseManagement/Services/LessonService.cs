using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory implementation of Lesson operations, backed by AppDataStore.
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public class LessonService : ILessonService
    {
        private readonly AppDataStore _store;

        public LessonService(AppDataStore store)
        {
            _store = store;
        }

        public Task<List<Lesson>> GetLessonsByCourseAsync(int courseId)
        {
            var result = _store.Lessons.Where(l => l.CourseId == courseId).OrderBy(l => l.OrderNumber).ToList();
            return Task.FromResult(result);
        }

        public Task<Lesson> GetLessonByIdAsync(int id)
        {
            var lesson = _store.Lessons.FirstOrDefault(l => l.Id == id);
            return Task.FromResult(lesson);
        }

        public Task<int> AddLessonAsync(Lesson lesson)
        {
            lesson.Id = _store.NextLessonId();
            lesson.CreatedDate = DateTime.Today;
            if (lesson.OrderNumber <= 0)
            {
                lesson.OrderNumber = _store.Lessons.Count(l => l.CourseId == lesson.CourseId) + 1;
            }
            _store.Lessons.Add(lesson);
            return Task.FromResult(lesson.Id);
        }

        public Task UpdateLessonAsync(Lesson lesson)
        {
            var entity = _store.Lessons.FirstOrDefault(l => l.Id == lesson.Id);
            if (entity != null)
            {
                entity.Title = lesson.Title;
                entity.Description = lesson.Description;
                entity.Content = lesson.Content;
                entity.VideoUrl = lesson.VideoUrl;
                entity.DurationMinutes = lesson.DurationMinutes;
                entity.OrderNumber = lesson.OrderNumber;
                entity.IsPublished = lesson.IsPublished;
                entity.UpdatedDate = DateTime.Today;
            }
            return Task.CompletedTask;
        }

        public Task DeleteLessonAsync(int id)
        {
            var entity = _store.Lessons.FirstOrDefault(l => l.Id == id);
            if (entity != null)
            {
                _store.Lessons.Remove(entity);
                _store.LessonCompletions.RemoveAll(c => c.LessonId == id);
            }
            return Task.CompletedTask;
        }

        public Task MarkLessonCompleteAsync(int studentId, int lessonId, bool isComplete)
        {
            var key = (StudentId: studentId, LessonId: lessonId);
            bool exists = _store.LessonCompletions.Contains(key);
            if (isComplete && !exists)
            {
                _store.LessonCompletions.Add(key);
            }
            else if (!isComplete && exists)
            {
                _store.LessonCompletions.Remove(key);
            }
            return Task.CompletedTask;
        }

        public Task<HashSet<int>> GetCompletedLessonIdsAsync(int studentId, int courseId)
        {
            var lessonIdsInCourse = _store.Lessons.Where(l => l.CourseId == courseId).Select(l => l.Id).ToHashSet();
            var completed = _store.LessonCompletions
                .Where(c => c.StudentId == studentId && lessonIdsInCourse.Contains(c.LessonId))
                .Select(c => c.LessonId)
                .ToHashSet();
            return Task.FromResult(completed);
        }
    }
}
