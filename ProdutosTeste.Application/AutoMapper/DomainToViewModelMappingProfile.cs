using AutoMapper;
using ProdutosTeste.Application.ViewModels;
using ProdutosTeste.Domain.Models;

namespace ProdutosTeste.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
