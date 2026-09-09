# Online Course Management System

**Group 3**

## Description

A web-based Course Management System that enables instructors to manage courses and lessons, students to register and enroll in courses, and both to track assignments and results. Built using Blazor WebAssembly with EF Core for data access, the system also features an interactive Student Learning Dashboard for monitoring academic progress at a glance.

## Technology Stack

- **Frontend/Framework:** Blazor WebAssembly
- **Database:** EF Core (Entity Framework Core)

## Overview

The Online Course Management System is a web application built with Blazor WebAssembly that allows management of courses, instructors, and students, along with enrollment, lessons, assignments, and results tracking. The system also includes an interactive Student Learning Dashboard for tracking academic progress.

## Modules

- Course Management
- Instructor Management
- Student Registration
- Course Enrollment
- Lessons
- Assignments
- Results
- Course Search
- Blazor Requirement

## Student Learning Dashboard

An interactive dashboard for students to view:

- Enrolled Courses
- Completed Lessons
- Pending Assignments
- Results

## Database Tables

- Students
- Instructors
- Courses
- Enrollments
- Lessons
- Assignments
- Results

## Project Steps

1. Create Blazor WebAssembly project.
2. Design database/models.
3. Configure EF Core.
4. Implement course management.
5. Implement student registration.
6. Implement enrollment.
7. Add lessons and assignments.
8. Create Learning Dashboard.
9. Add search.
10. Test and upload to GitHub.

## Getting Started

### Prerequisites

- .NET SDK (compatible with Blazor WebAssembly)
- SQL Server (or preferred EF Core-supported database)
- Visual Studio / Visual Studio Code

### Setup

```bash
# Clone the repository
git clone <repository-url>

# Navigate to the project directory
cd OnlineCourseManagementSystem

# Restore dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
```

## License

This project is developed for academic purposes.
