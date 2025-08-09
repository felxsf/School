namespace School.Application.Professors;

public interface IProfessorService
{
    Task<(IEnumerable<ProfessorReadDto> items, int total)> GetPagedAsync(int page, int pageSize, string? document, string? name, string? email);
    Task<ProfessorReadDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(ProfessorCreateDto dto);
    Task<bool> UpdateAsync(int id, ProfessorUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
