using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using School.Application.Professors;

namespace School.Infrastructure.Professors;

public class ProfessorService : IProfessorService
{
    private readonly SchoolDbContext _db;
    private readonly IMapper _mapper;
    public ProfessorService(SchoolDbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

    public async Task<(IEnumerable<ProfessorReadDto> items, int total)> GetPagedAsync(int page, int pageSize, string? document, string? name, string? email)
    {
        var q = _db.Professors.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(document))
            q = q.Where(p => p.Document.Contains(document));
        if (!string.IsNullOrWhiteSpace(name))
            q = q.Where(p => p.FullName.Contains(name));
        if (!string.IsNullOrWhiteSpace(email))
            q = q.Where(p => p.Email.Contains(email));

        q = q.OrderBy(p => p.Id);

        var total = await q.CountAsync();
        var items = await q.Skip((page - 1) * pageSize).Take(pageSize)
            .ProjectTo<ProfessorReadDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return (items, total);
    }

    public async Task<ProfessorReadDto?> GetByIdAsync(int id) =>
        await _db.Professors.AsNoTracking()
            .Where(p => p.Id == id)
            .ProjectTo<ProfessorReadDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(ProfessorCreateDto dto)
    {
        var entity = _mapper.Map<Professor>(dto);
        _db.Professors.Add(entity);
        await _db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(int id, ProfessorUpdateDto dto)
    {
        var entity = await _db.Professors.FindAsync(id);
        if (entity is null) return false;
        _mapper.Map(dto, entity);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _db.Professors.FindAsync(id);
        if (entity is null) return false;
        _db.Professors.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}
