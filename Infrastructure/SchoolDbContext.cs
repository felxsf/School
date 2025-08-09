using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using School.Application.Abstractions;
using System.Linq.Expressions;

namespace School.Infrastructure;

public class SchoolDbContext : DbContext
{
    private readonly IUserContext? _user;

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options, IUserContext? user = null)
        : base(options)
    {
        _user = user;
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Professor> Professors => Set<Professor>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Grade> Grades => Set<Grade>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(e =>
        {
            e.HasIndex(x => x.IdentificationNumber).IsUnique();
            e.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            e.Property(x => x.LastName).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Course>(e =>
        {
            e.HasIndex(x => x.Code).IsUnique();
            e.Property(x => x.Name).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<Grade>()
            .Property(g => g.Value)
            .HasPrecision(5, 2); // ajusta a tu escala (ej. 0..100 con 2 decimales)

        // Soft-delete global: solo IsActive = true
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                // Soft-delete global
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var prop = Expression.Property(parameter, nameof(BaseEntity.IsActive));
                var body = Expression.Equal(prop, Expression.Constant(true));
                var lambda = Expression.Lambda(body, parameter);
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);

                // Defaults de auditoría
                var builder = modelBuilder.Entity(entityType.ClrType);
                builder.Property(nameof(BaseEntity.CreatedAt))
                       .HasColumnType("datetime2")
                       .HasDefaultValueSql("GETUTCDATE()");
                builder.Property(nameof(BaseEntity.IsActive))
                       .HasDefaultValue(true);
            }
        }

        Seed(modelBuilder);
    }

    private void Seed(ModelBuilder mb)
    {
        var profs = new List<Professor>();
        for (int i = 1; i <= 3; i++)
            profs.Add(new Professor { Id = i, Document = $"PRF{i:000}", FullName = $"Profesor {i}", Email = $"prof{i}@school.test" });
        mb.Entity<Professor>().HasData(profs);

        var courses = new List<Course>
        {
            new() { Id=1, Code="MAT101", Name="Matemáticas I", Credits=3, ProfessorId=1 },
            new() { Id=2, Code="PRO101", Name="Programación I", Credits=4, ProfessorId=2 },
            new() { Id=3, Code="ING101", Name="Inglés I", Credits=2, ProfessorId=3 },
            new() { Id=4, Code="HIS101", Name="Historia", Credits=2, ProfessorId=1 },
            new() { Id=5, Code="FIS101", Name="Física", Credits=3, ProfessorId=2 }
        };
        mb.Entity<Course>().HasData(courses);

        var students = Enumerable.Range(1, 25).Select(i => new Student
        {
            Id = i,
            IdentificationNumber = $"STU{i:000000}",
            FirstName = $"Nombre{i}",
            LastName = $"Apellido{i}",
            BirthDate = new DateTime(2000, 1, 1).AddDays(i * 30)
        }).ToArray();
        mb.Entity<Student>().HasData(students);

        // Enrollments seed: matricular algunos estudiantes en cursos existentes
        var enrollments = new List<Enrollment>();
        int enrollmentId = 1;
        // usar fecha estática para evitar PendingModelChangesWarning
        var enrolledAt = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        for (int studentId = 1; studentId <= 10; studentId++)
        {
            // cada estudiante en dos cursos distintos
            enrollments.Add(new Enrollment { Id = enrollmentId++, StudentId = studentId, CourseId = 1, EnrolledAt = enrolledAt });
            enrollments.Add(new Enrollment { Id = enrollmentId++, StudentId = studentId, CourseId = (studentId % 5) + 1, EnrolledAt = enrolledAt });
        }
        mb.Entity<Enrollment>().HasData(enrollments);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var user = _user?.GetUser() ?? "system";

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = user;
                    entry.Entity.IsActive = true;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = user;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.IsActive = false;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = user;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
