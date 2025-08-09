namespace School.Application.Courses;

public record CourseCreateDto(string Code, string Name, int Credits, int ProfessorId);
public record CourseUpdateDto(string Name, int Credits, int ProfessorId);

// Para compatibilidad con AutoMapper ProjectTo (EF Core), usar clase con ctor por defecto
public class CourseReadDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int ProfessorId { get; set; }
    public string ProfessorName { get; set; } = string.Empty;
}
