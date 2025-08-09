namespace School.Application.Grades;

public record GradeCreateDto(int EnrollmentId, string Type, decimal Value, DateTime? GradedAt);
public record GradeUpdateDto(string Type, decimal Value, DateTime? GradedAt);
public record GradeReadDto(
    int Id,
    int EnrollmentId,
    string Type,
    decimal Value,
    DateTime GradedAt,
    int StudentId,
    int CourseId,
    string CourseCode
);
