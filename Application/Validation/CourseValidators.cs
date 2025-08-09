using FluentValidation;
using School.Application.Courses;

namespace School.Application.Validation;

public class CourseCreateDtoValidator : AbstractValidator<CourseCreateDto>
{
    public CourseCreateDtoValidator()
    {
        RuleFor(x => x.Code).NotEmpty().Length(4, 16);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Credits).InclusiveBetween(1, 10);
        RuleFor(x => x.ProfessorId).GreaterThan(0);
    }
}

public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
{
    public CourseUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Credits).InclusiveBetween(1, 10);
        RuleFor(x => x.ProfessorId).GreaterThan(0);
    }
}
