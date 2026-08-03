using ApiGateway.Contracts;
using ApiGateway.Mapping;
using ApiGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController(IUserGrpcService userService) : ControllerBase
    {
        private readonly IUserGrpcService _userService = userService;

        [HttpPost("reg")]
        public async Task<IActionResult> RegisterNewUser(UserRegistrationRequest request)
        {
            var grcpResponse = await _userService.RegisterUserAsync(request.Login, request.Email, request.Password);

            if (grcpResponse.Error.Length != 0)
            {
                return BadRequest(grcpResponse.Error);
            }

            return Ok(UserMapper.MapUserRegistrationResponse(grcpResponse));
        }

        [HttpGet("auth")]
        public async Task<IActionResult> AuthenticateUser([FromQuery] string login, [FromQuery] string password)
        {
            var grpcResponse = await _userService.AuthenticateUserAsync(login, password);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok(UserMapper.MapUserAuthenticationResponse(grpcResponse));
        }

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest request)
        {
            var grpcResponse = await _userService.UpdateUserAsync(request.UserId, request.Password, request.Login, request.Email, request.NewPassword, request.Friends, request.Groups, request.Chanels);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser([FromQuery] string userId, [FromQuery] string password)
        {
            var grpcResponse = await _userService.DeleteUserAsync(Guid.Parse(userId), password);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok();
        }
    }
}
