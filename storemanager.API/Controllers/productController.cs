using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using storemanager.Application.Services.Interfaces;
using storemanager.Application.ViewModels.ResultView;
using storemanager.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storemanager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productController : Controller
    {
        private readonly IproductsService _productService;
        private readonly ILogger<customersController> _logger;
        public productController(ILogger<customersController> logger, IproductsService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tblproduct model)
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"Create products");
            
            Result = await _productService.Create(model.Name, model.Price);
            return Ok(Result);
        }

        [HttpGet]
        [Route("list-product")]
        public async Task<IActionResult> GetList()
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"list products");
            Result = await _productService.GetList();
            return Ok(Result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(string Id)
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"product by id");
            Result = await _productService.GetId(Guid.Parse(Id));
            return Ok(Result);
        }

        //[HttpGet]
        //[Route("get-by-name")]
        //public async Task<IActionResult> GetByName(string name)
        //{
        //    ResultViewModel Result = new ResultViewModel();
        //    _logger.LogInformation($"product by id");
        //    Result = await _productService.GetName(name);
        //    return Ok(Result);
        //}
    }
}
