using DevFreela.Application.Command.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Validators
{
    public class CreateUserInputModelValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserInputModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("Email deve ser preenchido.")
                .NotNull()
                    .WithMessage("Email deve ser preenchido.");
        }
    }
}
