using Application.Students;

namespace School.Application.Students;

public interface IStudentService
{
    Task<(IEnumerable<StudentReadDto> items, int total)> GetPagedAsync(
        int page,
        int pageSize,
        string? identification,
        string? firstName,
        string? lastName,
        DateTime? birthDateFrom,
        DateTime? birthDateTo);
    Task<StudentReadDto?> GetByIdAsync(int id);
    Task<StudentReadDto?> GetByIdentificationAsync(string identificationNumber);
    Task<int> CreateAsync(StudentCreateDto dto);
    Task<bool> UpdateAsync(int id, StudentUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
