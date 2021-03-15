using System;
using System.Threading;
using System.Threading.Tasks;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using ProductApi.Domain.Services.Interfaces;
using ProductApi.Domain.Services.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace ProductApi.Domain.Commands.AccountCommands
{
    public class AccountCommandHandler : CommandHandler,
        IRequestHandler<LoginCommand, ValidationResult>
    {
        private readonly IRestService _restService;
        private readonly IConfiguration _configuration;

        public AccountCommandHandler(IRestService restService, IConfiguration configuration)
        {
            _restService = restService;
            _configuration = configuration;
        }

        public async Task<ValidationResult> Handle(LoginCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var request = new RestModel()
            {
                URL = _configuration["AppSettings:ProductsApi:URL"].ToString(),
                Username = message.Username,
                Password = message.Password
            };

            var response = await _restService.POST(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                AddError(response.Content);
                return ValidationResult;
            }

            return ValidationResult;
        }
    }
}