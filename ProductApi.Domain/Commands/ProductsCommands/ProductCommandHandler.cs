using System;
using System.Threading;
using System.Threading.Tasks;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;


namespace ProductApi.Domain.Commands.ProductsCommands
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, ValidationResult>,
        IRequestHandler<UpdateProductCommand, ValidationResult>,
        IRequestHandler<RemoveProductCommand, ValidationResult>
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = new Product(Guid.NewGuid(), message.Name, message.Value, message.Image);

            if (await _productRepository.GetByName(product.Name) != null)
            {
                AddError("Um produto com esse nome ja existe.");
                return ValidationResult;
            }

            //product.AddDomainEvent(new ProductRegisteredEvent(product.Id, product.Name, product.Email, product.BirthDate));

            _productRepository.Add(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = new Product(message.Id, message.Name, message.Value, message.Image);

            var existingProduct = await _productRepository.GetByName(product.Name);

            if (existingProduct != null && existingProduct.Id != product.Id)
            {
                if (!existingProduct.Equals(product))
                {
                    AddError("Um produto com esse nome ja existe.");
                    return ValidationResult;
                }
            }

            //product.AddDomainEvent(new ProductUpdatedEvent(product.Id, product.Name, product.Email, product.BirthDate));

            _productRepository.Update(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var product = await _productRepository.GetById(message.Id);

            if (product is null)
            {
                AddError("O produto não existe.");
                return ValidationResult;
            }

            //product.AddDomainEvent(new ProductRemovedEvent(message.Id));

            _productRepository.Remove(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
