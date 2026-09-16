using System.Net.Http.Json;
using OnlineCourseManagement.DTOs;
using OnlineCourseManagement.Interfaces;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// Client-side service for Course operations
    /// Author: Babita Thami (Phase 2)
    /// </summary>
    public class CourseService : ICourseService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/courses";

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CourseDTO>> GetAllCoursesAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<CourseDTO>>(BaseUrl) ?? new List<CourseDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching courses: {ex.Message}");
                return new List<CourseDTO>();
            }
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CourseDTO>($"{BaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching course {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<int> AddCourseAsync(CourseDTO course)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BaseUrl, course);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding course: {ex.Message}");
                return 0;
            }
        }

        public async Task UpdateCourseAsync(CourseDTO course)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"{BaseUrl}/{course.Id}", course);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating course: {ex.Message}");
            }
        }

        public async Task DeleteCourseAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
            }
        }

        public async Task<List<CourseDTO>> SearchCoursesAsync(string searchTerm)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<CourseDTO>>($"{BaseUrl}/search?term={searchTerm}") ?? new List<CourseDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching courses: {ex.Message}");
                return new List<CourseDTO>();
            }
        }

        public async Task<List<CourseDTO>> GetCoursesByInstructorAsync(int instructorId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<CourseDTO>>($"{BaseUrl}/instructor/{instructorId}") ?? new List<CourseDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching instructor courses: {ex.Message}");
                return new List<CourseDTO>();
            }
        }
    }
}
