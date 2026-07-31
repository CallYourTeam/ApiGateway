using Microsoft.AspNetCore.Mvc;

namespace API_Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost(Name = "user/reg")]
        public async Task<IActionResult> RegisterNewUser()
        {
            return Ok();
        }

        [HttpGet(Name = "user/auth")]
        public async Task<IActionResult> AuthenticateUser()
        {
            return Ok();
        }

        [HttpPatch(Name = "user/update")]
        public async Task<IActionResult> UpdateUser()
        {
            return Ok();
        }

        [HttpDelete(Name = "user/delete")]
        public async Task<IActionResult> DeleteUser()
        {
            return Ok();
        }
    }
}
