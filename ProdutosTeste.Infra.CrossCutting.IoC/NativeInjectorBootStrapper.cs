using ProdutosTeste.Application.Interfaces;
using ProdutosTeste.Application.Services;
using ProdutosTeste.Domain.Commands.ProductsCommands;
using ProdutosTeste.Domain.Core.Events;
using ProdutosTeste.Domain.Interfaces;
using ProdutosTeste.Infra.CrossCutting.Bus;
using ProdutosTeste.Infra.Data.Context;
using ProdutosTeste.Infra.Data.EventSourcing;
using ProdutosTeste.Infra.Data.Repository;
using ProdutosTeste.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using ProdutosTeste.Domain.Commands.AccountCommands;
using ProdutosTeste.Domain.Services.Interfaces;
using ProdutosTeste.Domain.Services.Services;

namespace ProdutosTeste.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IAccountAppService, AccountAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, ValidationResult>, AccountCommandHandler>();

            // Domain - Services
            services.AddScoped<IRestService, RestService>();
            
            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ProdutoContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}