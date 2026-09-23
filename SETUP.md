# Online Course Management System - Setup & Development Guide

Welcome! This guide helps each team member get started with their specific phase.

---

## 🚀 Initial Setup (Everyone)

### Prerequisites
- **.NET 8 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Visual Studio Code** (or Visual Studio 2022)
- **Git**

### First-Time Setup

```bash
# Clone repository
git clone <repo-url>
cd Online-Course-Management

# Restore NuGet packages
dotnet restore

# Build solution
dotnet build
```

---

## 📋 Phase-Specific Tasks

### Phase 1: Database Setup & Project Foundation
**Owner:** Ashna Shrestha

#### Tasks
1. **Database Design** ✓ (Complete)
   - Students, Instructors, Courses, Enrollments
   - Lessons, Assignments, Results tables

2. **EF Core Configuration** ✓ (Complete)
   - ApplicationDbContext created
   - All relationships defined
   - Migration configuration ready

3. **Next Steps**
   ```bash
   # Add EF Core tools
   dotnet tool install --global dotnet-ef
   
   # Create initial migration
   cd OnlineCourseManagement
   dotnet ef migrations add InitialCreate --project .
   
   # Update database
   dotnet ef database update
   ```

4. **Connection String**
   - Edit `appsettings.json` in Server project
   - Configure SQL Server or SQLite connection string

#### Key Files
- `OnlineCourseManagement/Data/ApplicationDbContext.cs`
- `OnlineCourseManagement/Models/*.cs`

---

### Phase 2: Course & Instructor Management
**Owner:** Babita Thami

#### Tasks
1. **Course Management API Endpoints**
   - Create CoursesController in Server project
   - Implement POST (add), PUT (edit), DELETE, GET endpoints

2. **Instructor Management API Endpoints**
   - Create InstructorsController in Server project
   - CRUD operations for instructors

3. **Course Search Functionality**
   - Filter by: Title, Instructor, Level
   - Sort by: Date Created, Start Date

#### Implementation Path
```
Server Project (to be created):
├── Controllers/
│   ├── CoursesController.cs
│   └── InstructorsController.cs
├── Services/
│   ├── ICourseService.cs
│   └── CourseService.cs
└── appsettings.json
```

#### Dependencies
- Requires Phase 1 to be complete (Database ready)

#### Key Files to Create
- `CourseService.cs` implementation (server-side)
- `InstructorService.cs` implementation
- API Controllers

---

### Phase 3: Student Registration & Enrollment
**Owner:** Beni Raj Karki

#### Tasks
1. **Student Registration**
   - Implement student signup logic
   - Password hashing and security
   - Email validation
   - Student profile management

2. **Student Authentication**
   - Implement login functionality
   - JWT token generation (optional)
   - Session management

3. **Course Enrollment**
   - Student enrolls in available courses
   - Check maximum capacity
   - Enrollment status tracking

4. **Enrollment Validation Logic**
   - Validate student eligibility
   - Check prerequisites (optional)
   - Prevent duplicate enrollments

#### Implementation Path
```
Server Project:
├── Controllers/
│   ├── StudentsController.cs
│   └── EnrollmentsController.cs
├── Services/
│   ├── IAuthService.cs
│   ├── AuthService.cs
│   ├── IStudentService.cs
│   └── StudentService.cs
└── Utilities/
    └── PasswordHasher.cs
```

#### Pages to Update
- `Pages/StudentRegistration.razor` (create new)
- `Pages/CourseEnrollment.razor` (create new)

#### Dependencies
- Requires Phase 1 (Database)
- Requires Phase 2 (Courses exist)

---

### Phase 4: Learning Content, Results & Dashboard
**Owner:** Ashna, Beni and Babita

#### Tasks
1. **Lessons Management**
   - Add lessons under each course
   - Manage lesson ordering
   - Upload lesson materials (links, videos)

2. **Assignments Management**
   - Create assignments for courses
   - Set due dates and marks
   - Assignment types: Quiz, Project, Essay, Practical

3. **Results Recording**
   - Record student assignment grades
   - Add feedback/comments
   - Track submission status

4. **Student Learning Dashboard**
   - Display enrolled courses
   - Show completed lessons
   - List pending assignments
   - Display results and performance

#### Implementation Path
```
Server Project:
├── Controllers/
│   ├── LessonsController.cs
│   ├── AssignmentsController.cs
│   └── ResultsController.cs
└── Services/
    ├── ILessonService.cs
    ├── LessonService.cs
    ├── IAssignmentService.cs
    ├── AssignmentService.cs
    ├── IResultService.cs
    └── ResultService.cs
```

