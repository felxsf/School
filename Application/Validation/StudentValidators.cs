using Application.Students;
using FluentValidation;
using School.Application.Students;

namespace School.Application.Validation;

public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
{
    public StudentCreateDtoValidator()
    {
        RuleFor(x => x.IdentificationNumber).NotEmpty().Length(6, 30);
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.BirthDate).LessThan(DateTime.UtcNow.AddYears(-5));
    }
}

public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
{
    public StudentUpdateDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.BirthDate).LessThan(DateTime.UtcNow.AddYears(-5));
    }
}
