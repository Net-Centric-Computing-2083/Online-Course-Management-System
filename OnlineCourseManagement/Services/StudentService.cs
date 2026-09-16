using System.Net.Http.Json;
using OnlineCourseManagement.DTOs;
using OnlineCourseManagement.Interfaces;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// Client-side service for Student operations
    /// Author: Beni Raj Karki (Phase 3)
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/students";

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<StudentDTO>>(BaseUrl) ?? new List<StudentDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching students: {ex.Message}");
                return new List<StudentDTO>();
            }
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<StudentDTO>($"{BaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching student: {ex.Message}");
                return null;
            }
        }

        public async Task<int> RegisterStudentAsync(StudentDTO student)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/register", student);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering student: {ex.Message}");
                return 0;
            }
        }

        public async Task UpdateStudentAsync(StudentDTO student)
        {
            try
            {
                await _httpClient.PutAsJsonAsync($"{BaseUrl}/{student.Id}", student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student: {ex.Message}");
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
            }
        }

        public async Task<StudentDTO> LoginAsync(string email, string password)
        {
            try
            {
                var loginRequest = new { Email = email, Password = password };
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/login", loginRequest);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<StudentDTO>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");
                return null;
            }
        }
    }
}
