using ApiGateway.Mapping;
using ApiGateway.Models;
using ApiGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("user/[controller]")]
    public class UserController(IUserGrpcService userService) : ControllerBase
    {
        private readonly IUserGrpcService _userService = userService;

        [HttpPost(Name = "reg")]
        public async Task<IActionResult> RegisterNewUser(UserRegistrationRequest request)
        {
            var grcpResponse = await _userService.RegisterUserAsync(request.Login, request.Email, request.Password);

            if (grcpResponse.Error.Length == 0)
            {
                return BadRequest(grcpResponse.Error);
            }

            return Ok(UserMapper.MapUserRegistrationResponse(grcpResponse));
        }

        [HttpGet(Name = "auth")]
        public async Task<IActionResult> AuthenticateUser(UserAuthenticationRequest request)
        {
            var grpcResponse = await _userService.AuthenticateUserAsync(request.Login, request.Password);

            if (grpcResponse.Error.Length == 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok(UserMapper.MapUserAuthenticationResponse(grpcResponse));
        }

        [HttpPatch(Name = "update")]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest request)
        {
            var grpcResponse = await _userService.UpdateUserAsync(request.UserId, request.Password, request.Login, request.Email, request.NewPassword, request.Friends, request.Groups, request.Chanels);

            if (grpcResponse.Error.Length == 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok();
        }

        [HttpDelete(Name = "delete")]
        public async Task<IActionResult> DeleteUser(UserDeleteRequest request)
        {
            var grpcResponse = await _userService.DeleteUserAsync(request.UserId, request.Password);

            if (grpcResponse.Error.Length == 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok();
        }
    }
}
