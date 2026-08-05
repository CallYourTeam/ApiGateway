using ApiGateway.Contracts.User;
using ApiGateway.Jwt;
using ApiGateway.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UtilsModule;

namespace ApiGateway.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController(IUserGrpcService userService, IJwtProvider jwtProvider) : ControllerBase
    {
        private readonly IUserGrpcService _userService = userService;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        [HttpPost("reg")]
        public async Task<IActionResult> RegisterNewUser([FromBody] UserRegistrationRequest request)
        {
            var grpcResponse = await _userService.RegisterUserAsync(request.Login, request.Email, request.Password);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            var jwtToken = _jwtProvider.GenerateToken(Guid.Parse(grpcResponse.UserId));

            return Ok(jwtToken);
        }

        [HttpGet("auth")]
        public async Task<IActionResult> AuthenticateUser([FromQuery] string login, [FromQuery] string password)
        {
            var grpcResponse = await _userService.AuthenticateUserAsync(login, password);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            var jwtToken = _jwtProvider.GenerateToken(Guid.Parse(grpcResponse.UserId));

            return Ok(jwtToken);
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request)
        {
            var grpcResponse = await _userService.UpdateUserAsync(request.UserId, request.Login, request.Email, request.Password, request.Friends, request.Groups, request.Chanels);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok();
        }

        [HttpDelete("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromQuery] string userId, [FromQuery] string password)
        {
            var grpcResponse = await _userService.DeleteUserAsync(Guid.Parse(userId), password);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok();
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetUser([FromQuery] string login)
        {
            var grpcResponse = await _userService.GetUserAsync(login);

            if (grpcResponse.Error.Length != 0)
            {
                return BadRequest(grpcResponse.Error);
            }

            return Ok(new UserGetResponse(
                grpcResponse.Login,
                DateTime.Parse(grpcResponse.RegisterationDate),
                Utils.StringToList(grpcResponse.Friends, Guid.Parse),
                Utils.StringToList(grpcResponse.Groups, Guid.Parse),
                Utils.StringToList(grpcResponse.Chanels, Guid.Parse)
            ));
        }
    }
}
