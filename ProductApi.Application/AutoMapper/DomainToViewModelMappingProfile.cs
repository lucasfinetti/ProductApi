using AutoMapper;
using ProductApi.Application.ViewModels;
using ProductApi.Domain.Models;

namespace ProductApi.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
