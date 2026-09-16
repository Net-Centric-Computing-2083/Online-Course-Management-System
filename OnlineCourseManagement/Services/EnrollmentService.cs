using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory implementation of Enrollment operations, backed by AppDataStore.
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDataStore _store;

        public EnrollmentService(AppDataStore store)
        {
            _store = store;
        }

        public Task<List<Enrollment>> GetStudentEnrollmentsAsync(int studentId)
        {
            var result = _store.Enrollments.Where(e => e.StudentId == studentId).ToList();
            return Task.FromResult(result);
        }

        public Task<List<Enrollment>> GetCourseEnrollmentsAsync(int courseId)
        {
            var result = _store.Enrollments.Where(e => e.CourseId == courseId).ToList();
            return Task.FromResult(result);
        }

        public async Task<int> EnrollStudentAsync(int studentId, int courseId)
        {
            if (!await ValidateEnrollmentAsync(studentId, courseId))
            {
                return 0;
            }

            var entity = new Enrollment
            {
                Id = _store.NextEnrollmentId(),
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Today,
                Status = "Active",
                Progress = 0,
                GPA = 0,
                IsApproved = true
            };
            _store.Enrollments.Add(entity);
            return entity.Id;
        }

        public Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            var entity = _store.Enrollments.FirstOrDefault(e => e.Id == enrollment.Id);
            if (entity != null)
            {
                entity.Status = enrollment.Status;
                entity.Progress = enrollment.Progress;
                entity.GPA = enrollment.GPA;
            }
            return Task.CompletedTask;
        }

        public Task<bool> ValidateEnrollmentAsync(int studentId, int courseId)
        {
            var student = _store.Students.FirstOrDefault(s => s.Id == studentId);
            var course = _store.Courses.FirstOrDefault(c => c.Id == courseId);
            if (student == null || !student.IsActive || course == null || !course.IsActive)
            {
                return Task.FromResult(false);
            }

            bool alreadyEnrolled = _store.Enrollments.Any(e =>
                e.StudentId == studentId && e.CourseId == courseId && e.Status != "Dropped");
            if (alreadyEnrolled)
            {
                return Task.FromResult(false);
            }

            int activeCount = _store.Enrollments.Count(e => e.CourseId == courseId && e.Status != "Dropped");
            if (activeCount >= course.MaxStudents)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public Task DropCourseAsync(int enrollmentId)
        {
            var entity = _store.Enrollments.FirstOrDefault(e => e.Id == enrollmentId);
            if (entity != null)
            {
                entity.Status = "Dropped";
            }
            return Task.CompletedTask;
        }
    }
}
