using ProductApi.Domain.Commands.ProductsCommands.Validations;

namespace ProductApi.Domain.Commands.ProductsCommands
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand(string name, decimal value, string image)
        {
            Name = name;
            Value = value;
            Image = image;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
