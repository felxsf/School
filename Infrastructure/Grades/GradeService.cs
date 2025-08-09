using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using School.Application.Grades;

namespace School.Infrastructure.Grades;

public class GradeService : IGradeService
{
    private readonly SchoolDbContext _db;
    private readonly IMapper _mapper;
    public GradeService(SchoolDbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

    public async Task<(IEnumerable<GradeReadDto> items, int total)> GetPagedAsync(
        int page, int pageSize, int? studentId, int? courseId, string? type, decimal? min, decimal? max)
    {
        var q = _db.Grades.AsNoTracking()
            .Include(g => g.Enrollment)
                .ThenInclude(e => e.Course)
            .AsQueryable();

        if (studentId.HasValue) q = q.Where(g => g.Enrollment.StudentId == studentId.Value);
        if (courseId.HasValue) q = q.Where(g => g.Enrollment.CourseId == courseId.Value);
        if (!string.IsNullOrWhiteSpace(type)) q = q.Where(g => g.Type == type);
        if (min.HasValue) q = q.Where(g => g.Value >= min.Value);
        if (max.HasValue) q = q.Where(g => g.Value <= max.Value);

        q = q.OrderByDescending(g => g.GradedAt).ThenBy(g => g.Id);

        var total = await q.CountAsync();
        var items = await q.Skip((page - 1) * pageSize).Take(pageSize)
            .ProjectTo<GradeReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return (items, total);
    }

    public async Task<GradeReadDto?> GetByIdAsync(int id) =>
        await _db.Grades.AsNoTracking()
            .Include(g => g.Enrollment).ThenInclude(e => e.Course)
            .Where(g => g.Id == id)
            .ProjectTo<GradeReadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(GradeCreateDto dto)
    {
        var entity = _mapper.Map<Grade>(dto);
        _db.Grades.Add(entity);
        await _db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(int id, GradeUpdateDto dto)
    {
        var entity = await _db.Grades.FindAsync(id);
        if (entity is null) return false;
        _mapper.Map(dto, entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _db.Grades.FindAsync(id);
        if (entity is null) return false;
        _db.Grades.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}
