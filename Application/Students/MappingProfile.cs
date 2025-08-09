using AutoMapper;
using Domain.Entities;
using School.Application.Students;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace School.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentReadDto>();
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();
    }
}