#### Pages to Create
- `Pages/Lessons.razor`
- `Pages/Assignments.razor`
- `Pages/StudentDashboard.razor`
- `Pages/Results.razor`

#### Dependencies
- Requires Phase 1 (Database)
- Requires Phase 3 (Student enrollment)

---

### Phase 5: Testing & Deployment
**Owner:** All Members

#### Tasks
1. **Unit Testing**
   - Test each module independently
   - Create test cases for services

2. **Integration Testing**
   - Test workflow across modules
   - End-to-end testing

3. **Bug Fixing**
   - Fix issues found during testing
   - Performance optimization

4. **GitHub Upload & Delivery**
   - Final code review
   - Push to main branch
   - Create release

#### Test Project Structure
```
Tests/
├── OnlineCourseManagement.Tests/
├── CourseServiceTests.cs
├── StudentServiceTests.cs
└── EnrollmentServiceTests.cs
```

---

## 📁 Project Structure Summary

```
Online-Course-Management/
├── OnlineCourseManagement/                      # Blazor WebAssembly project
│   ├── Models/                                   # Database entities
│   ├── DTOs/                                     # Data transfer objects
│   ├── Interfaces/                               # Service interfaces
│   ├── Data/ApplicationDbContext.cs              # EF Core context
│   ├── Pages/                                    # Razor pages
│   ├── Shared/                                   # MainLayout, NavMenu
│   ├── Services/                                 # Client services
│   ├── Properties/                               # launchSettings.json
│   └── wwwroot/                                  # Static files
│
├── OnlineCourseManagement.Server/                # Backend Web API (Phase 2+)
│
├── OnlineCourseManagement.sln                    # Solution file
├── README.md                                     # Project overview
└── SETUP.md                                      # This file
```

---

## 🔧 Development Workflow

### For Each Phase Owner:

1. **Create a feature branch**
   ```bash
   git checkout -b phase-X-feature
   ```

2. **Make your changes**
   - Follow the structure in this guide
   - Write clean, documented code
   - Comment your code with phase owner info

3. **Test your work**
   ```bash
   dotnet build
   dotnet test (if tests exist)
   ```

4. **Commit with meaningful messages**
   ```bash
   git commit -m "Phase X: Feature description"
   ```

5. **Push to repository**
   ```bash
   git push origin phase-X-feature
   ```

6. **Create Pull Request**
   - Link to relevant issues
   - Describe changes made
   - Request review from team

---

## 📚 Technology Stack

| Layer | Technology | Version |
|-------|-----------|---------|
| Frontend | Blazor WebAssembly | .NET 8 |
| Backend | ASP.NET Core | .NET 8 |
| Database | EF Core | 8.0 |
| Database | SQL Server / SQLite | Latest |
| Language | C# | Latest |

---

## 🐛 Common Issues & Solutions

### Issue: "Project not found" error
**Solution:** Run `dotnet restore` in the solution directory

### Issue: Database connection failed
**Solution:** Check `appsettings.json` connection string and ensure database server is running

### Issue: NuGet package conflicts
**Solution:** Delete `bin/` and `obj/` folders, then run `dotnet restore`

### Issue: EF Core migrations not working
**Solution:** Ensure you're in the Shared project when running migration commands

---

## 📞 Communication

- **Daily Stand-ups:** Share progress on Discord/Slack
- **Phase Dependencies:** Notify next phase when complete
- **Issues:** Create GitHub issues for blockers
- **Code Review:** Request review before merging

---

## ✅ Checklist

### Before Starting Your Phase
- [ ] Clone repository
- [ ] Run `dotnet restore` and `dotnet build`
- [ ] Read your phase requirements
- [ ] Check Phase 1 is complete (if dependent)
- [ ] Create feature branch

### During Development
- [ ] Follow code style and naming conventions
- [ ] Write XML documentation comments
- [ ] Test your features locally
- [ ] Update README if needed

### Before Submitting PR
- [ ] Code builds without errors
- [ ] All tests pass
- [ ] No merge conflicts
- [ ] PR description is clear
- [ ] Code review requested

---

## 🎓 Learning Resources

- [Blazor Documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [ASP.NET Core API](https://learn.microsoft.com/aspnet/core/web-api/)
- [C# Programming Guide](https://learn.microsoft.com/dotnet/csharp/fundamentals/)

---

**Last Updated:** September 2024
**Status:** Ready for Development
