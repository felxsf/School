using FluentValidation;
using School.Application.Grades;

namespace School.Application.Validation;

public class GradeCreateDtoValidator : AbstractValidator<GradeCreateDto>
{
    public GradeCreateDtoValidator()
    {
        RuleFor(x => x.EnrollmentId).GreaterThan(0);
        RuleFor(x => x.Type).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Value).InclusiveBetween(0, 100);
        // GradedAt opcional; si viene null, en mapping ponemos DateTime.UtcNow
    }
}

public class GradeUpdateDtoValidator : AbstractValidator<GradeUpdateDto>
{
    public GradeUpdateDtoValidator()
    {
        RuleFor(x => x.Type).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Value).InclusiveBetween(0, 100);
    }
}
