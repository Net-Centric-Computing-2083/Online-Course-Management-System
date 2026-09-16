using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Services
{
    /// <summary>
    /// In-memory, single-source-of-truth data store for the Blazor WebAssembly demo.
    /// The UI is fully interactive against this store so every module (Courses,
    /// Instructors, Students, Enrollment, Lessons, Assignments, Results, Dashboard)
    /// works end-to-end in the browser without a backend.
    ///
    /// This is intentionally temporary: once the OnlineCourseManagement.Server Web
    /// API and the real EF Core database (see Data/ApplicationDbContext.cs) are
    /// wired up, the I*Service implementations in this folder should be swapped
    /// for HttpClient-based versions that call the API instead of this store.
    /// Data here resets whenever the browser tab is refreshed.
    /// </summary>
    public class AppDataStore
    {
        private int _studentId;
        private int _instructorId;
        private int _courseId;
        private int _enrollmentId;
        private int _lessonId;
        private int _assignmentId;
        private int _resultId;

        public List<Student> Students { get; } = new();
        public List<Instructor> Instructors { get; } = new();
        public List<Course> Courses { get; } = new();
        public List<Enrollment> Enrollments { get; } = new();
        public List<Lesson> Lessons { get; } = new();
        public List<Assignment> Assignments { get; } = new();
        public List<Result> Results { get; } = new();

        /// <summary>Tracks which student has completed which lesson (simple join, no separate model).</summary>
        public List<(int StudentId, int LessonId)> LessonCompletions { get; } = new();

        public AppDataStore()
        {
            Seed();
        }

        public int NextStudentId() => ++_studentId;
        public int NextInstructorId() => ++_instructorId;
        public int NextCourseId() => ++_courseId;
        public int NextEnrollmentId() => ++_enrollmentId;
        public int NextLessonId() => ++_lessonId;
        public int NextAssignmentId() => ++_assignmentId;
        public int NextResultId() => ++_resultId;

        private void Seed()
        {
            var ashna = new Instructor { Id = NextInstructorId(), FirstName = "Ashna", LastName = "Shrestha", Email = "ashna@ocms.edu", PhoneNumber = "980-000-0001", Specialization = "Databases & Backend", Bio = "Database design and systems specialist.", JoinDate = DateTime.Today.AddYears(-2), IsActive = true };
            var babita = new Instructor { Id = NextInstructorId(), FirstName = "Babita", LastName = "Thami", Email = "babita@ocms.edu", PhoneNumber = "980-000-0002", Specialization = "Web Development", Bio = "Full-stack web developer focused on Blazor.", JoinDate = DateTime.Today.AddYears(-3), IsActive = true };
            var beni = new Instructor { Id = NextInstructorId(), FirstName = "Beni Raj", LastName = "Karki", Email = "beni@ocms.edu", PhoneNumber = "980-000-0003", Specialization = "Application Security", Bio = "Enrollment systems and application security.", JoinDate = DateTime.Today.AddYears(-1), IsActive = true };
            Instructors.AddRange(new[] { ashna, babita, beni });

            var c1 = new Course { Id = NextCourseId(), Title = "Introduction to C#", Code = "CS101", Description = "Learn the fundamentals of the C# programming language.", InstructorId = babita.Id, Duration = 8, MaxStudents = 30, Credits = 3, Level = "Beginner", CreatedDate = DateTime.Today.AddMonths(-2), StartDate = DateTime.Today.AddDays(-10), EndDate = DateTime.Today.AddDays(46), IsActive = true };
            var c2 = new Course { Id = NextCourseId(), Title = "ASP.NET Core & Blazor", Code = "CS204", Description = "Build modern interactive web apps with Blazor WebAssembly.", InstructorId = babita.Id, Duration = 10, MaxStudents = 25, Credits = 4, Level = "Intermediate", CreatedDate = DateTime.Today.AddMonths(-1), StartDate = DateTime.Today.AddDays(-3), EndDate = DateTime.Today.AddDays(67), IsActive = true };
            var c3 = new Course { Id = NextCourseId(), Title = "Database Design with EF Core", Code = "CS210", Description = "Relational database design and Entity Framework Core.", InstructorId = ashna.Id, Duration = 6, MaxStudents = 20, Credits = 3, Level = "Intermediate", CreatedDate = DateTime.Today.AddMonths(-1), StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(42), IsActive = true };
            Courses.AddRange(new[] { c1, c2, c3 });

            var sita = new Student { Id = NextStudentId(), FirstName = "Sita", LastName = "Gurung", Email = "sita@student.edu", PhoneNumber = "981-111-1111", PasswordHash = "demo", DateOfBirth = new DateTime(2002, 5, 10), Address = "Kathmandu", EnrollmentDate = DateTime.Today.AddMonths(-2), IsActive = true };
            var ram = new Student { Id = NextStudentId(), FirstName = "Ram", LastName = "Thapa", Email = "ram@student.edu", PhoneNumber = "982-222-2222", PasswordHash = "demo", DateOfBirth = new DateTime(2001, 8, 21), Address = "Pokhara", EnrollmentDate = DateTime.Today.AddMonths(-1), IsActive = true };
            Students.AddRange(new[] { sita, ram });

            Enrollments.Add(new Enrollment { Id = NextEnrollmentId(), StudentId = sita.Id, CourseId = c1.Id, EnrollmentDate = DateTime.Today.AddDays(-9), Status = "Active", Progress = 40, GPA = 0, IsApproved = true });
            Enrollments.Add(new Enrollment { Id = NextEnrollmentId(), StudentId = sita.Id, CourseId = c2.Id, EnrollmentDate = DateTime.Today.AddDays(-2), Status = "Active", Progress = 10, GPA = 0, IsApproved = true });
            Enrollments.Add(new Enrollment { Id = NextEnrollmentId(), StudentId = ram.Id, CourseId = c1.Id, EnrollmentDate = DateTime.Today.AddDays(-8), Status = "Active", Progress = 25, GPA = 0, IsApproved = true });

            var l1 = new Lesson { Id = NextLessonId(), CourseId = c1.Id, Title = "Getting Started with C#", Description = "Setting up your environment and writing your first program.", Content = "Welcome to C#!", OrderNumber = 1, VideoUrl = string.Empty, DurationMinutes = 30, CreatedDate = DateTime.Today.AddDays(-9), IsPublished = true };
            var l2 = new Lesson { Id = NextLessonId(), CourseId = c1.Id, Title = "Variables and Data Types", Description = "Understanding C#'s type system.", Content = "Types in C#...", OrderNumber = 2, VideoUrl = string.Empty, DurationMinutes = 45, CreatedDate = DateTime.Today.AddDays(-7), IsPublished = true };
            var l3 = new Lesson { Id = NextLessonId(), CourseId = c2.Id, Title = "Your First Blazor Component", Description = "Building and wiring up a component.", Content = "Components in Blazor...", OrderNumber = 1, VideoUrl = string.Empty, DurationMinutes = 40, CreatedDate = DateTime.Today.AddDays(-2), IsPublished = true };
            Lessons.AddRange(new[] { l1, l2, l3 });
            LessonCompletions.Add((sita.Id, l1.Id));

            var a1 = new Assignment { Id = NextAssignmentId(), CourseId = c1.Id, Title = "Quiz 1: C# Basics", Description = "Short quiz covering variables and data types.", DueDate = DateTime.Today.AddDays(5), MaxMarks = 20, AssignmentType = "Quiz", CreatedDate = DateTime.Today.AddDays(-5), IsPublished = true };
            var a2 = new Assignment { Id = NextAssignmentId(), CourseId = c2.Id, Title = "Project: Todo App", Description = "Build a small Todo application using Blazor.", DueDate = DateTime.Today.AddDays(14), MaxMarks = 100, AssignmentType = "Project", CreatedDate = DateTime.Today.AddDays(-1), IsPublished = true };
            Assignments.AddRange(new[] { a1, a2 });

            Results.Add(new Result { Id = NextResultId(), StudentId = sita.Id, AssignmentId = a1.Id, MarksObtained = 18, Feedback = "Great work!", SubmissionDate = DateTime.Today.AddDays(-1), GradedDate = DateTime.Today, IsSubmitted = true, SubmissionUrl = string.Empty });
        }
    }
}
