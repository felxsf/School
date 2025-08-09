namespace School.Application.Grades;

public interface IGradeService
{
    Task<(IEnumerable<GradeReadDto> items, int total)> GetPagedAsync(
        int page, int pageSize,
        int? studentId, int? courseId, string? type, decimal? min, decimal? max);

    Task<GradeReadDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(GradeCreateDto dto);
    Task<bool> UpdateAsync(int id, GradeUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
