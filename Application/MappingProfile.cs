using Application.Students;
using AutoMapper;
using Domain.Entities;
using School.Application.Courses;
using School.Application.Grades;
using School.Application.Professors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentReadDto>();
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();

        // Professors
        CreateMap<Professor, ProfessorReadDto>();
        CreateMap<ProfessorCreateDto, Professor>();
        CreateMap<ProfessorUpdateDto, Professor>();

        // Courses
        CreateMap<Course, CourseReadDto>()
            .ForMember(d => d.ProfessorName, o => o.MapFrom(s => s.Professor.FullName));
        CreateMap<CourseCreateDto, Course>();
        CreateMap<CourseUpdateDto, Course>();

        // Grades
        CreateMap<Grade, GradeReadDto>()
            .ForMember(d => d.StudentId, o => o.MapFrom(s => s.Enrollment.StudentId))
            .ForMember(d => d.CourseId, o => o.MapFrom(s => s.Enrollment.CourseId))
            .ForMember(d => d.CourseCode, o => o.MapFrom(s => s.Enrollment.Course.Code));
        CreateMap<GradeCreateDto, Grade>()
    .ForMember(d => d.GradedAt, o => o.MapFrom(s => s.GradedAt ?? DateTime.UtcNow));
        CreateMap<GradeUpdateDto, Grade>()
            .ForMember(d => d.GradedAt, o => o.MapFrom(s => s.GradedAt ?? DateTime.UtcNow));
    }
}
