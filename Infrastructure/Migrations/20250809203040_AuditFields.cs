using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Professors",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Professors",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Professors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Grades",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Grades",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Enrollments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Enrollments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedBy", "UpdatedAt", "UpdatedBy" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Courses");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Grades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
