# Quick Reference Guide

## 🚀 Clone & Initial Setup

```bash
# Clone repository
git clone https://github.com/mystify0007/Online-Course-Management.git
cd Online-Course-Management

# Restore NuGet packages
dotnet restore

# Build solution
dotnet build

# Run (when ready)
dotnet run
```

---

## 👤 Phase 1: Ashna Shrestha - Database Setup

```bash
# Install EF Core tools (one time)
dotnet tool install --global dotnet-ef

# Navigate to Shared project
cd src/OnlineCourseManagement.Shared

# Create migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update

# Verify by checking your database for tables
```

**Checklist:**
- [ ] Read PHASE1_DATABASE.md
- [ ] Install dotnet-ef
- [ ] Create initial migration
- [ ] Update database
- [ ] Configure appsettings.json with connection string
- [ ] Create ASP.NET Core Server project
- [ ] Notify Babita when complete

---

## 👤 Phase 2: Babita Thami - Course & Instructor Management

```bash
# Read phase guide first
cat PHASE2_MANAGEMENT.md

# Key files to create:
# - src/OnlineCourseManagement.Server/Controllers/CoursesController.cs
# - src/OnlineCourseManagement.Server/Controllers/InstructorsController.cs
# - src/OnlineCourseManagement.Server/Services/CoursesService.cs
# - src/OnlineCourseManagement.Server/Services/InstructorsService.cs

# Test API endpoints (using Postman or curl)
curl https://localhost:5001/api/courses

# Update Blazor Client pages:
# - Pages/ManageCourses.razor
# - Pages/ManageInstructors.razor
```

**Checklist:**
- [ ] Wait for Phase 1 to complete
- [ ] Read PHASE2_MANAGEMENT.md
- [ ] Create Server project (if not already done)
- [ ] Implement CoursesController
- [ ] Implement InstructorsController
- [ ] Add Course search functionality
- [ ] Test all endpoints
- [ ] Update Blazor pages
- [ ] Notify Beni when complete

---

## 👤 Phase 3: Beni Raj Karki - Student Registration & Enrollment

```bash
# Read phase guide first
cat PHASE3_ENROLLMENT.md

# Key files to create:
# - src/OnlineCourseManagement.Server/Controllers/StudentsController.cs
# - src/OnlineCourseManagement.Server/Controllers/EnrollmentsController.cs
# - src/OnlineCourseManagement.Server/Services/StudentService.cs
# - src/OnlineCourseManagement.Server/Services/AuthService.cs
# - src/OnlineCourseManagement.Server/Utilities/PasswordHasher.cs

# Install BCrypt for password hashing
cd src/OnlineCourseManagement.Server
dotnet add package BCrypt.Net-Next

# Test authentication endpoints
curl -X POST https://localhost:5001/api/students/register \
  -H "Content-Type: application/json" \
  -d '{"email":"test@test.com","password":"Test@123"}'
```

**Checklist:**
- [ ] Wait for Phase 2 to complete
- [ ] Read PHASE3_ENROLLMENT.md
- [ ] Implement StudentsController
- [ ] Implement EnrollmentsController
- [ ] Add password hashing
- [ ] Test registration/login
- [ ] Update Blazor pages (Register, Login, Profile)
- [ ] Test enrollment flow
- [ ] Notify Bhumika when complete

---

## 👤 Phase 4: Bhumika Tamang - Learning Content & Dashboard

```bash
# Read phase guide first
cat PHASE4_DASHBOARD.md

# Key files to create:
# - src/OnlineCourseManagement.Server/Controllers/LessonsController.cs
# - src/OnlineCourseManagement.Server/Controllers/AssignmentsController.cs
# - src/OnlineCourseManagement.Server/Controllers/ResultsController.cs
# - src/OnlineCourseManagement.Server/Services/LessonsService.cs
# - src/OnlineCourseManagement.Server/Services/AssignmentsService.cs
# - src/OnlineCourseManagement.Server/Services/ResultsService.cs
# - src/OnlineCourseManagement.Server/Services/DashboardService.cs

# Create Blazor pages:
# - Pages/Lessons.razor
# - Pages/Assignments.razor
# - Pages/StudentDashboard.razor
# - Pages/Results.razor

# Test dashboard
curl https://localhost:5001/api/dashboard/student/1
```

**Checklist:**
- [ ] Wait for Phase 3 to complete
- [ ] Read PHASE4_DASHBOARD.md
- [ ] Implement LessonsController
- [ ] Implement AssignmentsController
- [ ] Implement ResultsController
- [ ] Create DashboardService
- [ ] Create all Blazor pages
- [ ] Test dashboard data aggregation
- [ ] Notify all members when complete

---

## 👥 Phase 5: All Members - Testing & Integration

```bash
# Each member tests their module
dotnet test

# Pull latest changes
git pull origin main

# Test integration of all modules
# - Student registration → Enrollment → Dashboard

# Find and fix bugs
# Commit fixes to your phase branch

# Prepare for final delivery
git checkout main
git merge claude/vibrant-goldberg-rwewpz
git push origin main
```

**Checklist:**
- [ ] Unit test all endpoints
- [ ] Integration test complete workflow
- [ ] Fix bugs found
- [ ] Update README if needed
- [ ] Final code review
- [ ] Merge to main
- [ ] GitHub upload complete

---

## 📊 Git Workflow

### For Each Developer:

```bash
# Update from latest main (or your phase branch)
git pull origin claude/vibrant-goldberg-rwewpz

# Create feature branch (optional)
git checkout -b phase-X-feature-name

# Make changes
# ... edit files ...

# Stage changes
git add .

# Check what you're committing
git status

# Commit
git commit -m "Phase X: Brief description of changes"

# Push
git push origin phase-X-feature-name
# or if on main phase branch:
git push origin claude/vibrant-goldberg-rwewpz

# Create Pull Request on GitHub (optional)
```

---

## 🔧 Common Commands

```bash
# Build project
dotnet build

# Run tests
dotnet test

# Restore packages
dotnet restore

# Clean build
dotnet clean && dotnet build

# Check git status
git status

# View recent commits
git log --oneline -10

# View current branch
git branch -v
```

---

## 🐛 Troubleshooting

### Build Errors
```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build
```

### NuGet Issues
```bash
# Clear NuGet cache
dotnet nuget locals all --clear
dotnet restore
```

### Git Issues
```bash
# Undo uncommitted changes
git checkout -- .

# Undo last commit (be careful!)
git reset --soft HEAD~1

# View what changed
git diff
```

---

## 📚 Documentation Reference

- **README.md** - Project overview
- **SETUP.md** - Full setup instructions
- **PHASE1_DATABASE.md** - Ashna's guide
- **PHASE2_MANAGEMENT.md** - Babita's guide
- **PHASE3_ENROLLMENT.md** - Beni's guide
- **PHASE4_DASHBOARD.md** - Bhumika's guide
- **QUICK_REFERENCE.md** - This file

---

## 🎯 Daily Development

### Morning
1. Pull latest changes: `git pull`
2. Read team updates
3. Build project: `dotnet build`
4. Start coding

### Afternoon
1. Test your changes
2. Fix any issues
3. Commit work: `git commit -m "..."`
4. Push: `git push`

### End of Day
1. Review what you did
2. Document any blockers
3. Prepare for next day

---

**Remember:** One phase at a time. Each phase must complete before the next begins!

Good luck! 🚀
