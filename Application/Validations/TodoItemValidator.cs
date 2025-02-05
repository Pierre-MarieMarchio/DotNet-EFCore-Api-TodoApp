using System;
using FluentValidation;
using TodoApi.Application.Commons;
using TodoApi.Application.DTO;


namespace TodoApi.Application.Validations;

public class TodoItemValidator : BaseValidator<TodoItemDto>
{
    public TodoItemValidator()
    {

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Le titre est requis.")
            .MaximumLength(100).WithMessage("Le titre ne doit pas dépasser 100 caractères.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("L'ID utilisateur est requis.");
    }
}
