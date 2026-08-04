using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Contracts.User
{
    public record UserUpdateRequest
    (
        [Required] Guid UserId,
        [Required] string Login,
        [Required] string Email,
        [Required] string Password,
        [Required] List<Guid> Friends,
        [Required] List<Guid> Groups,
        [Required] List<Guid> Chanels
    );
}
