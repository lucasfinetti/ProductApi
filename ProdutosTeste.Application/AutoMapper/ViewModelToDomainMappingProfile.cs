using AutoMapper;
using ProdutosTeste.Application.ViewModels;
using ProdutosTeste.Domain.Commands.AccountCommands;
using ProdutosTeste.Domain.Commands.ProductsCommands;

namespace ProdutosTeste.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(p => new RegisterNewProductCommand(p.Name, p.Value, p.Image));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(p => new UpdateProductCommand(p.Id, p.Name, p.Value, p.Image));
            CreateMap<LoginViewModel, LoginCommand>()
                .ConstructUsing(p => new LoginCommand(p.Username, p.Password));
        }
    }
}
