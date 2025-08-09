namespace School.Application.Grades;

public record GradeCreateDto(int EnrollmentId, string Type, decimal Value, DateTime? GradedAt);
public record GradeUpdateDto(string Type, decimal Value, DateTime? GradedAt);

// Para soportar ProjectTo (EF Core + AutoMapper), usamos un DTO con ctor por defecto y propiedades settable
public class GradeReadDto
{
    public int Id { get; set; }
    public int EnrollmentId { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime GradedAt { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string CourseCode { get; set; } = string.Empty;
}
