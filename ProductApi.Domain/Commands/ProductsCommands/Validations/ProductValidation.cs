using System;
using FluentValidation;

namespace ProductApi.Domain.Commands.ProductsCommands.Validations
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, você deve digitar um Nome")
                .Length(2, 100).WithMessage("O Nome deve ter entre 2 e 100 caracteres");
        }

        protected void ValidateValue()
        {
            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("Por favor, você deve digitar um Valor");
        }

        protected void ValidateImage()
        {
            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("Por favor, você deve escolher uma Imagem");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        //protected static bool HaveMinimumAge(DateTime birthDate)
        //{
        //    return birthDate <= DateTime.Now.AddYears(-18);
        //}
    }
}
