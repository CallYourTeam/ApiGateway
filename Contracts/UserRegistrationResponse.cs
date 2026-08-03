using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Contracts
{
    public record UserRegistrationResponse
    (
        [Required] Guid UserId
    );
}
