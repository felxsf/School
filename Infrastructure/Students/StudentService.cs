using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using School.Application.Students;
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

        public async Task<(IEnumerable<StudentReadDto> items, int total)> GetPagedAsync(int page, int pageSize)
        {
            var query = _db.Students.AsNoTracking().OrderBy(s => s.Id);
            var total = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize)
                .ProjectTo<StudentReadDto>(_mapper.ConfigurationProvider).ToListAsync();
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
