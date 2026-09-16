using OnlineCourseManagement.DTOs;
using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory implementation of Instructor operations, backed by AppDataStore.
    /// Author: Babita Thami (Phase 2)
    /// </summary>
    public class InstructorService : IInstructorService
    {
        private readonly AppDataStore _store;

        public InstructorService(AppDataStore store)
        {
            _store = store;
        }

        public Task<List<InstructorDTO>> GetAllInstructorsAsync()
        {
            var result = _store.Instructors.Select(ToDto).OrderBy(i => i.LastName).ToList();
            return Task.FromResult(result);
        }

        public Task<InstructorDTO> GetInstructorByIdAsync(int id)
        {
            var instructor = _store.Instructors.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(instructor == null ? null : ToDto(instructor));
        }

        public Task<int> AddInstructorAsync(InstructorDTO instructor)
        {
            if (_store.Instructors.Any(i => i.Email.Equals(instructor.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.FromResult(0);
            }

            var entity = new Instructor
            {
                Id = _store.NextInstructorId(),
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                PasswordHash = "demo",
                Specialization = instructor.Specialization,
                Bio = instructor.Bio,
                JoinDate = DateTime.Today,
                IsActive = true
            };
            _store.Instructors.Add(entity);
            return Task.FromResult(entity.Id);
        }

        public Task UpdateInstructorAsync(InstructorDTO instructor)
        {
            var entity = _store.Instructors.FirstOrDefault(i => i.Id == instructor.Id);
            if (entity != null)
            {
                entity.FirstName = instructor.FirstName;
                entity.LastName = instructor.LastName;
                entity.Email = instructor.Email;
                entity.PhoneNumber = instructor.PhoneNumber;
                entity.Specialization = instructor.Specialization;
                entity.Bio = instructor.Bio;
            }
            return Task.CompletedTask;
        }

        public Task<bool> DeleteInstructorAsync(int id)
        {
            bool hasCourses = _store.Courses.Any(c => c.InstructorId == id);
            if (hasCourses)
            {
                return Task.FromResult(false);
            }

            var entity = _store.Instructors.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                _store.Instructors.Remove(entity);
            }
            return Task.FromResult(true);
        }

        private static InstructorDTO ToDto(Instructor i) => new InstructorDTO
        {
            Id = i.Id,
            FirstName = i.FirstName,
            LastName = i.LastName,
            Email = i.Email,
            PhoneNumber = i.PhoneNumber,
            Specialization = i.Specialization,
            Bio = i.Bio,
            JoinDate = i.JoinDate,
            IsActive = i.IsActive
        };
    }
}
