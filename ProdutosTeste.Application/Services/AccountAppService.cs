using System;
using System.Threading.Tasks;
using AutoMapper;
using ProdutosTeste.Application.Interfaces;
using ProdutosTeste.Application.ViewModels;
using FluentValidation.Results;
using NetDevPack.Mediator;
using ProdutosTeste.Domain.Commands.AccountCommands;

namespace ProdutosTeste.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public AccountAppService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Login(LoginViewModel loginViewModel)
        {
            var loginCommand = _mapper.Map<LoginCommand>(loginViewModel);
            return await _mediator.SendCommand(loginCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}