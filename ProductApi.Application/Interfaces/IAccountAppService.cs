using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Application.ViewModels;
using FluentValidation.Results;

namespace ProductApi.Application.Interfaces
{
    public interface IAccountAppService : IDisposable
    {
        Task<ValidationResult> Login(LoginViewModel loginViewModel);
    }
}
