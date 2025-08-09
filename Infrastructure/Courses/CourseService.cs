using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using School.Application.Courses;

namespace School.Infrastructure.Courses;

public class CourseService : ICourseService
{
    private readonly SchoolDbContext _db;
    private readonly IMapper _mapper;
    public CourseService(SchoolDbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

    public async Task<(IEnumerable<CourseReadDto> items, int total)> GetPagedAsync(int page, int pageSize, string? code, string? name, int? professorId)
    {
        var q = _db.Courses.AsNoTracking().Include(c => c.Professor).AsQueryable();

        if (!string.IsNullOrWhiteSpace(code))
            q = q.Where(c => c.Code.Contains(code));
        if (!string.IsNullOrWhiteSpace(name))
            q = q.Where(c => c.Name.Contains(name));
        if (professorId.HasValue)
            q = q.Where(c => c.ProfessorId == professorId.Value);

        q = q.OrderBy(c => c.Id);

        var total = await q.CountAsync();
        var items = await q.Skip((page - 1) * pageSize).Take(pageSize)
            .ProjectTo<CourseReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return (items, total);
    }

    public async Task<CourseReadDto?> GetByIdAsync(int id) =>
        await _db.Courses.AsNoTracking().Include(c => c.Professor)
            .Where(c => c.Id == id)
            .ProjectTo<CourseReadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(CourseCreateDto dto)
    {
        var entity = _mapper.Map<Course>(dto);
        _db.Courses.Add(entity);
        await _db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(int id, CourseUpdateDto dto)
    {
        var entity = await _db.Courses.FindAsync(id);
        if (entity is null) return false;
        _mapper.Map(dto, entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _db.Courses.FindAsync(id);
        if (entity is null) return false;
        _db.Courses.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}
