using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Application.Interfaces;
using ProductApi.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;

namespace ProductApi.Service.Api.Controllers
{
    [Route("account-management")]
    public class AccountController : ApiController
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginViewModel loginViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _accountAppService.Login(loginViewModel));
        }
    }
}
