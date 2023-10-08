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
        public UserController(HcmutSsoContext context) { 
            _context = context;
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
            //Result = await _userRepository.CheckUser(userName, password);

            //if (Result == null)
            //{
            //    Result.status = 0;
            //    Result.message = "Tài khoản không tồn tại trong hệ thống!";
            //}
            //else
            //{
            //    Result.status = 1;
            //    Result.message = "Tài khoản chính xác!";
            //}
            var user = await _context.TblUsers.Where(d => d.UserName == userName && d.Password == passWord).FirstOrDefaultAsync();
            if (user == null)
            {
                Result.status = 0;
                Result.message = "Tài khoản không tồn tại trong hệ thống!";
            }
            else
            {
                Result.status = 1;
                Result.message = "Tài khoản chính xác!";
            }
            return Ok(Result);
        }
    }
}
