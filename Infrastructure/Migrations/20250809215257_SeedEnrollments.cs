using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedEnrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "CreatedBy", "EnrolledAt", "StudentId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, null },
                    { 2, 2, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, null, null },
                    { 3, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, null, null },
                    { 4, 3, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, null, null },
                    { 5, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, null, null },
                    { 6, 4, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, null, null },
                    { 7, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, null, null },
                    { 8, 5, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, null, null },
                    { 9, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, null, null },
                    { 10, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 5, null, null },
                    { 11, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, null, null },
                    { 12, 2, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6, null, null },
                    { 13, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, null, null },
                    { 14, 3, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7, null, null },
                    { 15, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, null, null },
                    { 16, 4, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 8, null, null },
                    { 17, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, null, null },
                    { 18, 5, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 9, null, null },
                    { 19, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, null, null },
                    { 20, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
