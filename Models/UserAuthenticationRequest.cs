namespace ApiGateway.Models
{
    public class UserAuthenticationRequest
    {
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
