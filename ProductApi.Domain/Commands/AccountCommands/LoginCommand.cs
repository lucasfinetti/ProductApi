using System;
using ProductApi.Domain.Commands.AccountCommands.Validations;

namespace ProductApi.Domain.Commands.AccountCommands
{
    public class LoginCommand : AccountCommand
    {
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override bool IsValid()
        {
            ValidationResult = new LoginCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}