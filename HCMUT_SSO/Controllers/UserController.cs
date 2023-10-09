using HCMUT_SSO.Interfaces;
using HCMUT_SSO.Models;
using HCMUT_SSO.ViewModels.ResultView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCMUT_SSO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HcmutSsoContext _context;
        private readonly IUserRepository _userRepository;

        public UserController(HcmutSsoContext context, IUserRepository userRepository) { 
            _context = context;
            _userRepository = userRepository;   
        }

        [HttpGet]
        public async Task<ActionResult<List<TblUser>>> Getuser() {
            return Ok(await _context.TblUsers.ToListAsync());
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> CheckAuthenticationLogin(string userName, string passWord)
        {
            ResultViewModel Result = new ResultViewModel();
            Result = await _userRepository.CheckUser(userName, passWord);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Result);
        }
    }
}
