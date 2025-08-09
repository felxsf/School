namespace School.Application.Students;

public interface IStudentService
{
    Task<(IEnumerable<StudentReadDto> items, int total)> GetPagedAsync(int page, int pageSize);
    Task<StudentReadDto?> GetByIdAsync(int id);
    Task<StudentReadDto?> GetByIdentificationAsync(string identificationNumber);
    Task<int> CreateAsync(StudentCreateDto dto);
    Task<bool> UpdateAsync(int id, StudentUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
