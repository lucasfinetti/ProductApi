using System;
using ProdutosTeste.Domain.Commands.ProductsCommands.Validations;

namespace ProdutosTeste.Domain.Commands.ProductsCommands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string name, decimal value, string image)
        {
            Id = id;
            Name = name;
            Value = value;
            Image = image;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
