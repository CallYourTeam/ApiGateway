using System.ComponentModel.DataAnnotations;

namespace ApiGateway.Contracts
{
    public record UserAuthenticationResponse
    (
        [Required] Guid UserId,
        [Required] string Login,
        [Required] string Email,
        [Required] string PasswordHash,
        [Required] DateTime RegistrationDate,
        [Required] List<Guid> Freinds,
        [Required] List<Guid> Groups,
        [Required] List<Guid> Chanels
    );
}
