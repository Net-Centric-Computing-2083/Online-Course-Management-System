using OnlineCourseManagement.DTOs;
using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory implementation of Course operations, backed by AppDataStore.
    /// Author: Babita Thami (Phase 2)
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly AppDataStore _store;

        public CourseService(AppDataStore store)
        {
            _store = store;
        }

        public Task<List<CourseDTO>> GetAllCoursesAsync()
        {
            var result = _store.Courses.Select(ToDto).OrderBy(c => c.Title).ToList();
            return Task.FromResult(result);
        }

        public Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = _store.Courses.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(course == null ? null : ToDto(course));
        }

        public Task<int> AddCourseAsync(CourseDTO course)
        {
            var entity = new Course
            {
                Id = _store.NextCourseId(),
                Title = course.Title,
                Description = course.Description,
                Code = course.Code,
                InstructorId = course.InstructorId,
                Duration = course.Duration,
                MaxStudents = course.MaxStudents,
                Credits = course.Credits,
                Level = course.Level,
                CreatedDate = DateTime.Today,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                IsActive = true
            };
            _store.Courses.Add(entity);
            return Task.FromResult(entity.Id);
        }

        public Task UpdateCourseAsync(CourseDTO course)
        {
            var entity = _store.Courses.FirstOrDefault(c => c.Id == course.Id);
            if (entity != null)
            {
                entity.Title = course.Title;
                entity.Description = course.Description;
                entity.Code = course.Code;
                entity.InstructorId = course.InstructorId;
                entity.Duration = course.Duration;
                entity.MaxStudents = course.MaxStudents;
                entity.Credits = course.Credits;
                entity.Level = course.Level;
                entity.StartDate = course.StartDate;
                entity.EndDate = course.EndDate;
            }
            return Task.CompletedTask;
        }

        public Task DeleteCourseAsync(int id)
        {
            var entity = _store.Courses.FirstOrDefault(c => c.Id == id);
            if (entity != null)
            {
                _store.Courses.Remove(entity);
                _store.Enrollments.RemoveAll(e => e.CourseId == id);
                _store.Lessons.RemoveAll(l => l.CourseId == id);
                _store.Assignments.RemoveAll(a => a.CourseId == id);
            }
            return Task.CompletedTask;
        }

        public Task<List<CourseDTO>> SearchCoursesAsync(string searchTerm)
        {
            var term = (searchTerm ?? string.Empty).Trim();
            IEnumerable<Course> query = _store.Courses;
            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(c =>
                    c.Title.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    c.Code.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    c.Level.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    GetInstructorName(c.InstructorId).Contains(term, StringComparison.OrdinalIgnoreCase));
            }
            var result = query.Select(ToDto).OrderBy(c => c.Title).ToList();
            return Task.FromResult(result);
        }

        public Task<List<CourseDTO>> GetCoursesByInstructorAsync(int instructorId)
        {
            var result = _store.Courses.Where(c => c.InstructorId == instructorId).Select(ToDto).ToList();
            return Task.FromResult(result);
        }

        private string GetInstructorName(int instructorId)
        {
            var instructor = _store.Instructors.FirstOrDefault(i => i.Id == instructorId);
            return instructor == null ? "Unassigned" : $"{instructor.FirstName} {instructor.LastName}";
        }

        private CourseDTO ToDto(Course c) => new CourseDTO
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Code = c.Code,
            InstructorId = c.InstructorId,
            InstructorName = GetInstructorName(c.InstructorId),
            Duration = c.Duration,
            MaxStudents = c.MaxStudents,
            Credits = c.Credits,
            Level = c.Level,
            StartDate = c.StartDate ?? DateTime.MinValue,
            EndDate = c.EndDate ?? DateTime.MinValue,
            EnrolledStudents = _store.Enrollments.Count(e => e.CourseId == c.Id && e.Status != "Dropped")
        };
    }
}
