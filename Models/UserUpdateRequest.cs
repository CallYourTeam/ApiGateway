namespace ApiGateway.Models
{
    public class UserUpdateRequest
    {
        public required Guid UserId { get; set; }
        public required string Password { get; set; }
        public required string Login { get; set; }
        public required string Email { get; set; }
        public required string NewPassword { get; set; }
        public required List<Guid> Friends { get; set; }
        public required List<Guid> Groups { get; set; }
        public required List<Guid> Chanels { get; set; }
    }
}
