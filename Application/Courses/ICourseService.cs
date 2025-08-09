namespace School.Application.Courses;

public interface ICourseService
{
    Task<(IEnumerable<CourseReadDto> items, int total)> GetPagedAsync(int page, int pageSize, string? code, string? name, int? professorId);
    Task<CourseReadDto?> GetByIdAsync(int id);
    Task<int> CreateAsync(CourseCreateDto dto);
    Task<bool> UpdateAsync(int id, CourseUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
