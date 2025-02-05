using System;
using FluentValidation;
using TodoApi.Application.Commons;
using TodoApi.Application.DTO;

namespace TodoApi.Application.Validations;

public class TodoItemTagValidator : BaseValidator<TodoItemTagDto>
{
    public TodoItemTagValidator()
    {
        RuleFor(x => x.TagName)
           .NotEmpty().WithMessage("Le nom du tag est requis.")
           .Length(2, 50).WithMessage("Le nom du tag doit contenir entre 2 et 50 caractères.");
    }
}
