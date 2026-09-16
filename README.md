# Online Course Management System

A comprehensive Blazor WebAssembly application for managing online courses, instructors, students, and learning content.

**Technology Stack:** Blazor WebAssembly | Entity Framework Core | .NET 8

---

## 👥 Team Members

| Name | Phase | Responsibility |
|------|-------|-----------------|
| **Ashna Shrestha** | Phase 1 | Database Design, Blazor Project Setup, EF Core Configuration |
| **Babita Thami** | Phase 2 | Course Management, Instructor Management, Search Functionality |
| **Beni Raj Karki** | Phase 3 | Student Registration, Course Enrollment, Enrollment Validation |
| **Bhumika Tamang** | Phase 4 | Lessons, Assignments, Results, Student Learning Dashboard |

---

## 📋 Project Overview

### Database Schema (EF Core)
- **Students** - Student information and accounts
- **Instructors** - Instructor profiles
- **Courses** - Course details and metadata
- **Enrollments** - Student-Course relationships
- **Lessons** - Course lesson content
- **Assignments** - Course assignments
- **Results** - Student assignment results

### Modules
1. Course Management
2. Instructor Management
3. Student Registration
4. Course Enrollment
5. Lessons Management
6. Assignments Management
7. Results Tracking
8. Course Search
9. Student Learning Dashboard

---

## 🏗️ Project Structure

```
Online-Course-Management/
├── src/
│   ├── OnlineCourseManagement.Client/          # Blazor WebAssembly Frontend
│   │   ├── Pages/
│   │   ├── Components/
│   │   ├── Services/
│   │   └── wwwroot/
│   │
│   ├── OnlineCourseManagement.Server/          # Backend API (if needed)
│   │   ├── Controllers/
│   │   └── Services/
│   │
│   └── OnlineCourseManagement.Shared/          # Shared Models & DTOs
│       ├── Models/
│       ├── DTOs/
│       └── Interfaces/
│
├── Database/
│   ├── Migrations/
│   └── DbContext.cs
│
├── Tests/                                       # Unit & Integration Tests
│
└── README.md
```

---

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio Code or Visual Studio 2022
- Node.js (for package management, optional)

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Online-Course-Management
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Setup Database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet watch run
   ```

---

## 📅 Development Phases

### Phase 1: Project Setup & Database (Ashna Shrestha)
- [x] Create Blazor WebAssembly project structure
- [x] Design database schema
- [x] Configure EF Core
- [x] Create models for all entities
- [ ] Run initial migrations
- [ ] Create database context

### Phase 2: Management & Search (Babita Thami)
- [ ] Course Management (CRUD operations)
- [ ] Instructor Management (CRUD operations)
- [ ] Course Search functionality
- [ ] Filter and sorting capabilities

### Phase 3: Student & Enrollment (Beni Raj Karki)
- [ ] Student Registration
- [ ] Student Login/Authentication
- [ ] Student Profile Management
- [ ] Course Enrollment
- [ ] Enrollment Validation Logic

### Phase 4: Learning Content & Dashboard (Bhumika Tamang)
- [ ] Lessons Management
- [ ] Assignments Management
- [ ] Results Recording
- [ ] Student Learning Dashboard
- [ ] Progress Tracking

### Phase 5: Testing & Delivery (All Members)
- [ ] Unit Testing
- [ ] Integration Testing
- [ ] Bug Fixing
- [ ] Final Integration
- [ ] GitHub Upload

---

## 🛠️ Technology Details

### Frontend (Blazor WebAssembly)
- Interactive UI components
- Client-side routing
- Real-time data binding
- Responsive design

### Backend (Entity Framework Core)
- Database ORM
- Migration management
- Query optimization
- Data validation

### Database
- SQL Server or SQLite
- Relational schema
- Referential integrity
- Stored procedures (optional)

---

## 📝 Database Tables

| Table | Purpose |
|-------|---------|
| Students | Store student information |
| Instructors | Store instructor details |
| Courses | Store course metadata |
| Enrollments | Link students to courses |
| Lessons | Store lesson content |
| Assignments | Store assignment details |
| Results | Track student performance |

---

## 🧪 Testing

Run tests with:
```bash
dotnet test
```

---

## 📦 Deployment

Instructions for deployment to production will be added during Phase 5.

---

## 📄 License

This project is for educational purposes.

---

## 📞 Support

For questions or issues, contact the respective phase owners.

**Project Created:** September 2024
