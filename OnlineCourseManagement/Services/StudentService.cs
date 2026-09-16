using OnlineCourseManagement.DTOs;
using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory implementation of Student operations, backed by AppDataStore.
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly AppDataStore _store;

        public StudentService(AppDataStore store)
        {
            _store = store;
        }

        public Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            var result = _store.Students.Select(ToDto).OrderBy(s => s.LastName).ToList();
            return Task.FromResult(result);
        }

        public Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            var student = _store.Students.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(student == null ? null : ToDto(student));
        }

        public Task<int> RegisterStudentAsync(StudentDTO student)
        {
            if (_store.Students.Any(s => s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.FromResult(0);
            }

            var entity = new Student
            {
                Id = _store.NextStudentId(),
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                PasswordHash = "demo", // Phase 3: replace with real password hashing once wired to a backend
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                EnrollmentDate = DateTime.Today,
                IsActive = true
            };
            _store.Students.Add(entity);
            return Task.FromResult(entity.Id);
        }

        public Task UpdateStudentAsync(StudentDTO student)
        {
            var entity = _store.Students.FirstOrDefault(s => s.Id == student.Id);
            if (entity != null)
            {
                entity.FirstName = student.FirstName;
                entity.LastName = student.LastName;
                entity.Email = student.Email;
                entity.PhoneNumber = student.PhoneNumber;
                entity.DateOfBirth = student.DateOfBirth;
                entity.Address = student.Address;
            }
            return Task.CompletedTask;
        }

        public Task DeleteStudentAsync(int id)
        {
            var entity = _store.Students.FirstOrDefault(s => s.Id == id);
            if (entity != null)
            {
                _store.Students.Remove(entity);
                _store.Enrollments.RemoveAll(e => e.StudentId == id);
                _store.Results.RemoveAll(r => r.StudentId == id);
            }
            return Task.CompletedTask;
        }

        public Task<StudentDTO> LoginAsync(string email, string password)
        {
            // Demo-only lookup by email. Real authentication (password hashing and
            // verification) will be added once this is wired up to a backend in Phase 3.
            var student = _store.Students.FirstOrDefault(s => s.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(student == null ? null : ToDto(student));
        }

        private static StudentDTO ToDto(Student s) => new StudentDTO
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            PhoneNumber = s.PhoneNumber,
            DateOfBirth = s.DateOfBirth,
            Address = s.Address,
            EnrollmentDate = s.EnrollmentDate,
            IsActive = s.IsActive
        };
    }
}
