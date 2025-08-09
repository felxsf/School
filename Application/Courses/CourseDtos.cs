namespace School.Application.Courses;

public record CourseCreateDto(string Code, string Name, int Credits, int ProfessorId);
public record CourseUpdateDto(string Name, int Credits, int ProfessorId);
public record CourseReadDto(int Id, string Code, string Name, int Credits, int ProfessorId, string ProfessorName);
