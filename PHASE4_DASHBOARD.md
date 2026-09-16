# Phase 4: Learning Content, Results & Dashboard
**Owner:** Bhumika Tamang

---

## Overview
Phase 4 implements the learning content management system and student progress tracking features.

---

## Tasks

### 1. Lessons Management

#### Endpoints
```
GET    /api/courses/{courseId}/lessons     - Get lessons for course
GET    /api/lessons/{id}                   - Get lesson details
POST   /api/lessons                        - Create lesson
PUT    /api/lessons/{id}                   - Update lesson
DELETE /api/lessons/{id}                   - Delete lesson
PUT    /api/lessons/{id}/publish           - Publish lesson
```

#### Lesson Features
- Organized by course
- Sequential ordering (OrderNumber)
- Rich content support (HTML)
- Video URL integration
- Duration tracking
- Publication status

#### Implementation
1. Create `ILessonsService` interface
2. Create `LessonsService` implementation
3. Create `LessonsRepository` for data access
4. Create `LessonsController` API

#### Business Logic
- Validate course exists before adding lesson
- Auto-increment OrderNumber for new lessons
- Prevent publishing if content empty
- Track lesson duration

### 2. Assignments Management

#### Endpoints
```
GET    /api/courses/{courseId}/assignments - Get assignments for course
GET    /api/assignments/{id}                - Get assignment details
POST   /api/assignments                     - Create assignment
PUT    /api/assignments/{id}                - Update assignment
DELETE /api/assignments/{id}                - Delete assignment
PUT    /api/assignments/{id}/publish        - Publish assignment
```

#### Assignment Types
- Quiz (auto-graded possible)
- Project
- Essay
- Practical

#### Implementation
1. Create `IAssignmentsService`
2. Create `AssignmentsService`
3. Create `AssignmentsRepository`
4. Create `AssignmentsController`

#### Business Logic
- Set max marks validation
- Due date cannot be in past
- Validate assignment type
- Track published status

### 3. Results Management

#### Endpoints
```
GET    /api/results                        - Get all results (admin)
GET    /api/students/{studentId}/results  - Get student results
GET    /api/assignments/{id}/results      - Get assignment results
POST   /api/results                        - Submit result
PUT    /api/results/{id}                   - Grade assignment
GET    /api/results/{id}                   - Get result details
```

#### Result Features
- Track submission status
- Record marks obtained
- Add feedback/comments
- Track submission date
- Track grading date
- Submission file/link storage

#### Implementation
1. Create `IResultsService`
2. Create `ResultsService`
3. Create `ResultsRepository`
4. Create `ResultsController`

#### Business Logic
- Validate marks ≤ max marks
- Prevent re-submission after due date
- Calculate grade from marks
- Auto-save submitted results

### 4. Student Learning Dashboard

#### Dashboard Components
- **Enrolled Courses Section**
  - List of active enrollments
  - Course progress bar
  - Quick access to course

- **Completed Lessons Section**
  - Count of completed lessons
  - Lessons list with completion status
  - Option to review lessons

- **Pending Assignments Section**
  - Due date sorting
  - Assignment type indicator
  - Quick submit button

- **Results Section**
  - Assignment grades
  - Performance statistics
  - Grade distribution chart

#### Implementation
1. Create `DashboardService` aggregates data
2. Create `StudentDashboard.razor` page
3. Create dashboard components:
   - `EnrolledCoursesWidget.razor`
   - `PendingAssignmentsWidget.razor`
   - `ResultsWidget.razor`
   - `ProgressChart.razor`

### 5. Blazor Components & Pages

#### Components
- `Components/LessonCard.razor`
- `Components/LessonForm.razor`
- `Components/AssignmentCard.razor`
- `Components/AssignmentForm.razor`
- `Components/ResultForm.razor` (grading)
- `Components/DashboardWidget.razor` (reusable)

#### Pages
- `Pages/CourseDetail.razor` - View course with lessons
- `Pages/Lessons.razor` - Lessons management
- `Pages/Assignments.razor` - Assignments management
- `Pages/StudentDashboard.razor` - Student progress dashboard
- `Pages/Results.razor` - Results/grades view
- `Pages/GradeAssignment.razor` - Instructor grading

---

## Project Structure

