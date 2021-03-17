using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Application.Interfaces;
using ProductApi.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;

namespace ProductApi.Service.Api.Controllers
{
    [Route("api/product-management")]
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [CustomAuthorize("Products", "Read")]
        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            return await _productAppService.GetAll();
        }

        [CustomAuthorize("Products", "Read")]
        [HttpGet("{id:guid}")]
        public async Task<ProductViewModel> Get(Guid id)
        {
            return await _productAppService.GetById(id);
        }

        [CustomAuthorize("Products", "Write")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel productViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _productAppService.Register(productViewModel));
        }

        [CustomAuthorize("Products", "Write")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductViewModel productViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _productAppService.Update(productViewModel));
        }

        [CustomAuthorize("Products", "Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _productAppService.Remove(id));
        }
    }
}