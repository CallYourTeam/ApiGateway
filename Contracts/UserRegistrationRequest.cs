using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Contracts
{
    public record UserRegistrationRequest
    (
        [Required] string Login,
        [Required] string Email,
        [Required] string Password
    );
}
