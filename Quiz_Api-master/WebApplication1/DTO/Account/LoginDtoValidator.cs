﻿using FluentValidation;
using FluentValidation.Validators;

namespace QUIZZZ.DTO.Account
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName is required");

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage("Password is required")
               .MinimumLength(3)
               .WithMessage("Minimum Length 3");

        }

    }
}
