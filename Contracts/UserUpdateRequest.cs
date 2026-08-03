using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Contracts
{
    public record UserUpdateRequest
    (
        [Required] Guid UserId,
        [Required] string Password,
        [Required] string Login,
        [Required] string Email,
        [Required] string NewPassword,
        [Required] List<Guid> Friends,
        [Required] List<Guid> Groups,
        [Required] List<Guid> Chanels
    );
}
