using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrolledAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GradedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Document", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "PRF001", "prof1@school.test", "Profesor 1" },
                    { 2, "PRF002", "prof2@school.test", "Profesor 2" },
                    { 3, "PRF003", "prof3@school.test", "Profesor 3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "FirstName", "IdentificationNumber", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre1", "STU000001", "Apellido1" },
                    { 2, new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre2", "STU000002", "Apellido2" },
                    { 3, new DateTime(2000, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre3", "STU000003", "Apellido3" },
                    { 4, new DateTime(2000, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre4", "STU000004", "Apellido4" },
                    { 5, new DateTime(2000, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre5", "STU000005", "Apellido5" },
                    { 6, new DateTime(2000, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre6", "STU000006", "Apellido6" },
                    { 7, new DateTime(2000, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre7", "STU000007", "Apellido7" },
                    { 8, new DateTime(2000, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre8", "STU000008", "Apellido8" },
                    { 9, new DateTime(2000, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre9", "STU000009", "Apellido9" },
                    { 10, new DateTime(2000, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre10", "STU000010", "Apellido10" },
                    { 11, new DateTime(2000, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre11", "STU000011", "Apellido11" },
                    { 12, new DateTime(2000, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre12", "STU000012", "Apellido12" },
                    { 13, new DateTime(2001, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre13", "STU000013", "Apellido13" },
                    { 14, new DateTime(2001, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre14", "STU000014", "Apellido14" },
                    { 15, new DateTime(2001, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre15", "STU000015", "Apellido15" },
                    { 16, new DateTime(2001, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre16", "STU000016", "Apellido16" },
                    { 17, new DateTime(2001, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre17", "STU000017", "Apellido17" },
                    { 18, new DateTime(2001, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre18", "STU000018", "Apellido18" },
                    { 19, new DateTime(2001, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre19", "STU000019", "Apellido19" },
                    { 20, new DateTime(2001, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre20", "STU000020", "Apellido20" },
                    { 21, new DateTime(2001, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre21", "STU000021", "Apellido21" },
                    { 22, new DateTime(2001, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre22", "STU000022", "Apellido22" },
                    { 23, new DateTime(2001, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre23", "STU000023", "Apellido23" },
                    { 24, new DateTime(2001, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre24", "STU000024", "Apellido24" },
                    { 25, new DateTime(2002, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre25", "STU000025", "Apellido25" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Credits", "Name", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "MAT101", 3, "Matemáticas I", 1 },
                    { 2, "PRO101", 4, "Programación I", 2 },
                    { 3, "ING101", 2, "Inglés I", 3 },
                    { 4, "HIS101", 2, "Historia", 1 },
                    { 5, "FIS101", 3, "Física", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Code",
                table: "Courses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfessorId",
                table: "Courses",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_EnrollmentId",
                table: "Grades",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdentificationNumber",
                table: "Students",
                column: "IdentificationNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Professors");
        }
    }
}
