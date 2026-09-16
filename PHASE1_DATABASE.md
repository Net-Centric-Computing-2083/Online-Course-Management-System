# Phase 1: Database Setup & Foundation
**Owner:** Ashna Shrestha

---

## Overview
Phase 1 is the foundation of the entire project. All other phases depend on having a properly configured database and data models.

---

## Completed Tasks ✓

### 1. Database Schema Design ✓
The following tables have been designed:

| Table | Purpose | Status |
|-------|---------|--------|
| Students | Store student information | ✓ |
| Instructors | Store instructor details | ✓ |
| Courses | Store course metadata | ✓ |
| Enrollments | Link students to courses | ✓ |
| Lessons | Store lesson content | ✓ |
| Assignments | Store assignment details | ✓ |
| Results | Track student performance | ✓ |

### 2. EF Core Configuration ✓
- `ApplicationDbContext` created with all DbSets
- Model relationships configured
- Unique constraints defined
- Foreign key relationships established
- Cascade delete configured

### 3. Model Classes ✓
All entity models created in `OnlineCourseManagement/Models/`:
- Student.cs
- Instructor.cs
- Course.cs
- Enrollment.cs
- Lesson.cs
- Assignment.cs
- Result.cs

---

## Remaining Tasks

### 1. Install EF Core Tools
```bash
dotnet tool install --global dotnet-ef
```

### 2. Create Initial Migration
```bash
cd OnlineCourseManagement
dotnet ef migrations add InitialCreate --project .
```

### 3. Update Database
```bash
dotnet ef database update
```

### 4. Configure Connection String
Update `appsettings.json` with your database connection string:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=OnlineCourseManagementDb;Trusted_Connection=true;"
  }
}
```

### 5. Create API Server Project
This project will host the API endpoints for all other phases:

```bash
cd Online-Course-Management
dotnet new webapi -n OnlineCourseManagement.Server
dotnet sln add OnlineCourseManagement.Server/OnlineCourseManagement.Server.csproj
```

Configure in `Program.cs`:
```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## Key Files Modified/Created

```
OnlineCourseManagement/
├── Models/
│   ├── Student.cs
│   ├── Instructor.cs
│   ├── Course.cs
│   ├── Enrollment.cs
│   ├── Lesson.cs
│   ├── Assignment.cs
│   └── Result.cs
├── DTOs/
│   └── (To be used by Phase 2+)
├── Interfaces/
│   └── (To be used by Phase 2+)
├── Data/
│   └── ApplicationDbContext.cs ✓
└── OnlineCourseManagement.csproj ✓
```

---

## Validation Checklist

- [ ] All model files compile without errors
- [ ] ApplicationDbContext has all DbSets
- [ ] Relationships are properly configured
- [ ] Unique indexes are in place
- [ ] Foreign key constraints defined
- [ ] EF Core tools installed
- [ ] Initial migration created
- [ ] Database successfully updated
- [ ] Connection string configured
- [ ] Server API project created

---

## Next Phase Dependency

**Phase 2 (Babita Thami)** depends on:
- ✓ Database schema designed
- ✓ EF Core configured
- ✓ Models created
- ⏳ Migrations applied
- ⏳ Server project with DbContext setup

Notify Babita once the database is ready to proceed with API development.

---

## Tips & Best Practices

1. **Connection Strings**
   - Use `(localdb)` for local development
   - Use SQL Server for production
   - Never commit connection strings with passwords

2. **Migrations**
   - Always create meaningful migration names
   - Document complex migrations
   - Test migrations on a fresh database

3. **Entity Configuration**
   - Use Data Annotations for simple constraints
   - Use Fluent API for complex configurations
   - Keep ModelBuilder configurations organized

4. **Database Seeding**
   - Consider adding initial data in a seed method
   - Useful for development and testing

---

## Resources

- [EF Core Migrations](https://learn.microsoft.com/ef/core/managing-schemas/migrations/)
- [Modeling Relationships](https://learn.microsoft.com/ef/core/modeling/relationships/)
- [Data Annotations](https://learn.microsoft.com/dotnet/api/system.componentmodel.dataannotations/)

---

## Support

If you encounter issues:
1. Check the [Setup Guide](SETUP.md)
2. Review EF Core documentation
3. Check the Common Issues section
4. Contact the team lead

---

**Status:** ✓ Foundation Complete - Ready for API Development
**Next Step:** Create ASP.NET Core API Server
