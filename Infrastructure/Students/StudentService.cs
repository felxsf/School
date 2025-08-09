using Application.Students;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using School.Application.Students;
using School.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Students
{
    public class StudentService : IStudentService
    {
        private readonly SchoolDbContext _db;
        private readonly IMapper _mapper;
        public StudentService(SchoolDbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

        public async Task<(IEnumerable<StudentReadDto> items, int total)> GetPagedAsync(
            int page,
            int pageSize,
            string? identification,
            string? firstName,
            string? lastName,
            DateTime? birthDateFrom,
            DateTime? birthDateTo)
        {
            var q = _db.Students.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(identification))
                q = q.Where(s => s.IdentificationNumber.Contains(identification));
            if (!string.IsNullOrWhiteSpace(firstName))
                q = q.Where(s => s.FirstName.Contains(firstName));
            if (!string.IsNullOrWhiteSpace(lastName))
                q = q.Where(s => s.LastName.Contains(lastName));
            if (birthDateFrom.HasValue)
                q = q.Where(s => s.BirthDate >= birthDateFrom.Value);
            if (birthDateTo.HasValue)
                q = q.Where(s => s.BirthDate <= birthDateTo.Value);

            q = q.OrderBy(s => s.Id);

            var total = await q.CountAsync();
            var items = await q.Skip((page - 1) * pageSize).Take(pageSize)
                .ProjectTo<StudentReadDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return (items, total);
        }

        public async Task<StudentReadDto?> GetByIdAsync(int id) =>
            await _db.Students.AsNoTracking().Where(s => s.Id == id)
                .ProjectTo<StudentReadDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

        public async Task<StudentReadDto?> GetByIdentificationAsync(string identificationNumber) =>
            await _db.Students.AsNoTracking().Where(s => s.IdentificationNumber == identificationNumber)
                .ProjectTo<StudentReadDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

        public async Task<int> CreateAsync(StudentCreateDto dto)
        {
            var entity = _mapper.Map<Student>(dto);
            _db.Students.Add(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(int id, StudentUpdateDto dto)
        {
            var entity = await _db.Students.FindAsync(id);
            if (entity is null) return false;
            _mapper.Map(dto, entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Students.FindAsync(id);
            if (entity is null) return false;
            _db.Students.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
