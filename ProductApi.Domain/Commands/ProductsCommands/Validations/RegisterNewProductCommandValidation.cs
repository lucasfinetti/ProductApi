namespace ProductApi.Domain.Commands.ProductsCommands.Validations
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateName();
            ValidateValue();
            ValidateImage();
        }
    }
}
