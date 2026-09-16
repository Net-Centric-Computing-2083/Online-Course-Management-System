using Microsoft.EntityFrameworkCore;
using OnlineCourseManagement.Models;

namespace OnlineCourseManagement.Data
{
    /// <summary>
    /// Application Database Context for EF Core
    /// Author: Ashna Shrestha (Phase 1)
    /// Manages all database entities and configurations
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student entity
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Student>()
                .Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            // Configure Instructor entity
            modelBuilder.Entity<Instructor>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Instructor>()
                .Property(i => i.Email)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<Instructor>()
                .HasIndex(i => i.Email)
                .IsUnique();

            // Configure Course entity
            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Course>()
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<Course>()
                .Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.Code)
                .IsUnique();
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Enrollment entity
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();

            // Configure Lesson entity
            modelBuilder.Entity<Lesson>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<Lesson>()
                .Property(l => l.Title)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Course)
                .WithMany(c => c.Lessons)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Assignment entity
            modelBuilder.Entity<Assignment>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Assignment>()
                .Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Result entity
            modelBuilder.Entity<Result>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Assignment)
                .WithMany(a => a.Results)
                .HasForeignKey(r => r.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
