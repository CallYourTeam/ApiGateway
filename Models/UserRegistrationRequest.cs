namespace ApiGateway.Models
{
    public class UserRegistrationRequest
    {
        public required string Login { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
