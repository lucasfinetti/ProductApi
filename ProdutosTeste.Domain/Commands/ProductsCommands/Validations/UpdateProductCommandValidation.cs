namespace ProdutosTeste.Domain.Commands.ProductsCommands.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateValue();
            ValidateImage();
        }
    }
}