# Phase 3: Student Registration & Course Enrollment
**Owner:** Beni Raj Karki

---

## Overview
Phase 3 implements student management, authentication, and course enrollment functionality.

---

## Tasks

### 1. Student Registration & Authentication

#### Endpoints
```
POST   /api/students/register        - Register new student
POST   /api/students/login           - Login student
GET    /api/students                 - Get all students
GET    /api/students/{id}            - Get student by ID
PUT    /api/students/{id}            - Update student profile
DELETE /api/students/{id}            - Delete student account
POST   /api/students/{id}/password   - Change password
```

#### Registration Requirements
- Email validation (unique, valid format)
- Password requirements:
  - Minimum 8 characters
  - At least one uppercase letter
  - At least one number
  - At least one special character
- Confirm password match
- Date of birth validation

#### Implementation
1. Create `IPasswordHasher` utility
   - Use BCrypt or PBKDF2 for hashing
   - Never store plain text passwords

2. Create `AuthService`
   - Handle registration
   - Handle login
   - Generate JWT tokens (optional for Phase 1)

3. Create `StudentsController`
   - Registration endpoint
   - Login endpoint
   - Profile endpoints

#### Key Business Logic
- Hash passwords using strong algorithm
- Check email uniqueness during registration
- Validate age (optional: minimum age requirement)
- Lock account after failed login attempts (optional)

### 2. Course Enrollment

#### Endpoints
```
POST   /api/enrollments              - Enroll in course
GET    /api/enrollments/student/{id} - Get student's enrollments
GET    /api/enrollments/course/{id}  - Get course enrollments
PUT    /api/enrollments/{id}         - Update enrollment status
DELETE /api/enrollments/{id}         - Drop course
GET    /api/enrollments/validate     - Validate enrollment
```

#### Enrollment Features
- **Check Availability**
  - Course exists
  - Course not full (max students)
  - Course is active
  
- **Prevent Duplicates**
  - Student can't enroll twice
  - Unique constraint on (StudentId, CourseId)

- **Status Tracking**
  - Active, Completed, Dropped, Paused

- **Progress Tracking**
  - Track completion percentage
  - Calculate GPA

#### Validation Logic
```csharp
public async Task<bool> ValidateEnrollment(int studentId, int courseId)
{
    // Check student exists and is active
    // Check course exists and is active
    // Check course not full
    // Check student not already enrolled
    // Check any prerequisites (optional)
    return true; // if all checks pass
}
```

### 3. Blazor Components & Pages

#### Components to Create
- `Components/StudentForm.razor` - Registration form
- `Components/LoginForm.razor` - Login form
- `Components/EnrollmentForm.razor` - Enrollment modal
- `Components/EnrollmentList.razor` - List student enrollments

#### Pages to Create
- `Pages/Register.razor` - Student registration
- `Pages/Login.razor` - Student login
- `Pages/StudentProfile.razor` - Profile management
- `Pages/BrowseEnroll.razor` - Browse and enroll in courses

---

## Project Structure

```
OnlineCourseManagement.Server/
├── Controllers/
│   ├── StudentsController.cs
│   └── EnrollmentsController.cs
├── Services/
│   ├── Interfaces/
│   │   ├── IStudentService.cs
│   │   ├── IAuthService.cs
│   │   └── IEnrollmentService.cs
│   ├── StudentService.cs
│   ├── AuthService.cs
│   └── EnrollmentService.cs
├── Repositories/
│   ├── Interfaces/
│   │   ├── IStudentRepository.cs
│   │   └── IEnrollmentRepository.cs
│   ├── StudentRepository.cs
│   └── EnrollmentRepository.cs
├── Utilities/
│   ├── IPasswordHasher.cs
│   └── PasswordHasher.cs (using BCrypt)
├── Models/
│   └── AuthModels.cs
└── Program.cs

OnlineCourseManagement/
├── Pages/
│   ├── Register.razor
│   ├── Login.razor
│   ├── StudentProfile.razor
│   └── BrowseEnroll.razor
├── Components/
│   ├── StudentForm.razor
│   ├── LoginForm.razor
│   ├── EnrollmentForm.razor
│   └── EnrollmentList.razor
└── Services/
    └── AuthService.cs (client-side)
```

---

## Database Dependencies

✓ Phase 1 & 2 must be complete with:
- Student table
- Course table
- Enrollment table
- Courses API

---

## Password Security

### Implementation
```csharp
public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        // Use BCrypt.Net-Next NuGet package
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    
    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
```

### NuGet Package
```bash
dotnet add package BCrypt.Net-Next
```

---

## Validation Rules

### Student Registration
- Email: Required, Unique, Valid format
- FirstName: Required, 2-100 chars
- LastName: Required, 2-100 chars
- Password: Minimum 8 chars, complex requirements
- DateOfBirth: Valid date, not future
- PhoneNumber: Optional, valid format

### Enrollment
- Student must be active
- Course must be active
- Course capacity check
- No duplicate enrollments

---

## Error Responses

```json
{
  "success": false,
  "message": "Email already registered",
  "errors": {
    "Email": ["This email is already in use"]
  }
}
```

---

## Client-Side Validation

Validate in Blazor component before sending to server:
- Email format
- Password strength meter
- Matching passwords
- Required fields

---

## Testing Scenarios

1. **Registration**
   - [ ] Valid data → Success
   - [ ] Duplicate email → Fail
   - [ ] Weak password → Fail
   - [ ] Missing required field → Fail

2. **Login**
   - [ ] Correct credentials → Success
   - [ ] Wrong password → Fail
   - [ ] Non-existent email → Fail

3. **Enrollment**
   - [ ] Valid course → Success
   - [ ] Course full → Fail
   - [ ] Already enrolled → Fail
   - [ ] Inactive course → Fail

---

## Phase Completion Checklist

- [ ] Password hashing implemented
- [ ] Student registration API working
- [ ] Student login API working
- [ ] Student profile endpoints working
- [ ] Enrollment API endpoints working
- [ ] Validation logic implemented
- [ ] Error handling in place
- [ ] Blazor pages created
- [ ] Client-side validation working
- [ ] Integration tested
- [ ] Code reviewed and documented

---

## Next Phase

**Phase 4 ** will depend on:
- ✓ Student registration working
- ✓ Enrollment API working
- ✓ Students can enroll in courses

Notify once students can successfully enroll.

---

## Tips

1. Use HTTPS in production
2. Implement account lockout after failed attempts
3. Consider email verification
4. Log authentication attempts
5. Use proper error messages (don't reveal if email exists)
6. Hash passwords before storing
7. Implement refresh tokens for JWT

---

**Estimated Time:** 1-2 weeks
**Status:** Not Started - Waiting for Phase 2 Completion
