using System;
using FluentValidation;
using TodoApi.Application.Commons;
using TodoApi.Application.DTO;

namespace TodoApi.Application.Validations;

public class UserValidator : BaseValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Le nom d'utilisateur est requis.")
            .Length(3, 50).WithMessage("Le nom d'utilisateur doit contenir entre 3 et 50 caractères.");

 
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("L'email est requis.")
            .EmailAddress().WithMessage("Format d'email invalide.");


        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Le mot de passe est requis.")
            .MinimumLength(8).WithMessage("Le mot de passe doit contenir au moins 8 caractères.")
            .Matches(@"[A-Z]").WithMessage("Le mot de passe doit contenir au moins une lettre majuscule.")
            .Matches(@"[a-z]").WithMessage("Le mot de passe doit contenir au moins une lettre minuscule.")
            .Matches(@"[0-9]").WithMessage("Le mot de passe doit contenir au moins un chiffre.")
            .Matches(@"[\W_]").WithMessage("Le mot de passe doit contenir au moins un caractère spécial.");
    }
}

