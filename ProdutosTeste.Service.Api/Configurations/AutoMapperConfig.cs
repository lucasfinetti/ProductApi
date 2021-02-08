﻿using System;
using AutoMapper;
using ProdutosTeste.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ProdutosTeste.Service.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
