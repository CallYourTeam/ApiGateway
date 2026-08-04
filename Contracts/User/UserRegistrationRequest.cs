using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Contracts.User
{
    public record UserRegistrationRequest
    (
        [Required] string Login,
        [Required] string Email,
        [Required] string Password
    );
}
