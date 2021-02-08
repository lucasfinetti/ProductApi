namespace ProdutosTeste.Domain.Commands.AccountCommands.Validations
{
    public class LoginCommandValidation : AccountValidation<LoginCommand>
    {
        public LoginCommandValidation()
        {
            ValidateUser();
            ValidatePass();
        }
    }
}