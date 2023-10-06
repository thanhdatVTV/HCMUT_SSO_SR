using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using storemanager.Application.Services;
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
    public class customersController : ControllerBase
    {
        private readonly IcustomersService _customersService;
        private readonly ILogger<customersController> _logger;
        public customersController(ILogger<customersController> logger, IcustomersService customersService)
        {
            _logger = logger;
            _customersService = customersService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tblcustomer model)
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"Create customers");           
            Result= await _customersService.Create( model.FullName, model.Dob, model.Email);
            return  Ok(Result); 
        }

        [HttpGet]
        [Route("list-customer")]
        public async Task<IActionResult> GetList()
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"list products");
            Result = await _customersService.GetList();
            return Ok(Result);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(string Id)
        {
            ResultViewModel Result = new ResultViewModel();
            _logger.LogInformation($"product by id");
            Result = await _customersService.GetId(Guid.Parse(Id));
            return Ok(Result);
        }
    }
}
