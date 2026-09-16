# Phase 2: Course & Instructor Management
**Owner:** Babita Thami

---

## Overview
Phase 2 implements the core business logic for managing courses and instructors, along with search functionality.

---

## Tasks

### 1. Course Management API (CRUD)

#### Endpoints to Implement
```
GET    /api/courses                 - Get all courses
GET    /api/courses/{id}            - Get course by ID
POST   /api/courses                 - Add new course
PUT    /api/courses/{id}            - Update course
DELETE /api/courses/{id}            - Delete course
GET    /api/courses/instructor/{id} - Get courses by instructor
```

#### Implementation Steps
1. Create `ICoursesRepository` interface
2. Create `CoursesRepository` implementation
3. Create `CoursesService` business logic
4. Create `CoursesController` API controller

#### Key Business Logic
- Validate course code uniqueness
- Check instructor exists before assigning
- Validate max students > 0
- Validate course dates (start < end)

### 2. Instructor Management API (CRUD)

#### Endpoints to Implement
```
GET    /api/instructors              - Get all instructors
GET    /api/instructors/{id}         - Get instructor by ID
POST   /api/instructors              - Add new instructor
PUT    /api/instructors/{id}         - Update instructor
DELETE /api/instructors/{id}         - Delete instructor
GET    /api/instructors/{id}/courses - Get courses by instructor
```

#### Implementation Steps
1. Create `IInstructorsRepository` interface
2. Create `InstructorsRepository` implementation
3. Create `InstructorsService` business logic
4. Create `InstructorsController` API controller

#### Key Business Logic
- Validate email uniqueness
- Hash password before storing
- Check for active courses before deletion

### 3. Course Search & Filtering

#### Search Features
- **By Title** - Case-insensitive search
- **By Instructor** - Filter by instructor name/ID
- **By Level** - Filter by difficulty level (Beginner, Intermediate, Advanced)
- **By Status** - Active/Inactive courses

#### Endpoint
```
GET /api/courses/search?title=...&level=...&instructorId=...
```

#### Implementation
1. Add `SearchCoursesAsync()` method in repository
2. Use LINQ for dynamic filtering
3. Support pagination (optional: limit, offset)

### 4. Blazor Components

#### Components to Create
- `Components/CourseForm.razor` - Add/Edit course
- `Components/CourseCard.razor` - Display course card
- `Components/InstructorForm.razor` - Add/Edit instructor
- `Components/SearchBar.razor` - Course search

#### Pages to Create
- `Pages/ManageCourses.razor` - Course management page
- `Pages/ManageInstructors.razor` - Instructor management page

---

## Project Structure

```
src/OnlineCourseManagement.Server/
├── Controllers/
│   ├── CoursesController.cs
│   └── InstructorsController.cs
├── Services/
│   ├── Interfaces/
│   │   ├── ICoursesService.cs
│   │   └── IInstructorsService.cs
│   ├── CoursesService.cs
│   └── InstructorsService.cs
├── Repositories/
│   ├── Interfaces/
│   │   ├── ICoursesRepository.cs
│   │   └── IInstructorsRepository.cs
│   ├── CoursesRepository.cs
│   └── InstructorsRepository.cs
└── Program.cs

src/OnlineCourseManagement.Client/
├── Pages/
│   ├── ManageCourses.razor
│   └── ManageInstructors.razor
└── Components/
    ├── CourseForm.razor
    ├── CourseCard.razor
    ├── InstructorForm.razor
    └── SearchBar.razor
```

---

## Database Dependencies

✓ Phase 1 must be complete with:
- Course table
- Instructor table
- Enrollment table (for relationship)

---

## API Testing

Use tools like Postman or curl to test:

```bash
# Get all courses
curl https://localhost:5001/api/courses

# Create new course
curl -X POST https://localhost:5001/api/courses \
  -H "Content-Type: application/json" \
  -d '{"title":"C# Basics","description":"...","code":"CS101",...}'

# Search courses
curl https://localhost:5001/api/courses/search?title=C%23
```

---

## Validation Rules

### Courses
- Title: Required, max 256 chars
- Code: Required, Unique, max 50 chars
- Description: Optional, max 1000 chars
- Duration: > 0 weeks
- MaxStudents: > 0
- Credits: 0 - 4.0
- Level: Beginner | Intermediate | Advanced

### Instructors
- FirstName: Required, max 100 chars
- LastName: Required, max 100 chars
- Email: Required, Unique, valid email format
- Specialization: Optional, max 256 chars
- JoinDate: Cannot be future date

---

## Dependency Injection Setup

In `Program.cs`:
```csharp
builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IInstructorsService, InstructorsService>();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<IInstructorsRepository, InstructorsRepository>();
```

---

## Error Handling

Return appropriate HTTP status codes:
- 200 OK - Success
- 201 Created - Resource created
- 400 Bad Request - Validation error
- 404 Not Found - Resource not found
- 500 Internal Server Error - Server error

---

## Phase Completion Checklist

- [ ] CoursesController implemented (all endpoints)
- [ ] InstructorsController implemented (all endpoints)
- [ ] Course search functionality working
- [ ] Repository pattern implemented
- [ ] Service layer implemented
- [ ] Error handling in place
- [ ] API tested with Postman/curl
- [ ] Blazor components created
- [ ] Pages integrated with API
- [ ] Code reviewed and documented

---

## Next Phase

**Phase 3 (Beni Raj Karki)** will depend on:
- ✓ Courses API working
- ✓ Instructors API working
- ⏳ Course management fully operational

Notify Beni once this phase is complete and tested.

---

## Tips

1. Use repository pattern for data access
2. Implement validation in both service and controller
3. Use async/await for all database operations
4. Add proper logging
5. Document API endpoints
6. Use DTOs for API requests/responses

---

**Estimated Time:** 1-2 weeks
**Status:** Not Started - Waiting for Phase 1 Completion
