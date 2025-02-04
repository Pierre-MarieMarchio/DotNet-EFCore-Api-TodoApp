using System;
using FluentValidation;

namespace TodoApi.Application.Commons;

public abstract class BaseValidator<T> : AbstractValidator<T>
    where T : BaseDto
{
    
    protected BaseValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("L'ID ne peut pas être nul.")
            .GreaterThan(0)
            .WithMessage("L'ID doit être supérieur à zéro"); 
    }
}
