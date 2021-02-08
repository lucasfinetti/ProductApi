using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProdutosTeste.Application.ViewModels;
using FluentValidation.Results;

namespace ProdutosTeste.Application.Interfaces
{
    public interface IAccountAppService : IDisposable
    {
        Task<ValidationResult> Login(LoginViewModel loginViewModel);
    }
}
