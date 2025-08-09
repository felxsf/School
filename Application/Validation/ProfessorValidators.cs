using FluentValidation;
using School.Application.Professors;

namespace School.Application.Validation;

public class ProfessorCreateDtoValidator : AbstractValidator<ProfessorCreateDto>
{
    public ProfessorCreateDtoValidator()
    {
        RuleFor(x => x.Document).NotEmpty().Length(3, 30);
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(160);
    }
}

public class ProfessorUpdateDtoValidator : AbstractValidator<ProfessorUpdateDto>
{
    public ProfessorUpdateDtoValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(160);
    }
}
