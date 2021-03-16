using ProductApi.Application.Interfaces;
using ProductApi.Application.Services;
using ProductApi.Domain.Commands.ProductsCommands;
using ProductApi.Domain.Core.Events;
using ProductApi.Domain.Interfaces;
using ProductApi.Infra.CrossCutting.Bus;
using ProductApi.Infra.Data.Context;
using ProductApi.Infra.Data.EventSourcing;
using ProductApi.Infra.Data.Repository;
using ProductApi.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace ProductApi.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, ValidationResult>, ProductCommandHandler>();
            
            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ProductContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}