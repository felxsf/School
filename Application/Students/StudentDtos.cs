namespace Application.Students;

public record StudentCreateDto(string IdentificationNumber, string FirstName, string LastName, DateTime BirthDate);
public record StudentUpdateDto(string FirstName, string LastName, DateTime BirthDate);
public record StudentReadDto(int Id, string IdentificationNumber, string FirstName, string LastName, DateTime BirthDate);
