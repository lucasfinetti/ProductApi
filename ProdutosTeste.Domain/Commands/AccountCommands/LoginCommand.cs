using System;
using ProdutosTeste.Domain.Commands.AccountCommands.Validations;

namespace ProdutosTeste.Domain.Commands.AccountCommands
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