namespace ApiGateway.Models
{
    public class UserAuthenticationResponse
    {
        public required Guid UserId { get; set; }
        public required string Login { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required DateTime RegistrationDate { get; set; }
        public required List<Guid> Freinds { get; set; }
        public required List<Guid> Groups { get; set; }
        public required List<Guid> Chanels { get; set; }
    }
}
