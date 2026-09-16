using OnlineCourseManagement.Interfaces;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory implementation of Result (grading) operations, backed by AppDataStore.
    /// Author: Bhumika Tamang (Phase 4)
    /// </summary>
    public class ResultService : IResultService
    {
        private readonly AppDataStore _store;

        public ResultService(AppDataStore store)
        {
            _store = store;
        }

        public Task<List<Result>> GetResultsByAssignmentAsync(int assignmentId)
        {
            var result = _store.Results.Where(r => r.AssignmentId == assignmentId).ToList();
            return Task.FromResult(result);
        }

        public Task<List<Result>> GetResultsByStudentAsync(int studentId)
        {
            var result = _store.Results.Where(r => r.StudentId == studentId).ToList();
            return Task.FromResult(result);
        }

        public Task<int> RecordResultAsync(Result result)
        {
            var entity = _store.Results.FirstOrDefault(r => r.StudentId == result.StudentId && r.AssignmentId == result.AssignmentId);
            if (entity == null)
            {
                result.Id = _store.NextResultId();
                result.SubmissionDate = DateTime.Today;
                result.GradedDate = DateTime.Today;
                result.IsSubmitted = true;
                result.SubmissionUrl ??= string.Empty;
                _store.Results.Add(result);
                return Task.FromResult(result.Id);
            }

            entity.MarksObtained = result.MarksObtained;
            entity.Feedback = result.Feedback;
            entity.GradedDate = DateTime.Today;
            return Task.FromResult(entity.Id);
        }

        public Task DeleteResultAsync(int id)
        {
            var entity = _store.Results.FirstOrDefault(r => r.Id == id);
            if (entity != null)
            {
                _store.Results.Remove(entity);
            }
            return Task.CompletedTask;
        }
    }
}
