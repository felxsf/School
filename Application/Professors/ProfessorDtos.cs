namespace School.Application.Professors;

public record ProfessorCreateDto(string Document, string FullName, string Email);
public record ProfessorUpdateDto(string FullName, string Email);
public record ProfessorReadDto(int Id, string Document, string FullName, string Email);
