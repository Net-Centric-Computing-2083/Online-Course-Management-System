using OnlineCourseManagement.Shared.Interfaces;
using OnlineCourseManagement.Shared.Models;

namespace OnlineCourseManagement.Client.Services
{
    /// <summary>
    /// Client-side service for Enrollment operations
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public class EnrollmentService : IEnrollmentService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/enrollments";

        public EnrollmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Enrollment>> GetStudentEnrollmentsAsync(int studentId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Enrollment>>($"{BaseUrl}/student/{studentId}") ?? new List<Enrollment>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching enrollments: {ex.Message}");
                return new List<Enrollment>();
            }
        }

        public async Task<List<Enrollment>> GetCourseEnrollmentsAsync(int courseId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Enrollment>>($"{BaseUrl}/course/{courseId}") ?? new List<Enrollment>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching course enrollments: {ex.Message}");
                return new List<Enrollment>();
            }
        }

        public async Task<int> EnrollStudentAsync(int studentId, int courseId)
        {
            try
            {
                var enrollmentRequest = new { StudentId = studentId, CourseId = courseId };
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, enrollmentRequest);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enrolling student: {ex.Message}");
                return 0;
            }
        }

        public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"{BaseUrl}/{enrollment.Id}", enrollment);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating enrollment: {ex.Message}");
            }
        }

        public async Task<bool> ValidateEnrollmentAsync(int studentId, int courseId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/validate?studentId={studentId}&courseId={courseId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating enrollment: {ex.Message}");
                return false;
            }
        }

        public async Task DropCourseAsync(int enrollmentId)
        {
            try
            {
                await _httpClient.DeleteAsync($"{BaseUrl}/{enrollmentId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error dropping course: {ex.Message}");
            }
        }
    }
}
