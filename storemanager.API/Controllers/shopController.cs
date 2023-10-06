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
    public class shopController : Controller
    {
        private readonly IshopsService _shopsService;
        private readonly ILogger<shopController> _logger;
        public shopController(ILogger<shopController> logger, IshopsService shopsService)
        {
            _logger = logger;
            _shopsService = shopsService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Tblshop model)
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"Create shops");
            
            Result = await _shopsService.Create(model.Name, model.Location);
            return Ok(Result);
        }

        [HttpGet]
        [Route("list-shop")]
        public async Task<IActionResult> GetList()
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"list shops");           
            Result = await _shopsService.GetListShop();
            return Ok(Result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(string Id)
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"list shops");
            Result = await _shopsService.GetId(Guid.Parse(Id));
            return Ok(Result);
        }
    }
}
