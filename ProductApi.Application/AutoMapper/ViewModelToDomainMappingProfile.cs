using AutoMapper;
using ProductApi.Application.ViewModels;
using ProductApi.Domain.Commands.AccountCommands;
using ProductApi.Domain.Commands.ProductsCommands;

namespace ProductApi.Application.AutoMapper
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
