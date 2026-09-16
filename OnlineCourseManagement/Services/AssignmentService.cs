using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory implementation of Assignment operations, backed by AppDataStore.
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public class AssignmentService : IAssignmentService
    {
        private readonly AppDataStore _store;

        public AssignmentService(AppDataStore store)
        {
            _store = store;
        }

        public Task<List<Assignment>> GetAssignmentsByCourseAsync(int courseId)
        {
            var result = _store.Assignments.Where(a => a.CourseId == courseId).OrderBy(a => a.DueDate).ToList();
            return Task.FromResult(result);
        }

        public Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            var assignment = _store.Assignments.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(assignment);
        }

        public Task<int> AddAssignmentAsync(Assignment assignment)
        {
            assignment.Id = _store.NextAssignmentId();
            assignment.CreatedDate = DateTime.Today;
            _store.Assignments.Add(assignment);
            return Task.FromResult(assignment.Id);
        }

        public Task UpdateAssignmentAsync(Assignment assignment)
        {
            var entity = _store.Assignments.FirstOrDefault(a => a.Id == assignment.Id);
            if (entity != null)
            {
                entity.Title = assignment.Title;
                entity.Description = assignment.Description;
                entity.DueDate = assignment.DueDate;
                entity.MaxMarks = assignment.MaxMarks;
                entity.AssignmentType = assignment.AssignmentType;
                entity.IsPublished = assignment.IsPublished;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAssignmentAsync(int id)
        {
            var entity = _store.Assignments.FirstOrDefault(a => a.Id == id);
            if (entity != null)
            {
                _store.Assignments.Remove(entity);
                _store.Results.RemoveAll(r => r.AssignmentId == id);
            }
            return Task.CompletedTask;
        }
    }
}
