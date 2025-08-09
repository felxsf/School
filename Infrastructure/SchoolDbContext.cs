using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

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

            // 👇 Invoca tu método de semillas
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder mb)
        {
            // Profesores
            var profs = new List<Professor>();
            for (int i = 1; i <= 3; i++)
                profs.Add(new Professor { Id = i, Document = $"PRF{i:000}", FullName = $"Profesor {i}", Email = $"prof{i}@school.test" });
            mb.Entity<Professor>().HasData(profs);

            // Cursos
            var courses = new List<Course>
        {
            new() { Id=1, Code="MAT101", Name="Matemáticas I", Credits=3, ProfessorId=1 },
            new() { Id=2, Code="PRO101", Name="Programación I", Credits=4, ProfessorId=2 },
            new() { Id=3, Code="ING101", Name="Inglés I", Credits=2, ProfessorId=3 },
            new() { Id=4, Code="HIS101", Name="Historia", Credits=2, ProfessorId=1 },
            new() { Id=5, Code="FIS101", Name="Física", Credits=3, ProfessorId=2 }
        };
            mb.Entity<Course>().HasData(courses);

            // Estudiantes (25 para la paginación)
            var students = Enumerable.Range(1, 25).Select(i =>
                new Student
                {
                    Id = i,
                    IdentificationNumber = $"STU{i:000000}",
                    FirstName = $"Nombre{i}",
                    LastName = $"Apellido{i}",
                    BirthDate = new DateTime(2000, 1, 1).AddDays(i * 30)
                }).ToArray();

            mb.Entity<Student>().HasData(students);
        }
    }
}
