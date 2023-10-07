using HCMUT_SSO.Models;
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
    }
}