```
OnlineCourseManagement.Server/
├── Controllers/
│   ├── LessonsController.cs
│   ├── AssignmentsController.cs
│   ├── ResultsController.cs
│   └── DashboardController.cs
├── Services/
│   ├── Interfaces/
│   │   ├── ILessonsService.cs
│   │   ├── IAssignmentsService.cs
│   │   ├── IResultsService.cs
│   │   └── IDashboardService.cs
│   ├── LessonsService.cs
│   ├── AssignmentsService.cs
│   ├── ResultsService.cs
│   └── DashboardService.cs
├── Repositories/
│   ├── Interfaces/
│   │   ├── ILessonsRepository.cs
│   │   ├── IAssignmentsRepository.cs
│   │   └── IResultsRepository.cs
│   ├── LessonsRepository.cs
│   ├── AssignmentsRepository.cs
│   └── ResultsRepository.cs
└── Program.cs

OnlineCourseManagement/
├── Pages/
│   ├── CourseDetail.razor
│   ├── Lessons.razor
│   ├── Assignments.razor
│   ├── StudentDashboard.razor
│   ├── Results.razor
│   └── GradeAssignment.razor
└── Components/
    ├── LessonCard.razor
    ├── LessonForm.razor
    ├── AssignmentCard.razor
    ├── AssignmentForm.razor
    ├── ResultForm.razor
    └── DashboardWidget.razor
```

---

## Database Dependencies

✓ All previous phases must be complete:
- Phase 1: Database schema
- Phase 2: Courses API
- Phase 3: Student enrollment

---

## Validation Rules

### Lessons
- Title: Required, max 256 chars
- Content: Required for publishing
- OrderNumber: Auto-assigned
- Duration: Optional, > 0 minutes
- VideoUrl: Optional, valid URL format

### Assignments
- Title: Required, max 256 chars
- Type: Quiz | Project | Essay | Practical
- MaxMarks: Required, > 0
- DueDate: Required, should be after course start
- Description: Optional but recommended

### Results
- MarksObtained: 0 ≤ marks ≤ maxMarks
- Feedback: Optional
- SubmissionDate: Auto-set when submitted
- GradedDate: Set when graded

---

## Dashboard Data

Dashboard aggregates:
```csharp
public class StudentDashboardDTO
{
    public List<EnrolledCourseDTO> EnrolledCourses { get; set; }
    public int CompletedLessons { get; set; }
    public int TotalLessons { get; set; }
    public List<PendingAssignmentDTO> PendingAssignments { get; set; }
    public List<ResultDTO> RecentResults { get; set; }
    public decimal OverallGPA { get; set; }
}
```

---

## Grading System (Optional Enhancement)

Implement automatic grade calculation:
- 90-100: A (4.0)
- 80-89: B (3.0)
- 70-79: C (2.0)
- 60-69: D (1.0)
- <60: F (0.0)

---

## Charts & Analytics (Optional)

Using charting library (e.g., Chart.js with Blazor):
- Grade distribution pie chart
- Progress line chart
- Assignment completion status

---

## API Testing

```bash
# Get lessons for course
curl https://localhost:5001/api/courses/1/lessons

# Submit assignment result
curl -X POST https://localhost:5001/api/results \
  -H "Content-Type: application/json" \
  -d '{"studentId":1,"assignmentId":1,"marksObtained":85}'

# Get student dashboard
curl https://localhost:5001/api/dashboard/student/1
```

---

## Performance Considerations

1. **Pagination** for large assignment/result lists
2. **Lazy Loading** for lesson content (especially videos)
3. **Caching** dashboard data (expires quickly)
4. **Indexing** on frequently queried fields
5. **Async Operations** for all database calls

---

## Phase Completion Checklist

- [ ] Lessons API endpoints implemented
- [ ] Assignments API endpoints implemented
- [ ] Results API endpoints implemented
- [ ] Dashboard aggregation logic working
- [ ] Validation rules enforced
- [ ] Blazor pages created
- [ ] Components functional
- [ ] Dashboard displaying correctly
- [ ] Charts/analytics (if included)
- [ ] Performance optimized
- [ ] Integration tested
- [ ] Code reviewed and documented

---

## Next Phase

**Phase 5 (All Members)** will:
- Test all integrated modules
- Fix bugs
- Prepare for delivery
- Upload to GitHub

---

## Tips

1. Use virtual properties for lazy loading
2. Implement soft deletes for audit trail
3. Add timestamp fields (CreatedDate, UpdatedDate)
4. Cache frequently accessed data
5. Implement logging for grading
6. Consider file upload security for submissions

---

**Estimated Time:** 1-2 weeks
**Status:** Not Started - Waiting for Phase 3 Completion
