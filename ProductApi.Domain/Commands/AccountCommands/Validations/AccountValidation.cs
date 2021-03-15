using System;
using FluentValidation;

namespace ProductApi.Domain.Commands.AccountCommands.Validations
{
    public abstract class AccountValidation<T> : AbstractValidator<T> where T : AccountCommand
    {
        protected void ValidateUser()
        {
            RuleFor(c => c.Username)
                .NotEmpty().WithMessage("Por favor, você deve digitar um Usuario");
        }

        protected void ValidatePass()
        {
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Por favor, você deve digitar uma Senha");
        }
    }
}